Shader "My2/StandardSurface/1C/Flame"
{
    Properties
    {
        _MainTex1 ("Albedo for Still Texture (RGB)", 2D) = "white" {}
		_MainTex2 ("Noise (RGB)", 2D) = "white" {}
		_MainTex3 ("Albedo for Animation (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        sampler2D _MainTex1;
		sampler2D _MainTex2;	// noise
		sampler2D _MainTex3;	// animation

        struct Input
        {
            float2 uv_MainTex1;
			float2 uv_MainTex2;
			float2 uv_MainTex3;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //fixed4 c = tex2D (_MainTex1, IN.uv_MainTex1);
			//fixed4 d = tex2D (_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y));
			fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y)); // noise
			fixed4 c = tex2D(_MainTex1, IN.uv_MainTex1 + d.r);
			fixed4 e = tex2D(_MainTex3, float2(IN.uv_MainTex3.x, IN.uv_MainTex3.y - _Time.y));

            o.Albedo = c.rgb * e.rgb;
			o.Emission = c.rgb + e.rgb;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
