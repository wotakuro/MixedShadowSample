Shader "App/ShadowTestShader"
{

	Properties
	{
		[NoScaleOffset] _MainTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Pass
		{
			Tags{ "LightMode" = "LightweightForward" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "inc/CustomAutoLight.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 shadowCoord : TEXCOORD1;
				float4 pos : SV_POSITION;
			};

			inline float4 CalculateScreenPos(float4 pos) {
				float4 o = pos * 0.5f;
				o.xy = float2(o.x, o.y*_ProjectionParams.x) + o.w;
				o.zw = pos.zw;
				return o;
			}
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				// compute shadows data
				TRANSFER_SHADOW(o);
				return o;
			}

			sampler2D _MainTex;
            half4 _RealTimeShadowColor;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed shadow = SHADOW_ATTENUATION(i);
                shadow = clamp(shadow + 0.5, 0.0,1.0);

				col.rgb = col.rgb * shadow + _RealTimeShadowColor * (1.0 - shadow);
				return col;
			}
			ENDCG
		}

		Pass{
				Tags{ "LightMode" = "DepthOnly" }
				ZWrite On
				ColorMask 0
				Cull[_Cull]

				CGPROGRAM
				#pragma vertex depthVert
				#pragma fragment depthFrag
				#include "UnityCG.cginc"
				struct v2f
				{
					float4 pos : SV_POSITION;
				};

				v2f depthVert(appdata_base v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}
				fixed4 depthFrag(v2f i) : SV_Target
				{
					return 0;
				}
				ENDCG
		}
				
        Pass
        {
            Tags{"LightMode" = "ShadowCaster"}

            ZWrite On
            ZTest LEqual
            Cull[_Cull]

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0

            // -------------------------------------
            // Material Keywords
            #pragma shader_feature _ALPHATEST_ON

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
            #include "LWRP/ShaderLibrary/LightweightPassShadow.hlsl"
            ENDHLSL
        }
	}
}
