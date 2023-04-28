Shader "My/StandardSurface/31D/PBR_AddOcclusion"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Metallic ("Metalic", Range(0, 1)) = 0
        _Glossiness ("Smoothness", Range(0, 1)) = 0.5
        _NormalMap ("NormalMap", 2D) = "white" {}
        _OcclusionMap ("OcclusionMap", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _Metallic;
        float _Glossiness;
        sampler2D _NormalMap;
        sampler2D _OcclusionMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
            float2 uv_OcclusionMap;
            float3 viewDir;
        };

        // https://docs.unity3d.com/kr/2021.3/Manual/SL-SurfaceShaders.html
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            float3 n = UnpackNormal(tex2D (_NormalMap, IN.uv_NormalMap));
            o.Normal = n;
            o.Occlusion = tex2D (_OcclusionMap, IN.uv_OcclusionMap);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
