////////////////////////////////////////////////////////////////////////////////////////////
                      Stylized Explosion Package (by. VFX_Klaus)
////////////////////////////////////////////////////////////////////////////////////////////

Thank you for purchasing the Styled Exploration Package.
This note describes how this package is configured, how texture should be used, and how it works within a Particle System.

All the effect prepab is made of only two materials(Additive and Alpha Blended). These materials use only one texture.
I put all the elements of explosion into that one texture.

   ▷ Red channel is main texture.
   ▷ Green channel is dissolve texture. The main texture gradually dissolve into the shape of green texture.
   ▷ Blue channel gives UV distortion.

These RGB channels can be modified by Custom Data in the Particle System.
There are 4 Components of Custom Data.

   ▷ X value is for Dissolve. From 0 to 1, it gradually dissolves.
   ▷ Y value is for Dissolve Sharpness. The larger the number, the sharper the edges of dissolve.
   ▷ Z value is for Distortion. The larger the number, the stronger the distortion.
   ▷ W value is for Soft Particle Factor. As the number goes to zero, the overlap of mesh becomes transparent.

Material and shader named "Explosion_lab" are not used for explosion effects. It was used in the background of Scene just to show the effect.

-------------------------------------------------------------------
                      Update 1.1 - URP, HDRP available
-------------------------------------------------------------------

This update included ShaderGraph shader so that it can be used in projects that use Render Pipeline such as URP or HDRP.
The original shader I made may seem to work on the Render Pipeline, but that's not the shape I intended.

So if you're a developer working on the Render Pipeline project, Please replace the ShaderGraph shader on the each material.
(I put "_SG" after the file name of the ShaderGraph shader to distinguish it from the original shader.)

   ① Open the "Materials" folder. Then you can see 3 materials.
   ② You can click on each material to replace the shader on the Inspector tab, or open the "Shaders" folder and drag the shader into the material.
         ▷"Explosion_lab_SG" shader → "Explosion_lab" material
         ▷"Fx_explosion_add_SG" shader → "Mat_fx_explosion_set_add" material
         ▷"Fx_explosion_apb_SG" shader → "Mat_fx_explosion_set_apb" material
   ③ If you replace the shader of the material, it will be applied automatically to all effects.

-------------------------------------------------------------------
                   Update 1.2 - Organize folders
-------------------------------------------------------------------
"Fx_explosion_add" shader naming error correction.
"VFX_Klaus/fx_explosion_apb" → "VFX_Klaus/fx_explosion_add"

-------------------------------------------------------------------
                Update 1.3 - Added Emissive Parameter
-------------------------------------------------------------------
Added "Emissive Power" parameter in additive material to adjust Bloom (Post Process)


Thank you once again, and I hope my effect will be useful for your development.
- KFX_Klaus