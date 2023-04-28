Shader "My/StandardSurface/23A_AddNoiseToTexture"
{
    Properties
    {
        _MainTex1 ("Albedo (RGB)", 2D) = "white" {} // Still Texture
        _MainTex2 ("Noise (RGB)", 2D) = "white" {} // Texture to Animate
        _MainTex3 ("Albedo for Animation (RGB)", 2D) = "white" {} // Texture to Animate        
    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade // alpha:fade added

        sampler2D _MainTex1;
        sampler2D _MainTex2;
        sampler2D _MainTex3;

        struct Input
        {
            float2 uv_MainTex1;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 e = tex2D (_MainTex3, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y)); // Animate Smoke
            fixed4 d = tex2D (_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y)); // Animate Noise
            fixed4 c = tex2D (_MainTex1, IN.uv_MainTex1 + d.r);
            //o.Albedo = e.rgb;
            o.Emission = c.rgb/2 + e.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
