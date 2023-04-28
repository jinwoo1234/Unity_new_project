Shader "My/StandardSurface/22A_MultiplyTextues"
{
    Properties
    {
        _MainTex1 ("Albedo for Still Texture (RGB)", 2D) = "white" {} // Still Texture
        _MainTex2 ("Albedo for Animation (RGB)", 2D) = "white" {} // Texture to Animate
    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade // alpha:fade added

        sampler2D _MainTex1;
        sampler2D _MainTex2;

        struct Input
        {
            float2 uv_MainTex1;
            float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex1, IN.uv_MainTex1);
            fixed4 d = tex2D (_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y));
            o.Albedo = c.rgb * d.rgb;    // Multiply Albedo
            o.Emission = c.rgb * d.rgb;  // Multiply Emissions
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
