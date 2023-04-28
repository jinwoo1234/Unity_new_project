Shader "My/StandardSurface/12A_UV_TexturePos"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _UVOffsetX ("UV Offset", Range(-1, 1)) = 0
        _UVOffsetY ("UV Offset", Range(-1, 1)) = 0
        //_UVOffsetXY ("UV Offset", Range(-1, 1)) = 0
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

        float _UVOffsetX;
        float _UVOffsetY;
        //float _UVOffsetXY;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, fixed2(IN.uv_MainTex.x + _UVOffsetX, IN.uv_MainTex.y + _UVOffsetY));
            //fixed4 c += tex2D (_MainTex, IN.uv_MainTex + _UVOffsetXY);
            o.Albedo = c.rgb;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
