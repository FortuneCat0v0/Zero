////////////////////////////////////////////////////////////////////////////////////////////
                       Stylized Earth Skills (by. VFX_Klaus)
////////////////////////////////////////////////////////////////////////////////////////////

Thank you for purchasing the Stylized Earth Skills Package.
This note describes how this package is configured, how texture should be used, and how it works within a Particle System.

This package is for Built-in, URP and HDRP.
To use in Built-in, you have to install "Shader Graph" from package manager and also your project version must be 2021.2.0 or higher.

All the effect prepab is made of only three materials.

1. One is for rock effect using a mesh(fbx). 
   This material use the uv unfolded texture(Tex_fx_rock) of rock modeling.

    ▷ Red channel is main texture.
    ▷ Green channel is dissolve texture. The main texture gradually dissolve into the shape of green texture.
    ▷ Blue channel is for secondary color. It can be changed in the custom data 2 of the particle system.

The particle system using this material uses custom data as follows.

    ▷ Custom Data 1 : X value is for Dissolve. From 0 to 1, it gradually dissolves.
    ▷ Custom Data 2 : Secondary Color

2. And the rests are for effects such as smoke, particle, impact etc.
   They are structurally the same, but one is additive and one is alpha blend.
   The additive one has "Emissive_Power" parameter, so you can use it to amplify the bloom of the post process or to increase the bright area.
   These materials use only one main texture(Tex_fx_particle_set).
   I put all the elements into that one texture. This texture is a tga file so it contains alpha.
   
    ▷ Red channel is main texture.
    ▷ Green channel is dissolve texture. The main texture gradually dissolve into the shape of green texture.
    ▷ Blue channel gives UV distortion.
    ▷ Alpha channel is for alpha.

The particle system using these materials uses custom data as follows.

    ▷ X value is for Dissolve. From 0 to 1, it gradually dissolves.
    ▷ Y value is for Dissolve Sharpness. The larger the number, the sharper the edges of dissolve.
    ▷ Z value is for Distortion. The larger the number, the stronger the distortion.
    ▷ W value is for Soft Particle Factor. As the number goes to zero, the overlap of mesh becomes transparent.

You can check the effect through a simple demo scene called "VFX_Lab_Stylized_Earth_Skills".

Material and shader named "VFX_lab" are not used for effects. It was used in the background of Scene just to show the effect.

Thank you once again, and I hope my effect will be useful for your development.
- KFX_Klaus