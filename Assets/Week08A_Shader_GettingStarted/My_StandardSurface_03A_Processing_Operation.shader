Shader "My/StandardSurface/03A_Processing_Operation"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Value ("Value", Range(-1, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed _Value;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb + _Value;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
