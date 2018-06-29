# MixedShadowSample

Read this in other languages: English, [日本語](README.ja.md)<br />


## Original Source
  https://github.com/Unity-Technologies/ScriptableRenderPipeline
  Customized from "LWRP 1.1.8-preview".

## Image

![alt text](docs/img/MixShadow.png)


Non-Customized "LWRP" renders like this.

![alt text](docs/NG_Pattern1.png)




## RenderPass Flow

![alt text](docs/1st_step.png)<br/>
1.Generate ShadowMap renders only Character.

![alt text](docs/2nd_step.png)<br/>
2.Rendering BG Objects with ShadowMap(CharacterOnly)

![alt text](docs/3rd_step.png)<br/>
3.Rebdering Character to ShadowMap.

![alt text](docs/4th_step.png)<br/>
4.Render Character with ShadowMap.


## Why?
 - Reduce the rendering cost.Because we should only care around the Character.<br/>
 - We can make ShadowMapTexture lower resolution because the shadow distance become shorter.<br/>
 - BG shadows are baked. So its quality is high.

