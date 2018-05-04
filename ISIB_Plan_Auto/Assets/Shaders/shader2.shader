Shader "Custom/shader2" {
	Properties{
		_Background("Background", Color) = (1,1,1,1)
		_Color1("Color1", Color) = (1,1,1,1)
		_Color2("Color2", Color) = (1,1,1,1)
		_Color3("Color3", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BisTex("Second", 2D) = "white" {}
		_TrisTex("Third", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Percentage1("Poucentage1", Range(0,1)) = 0.0
		_Percentage2("Poucentage2", Range(0,1)) = 0.0
		_Percentage3("Poucentage3", Range(0,1)) = 0.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BisTex;
			sampler2D _TrisTex;

			struct Input {
				float2 uv_MainTex;
				float2 uv_BisTex;
				float2 uv_TrisTex;
			};
			half _Percentage1;
			half _Percentage2;
			half _Percentage3;
			half _Glossiness;
			half _Metallic;
			fixed4 _Background;
			fixed4 _Color1;
			fixed4 _Color2;
			fixed4 _Color3;

			void surf(Input IN, inout SurfaceOutputStandard o) {
				// Albedo comes from a texture tinted by color
				fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex);
				fixed4 c2 = tex2D(_BisTex, IN.uv_BisTex);
				fixed4 c3 = tex2D(_TrisTex, IN.uv_TrisTex);
				o.Albedo = _Background-((fixed3(1, 1, 1) - c1.rgb) * c1.a * _Percentage1 * _Color1 + (fixed3(1, 1, 1) - c2.rgb)* c2.a *_Percentage2 * _Color2 + (fixed3(1, 1, 1) - c3.rgb) * c3.a * _Percentage3 * _Color3);
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c1.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
