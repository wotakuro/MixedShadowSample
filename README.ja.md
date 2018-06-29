# MixedShadowSample
Read this in other languages: [English](README.ja.md), 日本語 <br />


## オリジナルのソースコード
  https://github.com/Unity-Technologies/ScriptableRenderPipeline
  LWRP 1.1.8-previewより派生しました

## イメージ図

![alt text](docs/img/MixShadow.png)

※わかりやすくするため、青い影がリアルタイムで描いているshadowでBakeした影は黒です。

通常のLWRPだとこのように描画されてしまいます。

![alt text](docs/NG_Pattern1.png)



## RenderPassの流れについて

![alt text](docs/1st_step.png)<br/>
始めにキャラクターだけのShadowMapを生成します

![alt text](docs/2nd_step.png)<br/>
キャラクターだけのShadowMapを適応して背景を描きます

![alt text](docs/3rd_step.png)
キャラクターだけのShadowMapに背景オブジェクトも描き足します

![alt text](docs/4th_step.png)
最後にキャラクターを描画します



## これを行う理由について
・キャラクターの周りだけをリアルタイムで処理するようにする事で影の描画負荷を抑えます
・近距離のみで済むのでShadowの解像度を抑えられます
・背景の影はBakeしたものなので高品質です。
