Shader "My2/StandardSurface/2B"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_UVOffsetX ("UV Offset X", Range(-1, 1)) = 0
		_UVOffsetY ("UV Offset Y", Range(-1, 1)) = 0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

		float _UVOffsetX;
		float _UVOffsetY;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //fixed4 c = tex2D (_MainTex, fixed2(IN.uv_MainTex.x + _UVOffsetX ,IN.uv_MainTex.y + _UVOffsetY));
			//fixed4 c = tex2D(_MainTex, fixed2(IN.uv_MainTex.x + _Time.y, IN.uv_MainTex.y + _UVOffsetY)); // _Time.y == 1 , _Time.x == 1/20
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex + _SinTime.w);
            o.Albedo = c.rgb;
			o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
