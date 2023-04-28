Shader "My2/StandardSurface/20"
{
    Properties
    {
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

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = 1 - c.rgb;
			//fixed4 Albedo = 1 - (c.r + c.g + c.b) / 3; // grayscale
			//o.Albedo = Albedo;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
