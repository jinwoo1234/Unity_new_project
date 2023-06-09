Shader "My2/StandardSurface/10A_RGBInterfacing"
{
    Properties
    {
        _Red ("Red", Range(0, 1)) = 1.0
		_Green ("Green", Range(0, 1)) = 1.0
		_Blue ("Blue", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }


        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
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
