Shader "My/StandardSurface/04A_Processing_Texture_Add"
{
    Properties
    {
        _MainTex1 ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo with Alpha (RGB)", 2D) = "white" {} // 알파 값이 있는 이미지
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex1;
        sampler2D _MainTex2;

        struct Input
        {
            float2 uv_MainTex1;
            float2 uv_MainTex2;
        };

        float _LerpRange;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex1, IN.uv_MainTex1);
            fixed4 d = tex2D (_MainTex2, IN.uv_MainTex2); 
            o.Albedo = c.rgb + d.rgb;
            o.Alpha = d.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
