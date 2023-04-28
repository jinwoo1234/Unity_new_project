Shader "My/StandardSurface/03B_Processing_TextureBW"
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
            fixed4 Albedo = (c.r + c.g + c.b)/3; // BW
            o.Albedo = Albedo;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
