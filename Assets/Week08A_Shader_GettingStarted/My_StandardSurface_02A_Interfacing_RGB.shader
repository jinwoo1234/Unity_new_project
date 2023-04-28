Shader "My/StandardSurface/02A_Interfacing_RGB"
{
    Properties
    {
        _Red ("Red", Range(0, 1)) = 1.0
        _Green ("Green", Range(0, 1)) = 0
        _Blue ("Blue", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input
        {
            float2 uv_MainTex;
        };

        float _Red;
        float _Green;
        float _Blue;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = float3(_Red, _Green, _Blue);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
