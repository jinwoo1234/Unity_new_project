Shader "My/StandardSurface/03C_Processing_TextureNeg"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
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

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 Albedo = 1-(c.r + c.g + c.b)/3; // BW Neg
            o.Albedo = Albedo;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
