茜式宝石シェーダー (akanevrc_JewelShader)


This product is a shader of Unity built-in rendering pipeline.
Not contains 3D models.
Supports to use in VRChat for Windows.
(There is no problem even if you use it for purposes other than VRChat)


[ Caution! ]
The meshes that is applied with this shader correctly, there are conditions.
The condition: The mesh is continuous in a polar coordinate system with the specified centroid position as the origin

Also, since this shader refers to the Reflection Probe (or Skybox),
objects that do not appear in the Reflection Probe will not be transparent.


[ Sale ]
URL : https://akanezoranomukou.booth.pm/
Seller : 茜 (akanevrc)

[ Author ]
茜（akanevrc）

[ Verification Environment ]
Unity 2019.4.31f1

[ Requirements for VRChat ]
VRChat Windows Edition
(Not for Oculus/Meta Quest Edition! Please be careful!)

[ License ]
CC0
https://creativecommons.org/share-your-work/public-domain/cc0/


[ Abstraction ]
akanevrc_JewelShader is a shader that reproduces the refraction and reflection of transparent substances.
This shader is very fast because draw in 1 pass without using rays by baking normal data to a cubemap.
Both hard edge and soft edge supported.
The color of the object can be specified.
It is possible to reproduce a prism-like spectrum.
It gives a photorealistic look and is better suited for larger objects than smaller ones.


[ Usage ]
It is necessary for this shader works correctly,
required to bake normals into a cubemap and apply the generated material to the target mesh.
The way to do it is like this...

1. Place in the scene the prefab that will be in following path.
  Assets/akanevrc/JewelShader/CubemapBaker/CubemapBaker.prefab
2. Set a Prefab/GameObject that contains the mesh
  to which the shader will be applied in the input field below.
  「Target mesh Prefab/GameObject」（処理対象のメッシュを含むPrefab/GameObject）
3. Click the 「Bake」（ベイク） button, and specify saving path of cubemap and material,
  then the PNG format cubemap and the material to which the cubemap is applied are saved.
4. Set the material to the mesh.


[ CubemapBaker ]
This is the script that bake normals into a cubemap.
This can be used when the following prefab placed in the scene.
  Assets/akanevrc/JewelShader/CubemapBaker/CubemapBaker.prefab

Click the 「日本語」（English） button in right-up, will toggle English/Japanese.
Configure items like following...

「Target mesh Prefab/GameObject」（処理対象のメッシュを含むPrefab/GameObject）
The normals of specified mesh will be baked into cubemap.
Basically, specify the mesh that will be applied with the material.
As above, this mesh should be matching the conditions.
(However, can be applied in the fact, errors will not be occured even if condition not suitable.)
The condition: The mesh is continuous in a polar coordinate system with the specified centroid position as the origin

「Specify centroid manually」（中心座標を手動で指定）
When unchecked, the centroid coordinates are automatically calculated from the mesh information.
When checked, the centroid coordinates can be specified to any value.

「Centroid position」（中心座標）
Specify the centroid coordinates If "Specify centroid manually" checked.

「Baked cubemap width」（ベイクされるキューブマップのサイズ）
Specify the width of one face of the cubemap.

「Bake」（ベイク） button
Bake the cubemap along the configurations.
Click this, save file dialog will be shown,
then specify the saving file name.


[ akanevrc_JewelShader/Jewel ]
This is the shader looks like a jewel.
This can be used when set to a material.

Click the 「日本語」（English） button in right-up, will toggle English/Japanese.
Configure items like following...

「Normal Cubemap」（法線キューブマップ）
Specify cubemap baked with CubemapBaker.
This item is automatically set by CubemapBaker when baking.

「Centroid Position」（中心座標）
The center coordinates of the normal baking.
This item is automatically set by CubemapBaker when baking.

「Refractive Index」（屈折率）
Specify refractive index of the object.
As a guide, 1.3 is ice, 1.5 is glass, 1.7 is sapphire, and 2.4 is diamond.

「Light Source 1 - 4」（光源 1～4）
Auxiliary light source (directional light).
You can click the arrow to expand it and set the following parameters.

    「Direction」（向き）
    Specify the direction of the light source.

    「Power Value」（累乗値）
    Specify the power value for light source.
    The smaller it is, the wider the range.

    「Reflection Ratio」（反射率）
    Specifies the reflectance at which the light from the light source
    reflects off the surface of the object.

    「Color (Intensity)」（色（強さ））
    Specify the intensity of light source.
    This is HDR color.

    「Multiplication Factor」（乗算係数）
    A coefficient that determines whether the effect of a light source is additive or productive.
    This value is larger, light source is bright in the bright place and dark in the dark place.
    This value is smaller, light source is bright in both the bright place and the dark place.

    「Weight Factor」（重み係数）
    A coefficient that multiplies the brightness of the light source.
    If 1, ther light will be bright.
    If 0, the light source is disabled.
    If -1, the illuminated position will be darkened.

「Color Attenuation R」（赤の減衰）
「Color Attenuation G」（緑の減衰）
「Color Attenuation B」（青の減衰）
Color of object.
If increase the attenuation of red, it becomes cyan.
If increase the attenuation of green, it becomes magenta.
If increase the attenuation of blue, it becomes yellow.

「Spectorscopy」（分光）
If specify None, spectorscopy will not be performed.
If specify RGB, spectorscopy will be performed like a prism.

「Spectrum Refractive Ratio R」（赤の屈折比率）
「Spectrum Refractive Ratio G」（緑の屈折比率）
「Spectrum Refractive Ratio B」（青の屈折比率）
The values to be multiplied by the refraction index specified above.
Spectroscopy is expressed by appropriately distributing this values.


[ Change Log ]
1.1.4 (2022/07/27)
Change the license to CC0.

1.1.3 (2022/05/24)
Fix a defect in the Small License.

1.1.2 (2022/05/24)
Fix a defect in the Regular License.

1.1.1 (2022/05/20)
Fix a bug about saving material when baking.

1.1.0 (2022/05/20)
Add light source functionality and count.
Change shader property default values.

1.0.0 (2022/05/16)
Implement basic functionality


[ Contacts ]
茜 (akanevrc)
Twitter : @akanevrc
Mail : akanezoranomukou@gmail.com
