Shader "MY/PostEffects/GrayScale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_GrayScaleAmount("GrayScaleAmount", Range(0, 1)) = 1
	}
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			float _GrayScaleAmount;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                
				float grayness = col.r / 3 + col.g / 3 + col.b / 3;
				fixed4 finalColor = lerp(col, grayness, _GrayScaleAmount);
				col.rgb = finalColor;

                return col;
            }
            ENDCG
        }
    }
}
