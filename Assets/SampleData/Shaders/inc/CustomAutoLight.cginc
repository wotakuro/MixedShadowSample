sampler2D _ScreenSpaceShadowMap;

#define SHADOW_COORDS(idx1) float4 shadowCoord : TEXCOORD##idx1;
#define TRANSFER_SHADOW(a) a.shadowCoord = CustomCalculateScreenPos(a.pos)
#define SHADOW_ATTENUATION(i) tex2D(_ScreenSpaceShadowMap, i.shadowCoord.xy/i.shadowCoord.w).x

inline float4 CustomCalculateScreenPos(float4 pos) {
	float4 o = pos * 0.5f;
	o.xy = float2(o.x, o.y*_ProjectionParams.x) + o.w;
	o.zw = pos.zw;
	return o;
}

