Shader "Hovl/Particles/Blend_TwoSides_URP"
{
    Properties
    {
        _Cutoff("Mask Clip Value", Float) = 0.5
        _MainTex("Main Tex", 2D) = "white" {}
        _Mask("Mask", 2D) = "white" {}
        _Noise("Noise", 2D) = "white" {}
        _SpeedMainTexUVNoiseZW("Speed MainTex U/V + Noise Z/W", Vector) = (0,0,0,0)
        _FrontFacesColor("Front Faces Color", Color) = (0,0.2313726,1,1)
        _BackFacesColor("Back Faces Color", Color) = (0.1098039,0.4235294,1,1)
        _Emission("Emission", Float) = 2
        [Toggle]_UseFresnel("Use Fresnel?", Float) = 1
        [Toggle]_SeparateFresnel("SeparateFresnel", Float) = 0
        _SeparateEmission("Separate Emission", Float) = 2
        _FresnelColor("Fresnel Color", Color) = (1,1,1,1)
        _Fresnel("Fresnel", Float) = 1
        _FresnelEmission("Fresnel Emission", Float) = 1
        [Toggle]_UseCustomData("Use Custom Data?", Float) = 0
        [HideInInspector] _texcoord("", 2D) = "white" {}
        [HideInInspector] _tex4coord("", 2D) = "white" {}
        [HideInInspector] __dirty("", Int) = 1
    }

    SubShader
    {
        Tags { "RenderType" = "TransparentCutout" "Queue" = "Transparent+0" "IsEmissive" = "true" "PreviewType" = "Plane" }
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv : TEXCOORD0;
                float4 uv4 : TEXCOORD4;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
                float2 uv : TEXCOORD3;
                float4 uv4 : TEXCOORD4;
                float4 color : COLOR;
            };

            float _Cutoff;
            float4 _MainTex_ST;
            float4 _Mask_ST;
            float4 _Noise_ST;
            float4 _SpeedMainTexUVNoiseZW;
            float4 _FrontFacesColor;
            float4 _BackFacesColor;
            float _Emission;
            float _Fresnel;
            float _FresnelEmission;
            float4 _FresnelColor;
            float _SeparateFresnel;
            float _UseFresnel;
            float _SeparateEmission;
            float _UseCustomData;

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_Mask);
            SAMPLER(sampler_Mask);
            TEXTURE2D(_Noise);
            SAMPLER(sampler_Noise);

            Varyings vert(Attributes input)
            {
                Varyings output;
                float3 worldPos = TransformObjectToWorld(input.positionOS);
                float3 worldNormal = TransformObjectToWorldNormal(input.normalOS);
                float3 viewDir = GetCameraPositionWS() - worldPos;

                output.positionHCS = TransformWorldToHClip(worldPos);
                output.worldPos = worldPos;
                output.worldNormal = worldNormal;
                output.viewDir = viewDir;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.uv4 = input.uv4;
                output.color = input.color;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float3 worldPos = input.worldPos;
                float3 viewDir = normalize(input.viewDir);
                float3 worldNormal = normalize(input.worldNormal);
                float fresnelNdotV = dot(worldNormal, viewDir);
                float fresnelEffect = pow(1.0 - fresnelNdotV, _Fresnel);
                float fresnel = saturate(fresnelEffect);
                float4 frontColor = _FrontFacesColor;
                float4 backColor = _BackFacesColor;
                float4 finalColor = lerp(frontColor, backColor, step(0.0, -fresnelNdotV));

                if (_UseFresnel > 0)
                {
                    finalColor = lerp(frontColor, frontColor * (1.0 - fresnel) + _FresnelColor * fresnel * _FresnelEmission, _UseFresnel);
                }

                float2 uv = input.uv + _SpeedMainTexUVNoiseZW.xy * _Time.y;
                float4 mainTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);

                finalColor.rgb *= mainTex.rgb * input.color.rgb * _Emission;

                if (_SeparateFresnel > 0)
                {
                    finalColor.rgb = lerp(finalColor.rgb, (finalColor.rgb + _FresnelColor.rgb * mainTex.rgb * _SeparateEmission), _SeparateFresnel);
                }

                float2 maskUV = input.uv * _Mask_ST.xy + _Mask_ST.zw;
                float2 noiseUV = input.uv4.xy * _Noise_ST.xy + _Noise_ST.zw + _SpeedMainTexUVNoiseZW.zw * _Time.y;
                float mask = SAMPLE_TEXTURE2D(_Mask, sampler_Mask, maskUV).r;
                float noise = SAMPLE_TEXTURE2D(_Noise, sampler_Noise, noiseUV).r;

                if (_UseCustomData > 0)
                {
                    noise = lerp(1.0, noise, input.uv4.z);
                }

                clip(mask * noise - _Cutoff);

                return finalColor;
            }
            ENDHLSL
        }
    }
    FallBack "Diffuse"
}
