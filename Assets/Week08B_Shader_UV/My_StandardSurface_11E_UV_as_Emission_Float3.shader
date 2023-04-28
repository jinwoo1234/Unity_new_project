Shader "My/StandardSurface/11E_UV_Emission_Float3"
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
            o.Albedo = c.rgb;
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0.5); // U --> Red, V --> Green
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
