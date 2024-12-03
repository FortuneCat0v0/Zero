////////////////////////////////////////////////////////////////////////////////////////////
                      Stylized_Element_Splash_vol.1 (by. VFX_Klaus)
////////////////////////////////////////////////////////////////////////////////////////////

Thank you for purchasing the Stylized_Element_Splash_vol.1.
This note describes how this package is configured, how texture should be used, and how it works within a Particle System.

To use in Built-in, you have to install "Shader Graph" from package managerand also your project version must be 2021.2.0 or higher.

I put all the effect elements into two textures so that each prefab uses the least amount of material.

The structure of the texture is as follows.

   ▷ Red channel is main texture.
   ▷ Green channel is dissolve texture. The main texture gradually dissolve into the shape of green texture.
   ▷ Blue channel gives UV distortion.
   ▷ And Alpha channel.

These effects can be modified by two Custom Data in the Particle System.

There are 4 Components in Custom Data 1.

   ▷ X value is for Dissolve. From 0 to 1, it gradually dissolves.
   ▷ Y value is for Dissolve Sharpness. The larger the number, the sharper the edges of dissolve.
   ▷ Z value is for Distortion. The larger the number, the stronger the distortion.
   ▷ W value is for Soft Particle Factor. As the number goes to zero, the overlap of mesh becomes transparent.

You can use Custom Data 2 to add highlight colors.
If you don't want to use the highlight color, change the custom data 2 mode to 'Disabled'.

There are four materials in my package and all materials use only one shader.

You can see the names "Mat_fx_ --- _highlight_outer" and "Mat_fx_ --- _highlight_inner".
This name literally indicates whether the highlight will be on the outside or inside.
For example, If you use "Mat_fx_ --- _highlight_outer", the highlight color of effect will appear outside.

Each material has two parameters "Highlight_Min" and "Highlight_Max".
By adjusting the two parameters, you can change the thickness of the highlight.

All materials use only one shader.

Material and shader named "Explosion_lab" are not used for effects. It was used in the background of Scene just to show the effect.

If your project environment is 2D or 2D Experimental and you can't see the effect, please set the "Use SoftParticle Factor?" bool parameter of all materials to off.

Thank you once again, and I hope my effect will be useful for your development.
- KFX_Klaus