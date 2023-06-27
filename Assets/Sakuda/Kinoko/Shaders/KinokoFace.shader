Shader "Unlit/TexAnim1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _IsAnim ("IsAnim", float) = 0
        _NumFrames ("NumFrames", int) = 1
        _AnimSpeed ("AnimSpeed", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            bool _IsAnim;
            int _NumFrames;
            float _AnimSpeed;
 
            struct attributes
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct varyings
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            varyings vert (attributes i)
            {
                varyings o;
                o.vertex = UnityObjectToClipPos(i.vertex);
                o.uv = TRANSFORM_TEX(i.uv, _MainTex);
                return o;
            }

            fixed4 frag (varyings i) : SV_Target
            {
                // フラグが立っていたら、_TimeをもとにUV座標をずらす
                float sca = 1.0 / _NumFrames;
                int idx = floor(frac(_Time.w * _AnimSpeed) / sca);
                i.uv.x = _IsAnim ? (i.uv.x + idx) * sca : i.uv.x * sca;
                i.uv.y = (i.uv.y + 1.0 - _IsAnim) * 0.5;

                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
