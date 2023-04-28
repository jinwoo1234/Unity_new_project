Shader "My/StandardSurface/05B_Processing_Texture_LerpAlpha"
{
    Properties
    {
        _MainTex1 ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo with Alpha (RGB)", 2D) = "white" {} // 알파 값이 있는 이미지
        _LerpRange ("Lerp Range", Range(0, 1)) = 0.5
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
            fixed4 d = tex2D (_MainTex2, IN.uv_MainTex2); // 알파 값이 있는 이미지
            o.Albedo = lerp(c.rgb, d.rgb, d.a * _LerpRange); // 알파 값이 있는 이미지를 기준으로 Lerp
            o.Alpha = d.a; // 무관
        }
        ENDCG
    }
    FallBack "Diffuse"
}
