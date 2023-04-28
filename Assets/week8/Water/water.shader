Shader "My3/water"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		sampler2D _MainTex;

		struct Input
		{
			float2 uv_MainTex;
		};

		fixed4 _Color;
		void surf(Input IN, inout SurfaceOutputStandard o)
		{

			fixed4 c = tex2D(_MainTex, float2(IN.uv_MainTex.x + _SinTime.w, IN.uv_MainTex.y - _Time.x)) * _Color; // y 축으로 이동
			o.Albedo = c.rgb;
			o.Emission = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
