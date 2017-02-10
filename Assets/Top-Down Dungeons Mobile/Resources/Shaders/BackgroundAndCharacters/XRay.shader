Shader "FixedFunctionShader/XRay" 
{
	// 固定管线Shader编写
	//-------------------------------【属性】-----------------------------------------
	Properties
	{
		_MainTex("贴图", 2D) = "white" {}
		_Color("XRay颜色",Color) = (0.1,0.7,0.3,1)
		_Power("强度", Range(0.1,8.0)) = 1.0
	}

		//--------------------------------【子着色器】----------------------------------
		SubShader
	{
		//-----------子着色器标签----------
		Tags{ "Queue" = "Transparent" }

		//----------------通道1 绘制被遮挡区域--------------
		Pass
		{
			Blend  SrcAlpha   One
			ZTest Greater
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert  
			#pragma fragment frag  
			#include "UnityCG.cginc"  

			float4 _Color;
			float _Power;

			struct appdata_t 
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				float4 color:COLOR;
				float4 normal:NORMAL;
			};

			struct v2f 
			{
				float4  pos : SV_POSITION;
				float4  color:COLOR;
			};
			v2f vert(appdata_t v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
				float rim = 1 - saturate(dot(viewDir, v.normal));
				o.color = _Color*pow(rim, _Power);
				return o;
			}
			float4 frag(v2f i) : COLOR
			{
				return i.color;
			}
				ENDCG
		}

			//----------------通道2 正常绘制未被遮挡区域--------------
				Pass
			{
				ZWrite On
				Lighting Off

				ZTest  Less

				CGPROGRAM
				#pragma vertex vert  
				#pragma fragment frag  
				#include "UnityCG.cginc"  

				sampler2D	_MainTex;
			
				struct appdata_t
			{
				float4 vertex : POSITION;
				float2 tex : TEXCOORD0;
			};

			struct v2f
			{
				float4  pos : SV_POSITION;
				float2 uv:TEXCOORD0;
			};
			v2f vert(appdata_t v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
				o.uv = v.tex;
				return o;
			}
			float4 frag(v2f i) : COLOR
			{
				return tex2D(_MainTex, i.uv);
			}
				ENDCG
			}
	}
	


}