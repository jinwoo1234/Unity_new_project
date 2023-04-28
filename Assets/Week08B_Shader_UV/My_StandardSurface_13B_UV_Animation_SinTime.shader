Shader "My/StandardSurface/13B_UV_Animation_Time"
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

        // https://docs.unity3d.com/kr/current/Manual/SL-UnityShaderVariables.html
        /*******************************************
        _Time.x == 1/20, _Time.y == 1, _Time.z == 2, _Time.w == 3 
        _SinTime.x == t/8, _SinTime.y == t/4, _SinTime.z == t/2, _SinTime.w == t
        _CosTime.x == t/8, _CosTime.y == t/4, _CosTime.z == t/2, _CosTime.w == t
        unity_DeltaTime.x == dt, unity_DeltaTime.y == 1/dt, unity_DeltaTime.z == smoothDt, unity_DeltaTime.w == 1/smoothDt 
        *******************************************/
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + _SinTime.w); 
            o.Albedo = c.rgb;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
