# MixedShadowSample

Read this in other languages: English, [日本語](README.ja.md)<br />


## Original Source
  https://github.com/Unity-Technologies/ScriptableRenderPipeline <br />
  Customized from "LWRP 1.1.8-preview".

## Image

### Customed RenderPipeline
<img src="docs/img/MixShadow.png" width="480px" /> <br />

* Realtime shadow renders blued. Baked shadow renders blacked.

### Non-Customized "LWRP" 
Non-Customized "LWRP" renders like this.<br />
The ground is recieved realtime shadow from BG Objcets.

<img src="docs/img/NG_Pattern1.png" width="320px" /> <br />


## RenderPass Flow

1.Generate ShadowMap renders only Character.<br/>
<img src="docs/img/1st_step.png" width="480px" /> <br />

2.Rendering BG Objects with ShadowMap(CharacterOnly)<br />
<img src="docs/img/2nd_step.png" width="480px" /> <br />

3.Rebdering Character to ShadowMap.<br />
<img src="docs/img/3rd_step.png" width="480px" /> <br />

4.Render Character with ShadowMap.<br />
<img src="docs/img/4th_step.png" width="480px" /> <br />


## Why?
 - This makes the rendering shadow cost lower.Because we should only care around the Character.<br/>
 - We can make ShadowMapTexture lower resolution because the shadow distance become shorter.<br/>
 - BG shadows are baked. So its quality is high.

