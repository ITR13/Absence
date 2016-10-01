// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33144,y:32598,varname:node_4795,prsc:2|emission-6859-OUT;n:type:ShaderForge.SFN_ScreenPos,id:8306,x:32046,y:32785,varname:node_8306,prsc:2,sctp:2;n:type:ShaderForge.SFN_Tex2d,id:6116,x:32278,y:32657,ptovrint:False,ptlb:OutlineTex,ptin:_OutlineTex,varname:_node_6116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f15e4995cc92c4ac698b9bcb226b2b78,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector4Property,id:5525,x:32046,y:32957,ptovrint:False,ptlb:PlayerPos,ptin:_PlayerPos,varname:node_5525,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_Distance,id:743,x:32236,y:32924,varname:node_743,prsc:2|A-8306-UVOUT,B-5525-XYZ;n:type:ShaderForge.SFN_ValueProperty,id:5055,x:31911,y:33194,ptovrint:False,ptlb:Radius,ptin:_Radius,varname:node_5055,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_InverseLerp,id:1756,x:32429,y:33345,varname:node_1756,prsc:2|A-8702-OUT,B-6206-OUT,V-743-OUT;n:type:ShaderForge.SFN_Add,id:6206,x:32160,y:33325,varname:node_6206,prsc:2|A-5055-OUT,B-2405-OUT;n:type:ShaderForge.SFN_Subtract,id:1959,x:32160,y:33113,varname:node_1959,prsc:2|A-5055-OUT,B-2405-OUT;n:type:ShaderForge.SFN_Vector1,id:8702,x:32160,y:33265,varname:node_8702,prsc:2,v1:0;n:type:ShaderForge.SFN_InverseLerp,id:3803,x:32429,y:33179,varname:node_3803,prsc:2|A-8702-OUT,B-1959-OUT,V-743-OUT;n:type:ShaderForge.SFN_Floor,id:3190,x:32600,y:33179,varname:node_3190,prsc:2|IN-3803-OUT;n:type:ShaderForge.SFN_Floor,id:4033,x:32620,y:33345,varname:node_4033,prsc:2|IN-1756-OUT;n:type:ShaderForge.SFN_Add,id:9985,x:32958,y:33219,varname:node_9985,prsc:2|A-3634-OUT,B-4285-OUT;n:type:ShaderForge.SFN_Fmod,id:5993,x:32783,y:32997,varname:node_5993,prsc:2|A-9985-OUT,B-1022-OUT;n:type:ShaderForge.SFN_Vector1,id:1022,x:32554,y:33071,varname:node_1022,prsc:2,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:2405,x:31911,y:33282,ptovrint:False,ptlb:Threshold,ptin:_Threshold,varname:node_2405,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Clamp01,id:4285,x:32783,y:33345,varname:node_4285,prsc:2|IN-4033-OUT;n:type:ShaderForge.SFN_Clamp01,id:3634,x:32783,y:33206,varname:node_3634,prsc:2|IN-3190-OUT;n:type:ShaderForge.SFN_Color,id:5938,x:32278,y:32480,ptovrint:False,ptlb:ColorMul,ptin:_ColorMul,varname:node_5938,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9380,x:32507,y:32580,varname:node_9380,prsc:2|A-5938-RGB,B-6116-RGB;n:type:ShaderForge.SFN_Multiply,id:107,x:32701,y:32712,varname:node_107,prsc:2|A-9380-OUT,B-7275-OUT;n:type:ShaderForge.SFN_Round,id:7275,x:32701,y:32854,varname:node_7275,prsc:2|IN-5993-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6571,x:32701,y:32483,ptovrint:False,ptlb:GlowMul,ptin:_GlowMul,varname:node_6571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:6859,x:32935,y:32585,varname:node_6859,prsc:2|A-6571-OUT,B-107-OUT;proporder:6116-5938-6571;pass:END;sub:END;*/

Shader "Shader Forge/OutlineGlow" {
    Properties {
        _OutlineTex ("OutlineTex", 2D) = "white" {}
        _ColorMul ("ColorMul", Color) = (1,0,0,1)
        _GlowMul ("GlowMul", Float ) = 3
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _OutlineTex; uniform float4 _OutlineTex_ST;
            uniform float4 _PlayerPos;
            uniform float _Radius;
            uniform float _Threshold;
            uniform float4 _ColorMul;
            uniform float _GlowMul;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
////// Lighting:
////// Emissive:
                float4 _OutlineTex_var = tex2D(_OutlineTex,TRANSFORM_TEX(i.uv0, _OutlineTex));
                float3 node_9380 = (_ColorMul.rgb*_OutlineTex_var.rgb);
                float node_8702 = 0.0;
                float node_743 = distance(sceneUVs.rg,_PlayerPos.rgb);
                float3 emissive = (_GlowMul*(node_9380*round(fmod((saturate(floor(((node_743-node_8702)/((_Radius-_Threshold)-node_8702))))+saturate(floor(((node_743-node_8702)/((_Radius+_Threshold)-node_8702))))),2.0))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
