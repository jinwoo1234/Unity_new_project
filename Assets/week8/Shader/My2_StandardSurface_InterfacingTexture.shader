Shader "My2/StandardSurface/11A_InterfacingTexture"
{
	Properties
	{
		//_Color ("Color", Color) = (1,1,1,1)
		_Value ("Value", Range(-1, 1)) = 0
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
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

        fixed4 _Color;
		float _Value;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) + _Value;
            o.Albedo = c.rgb;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
