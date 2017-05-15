// Shader created with Shader Forge v1.33 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.33;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-6804-OUT,spec-1681-OUT,gloss-4036-OUT,normal-5106-OUT,alpha-5381-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31629,y:32371,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:73609658903a8a44d903aa165ade8c41,ntxv:0,isnm:False|UVIN-1282-OUT;n:type:ShaderForge.SFN_Tex2d,id:2247,x:32010,y:33206,ptovrint:False,ptlb:node_2247,ptin:_node_2247,varname:node_2247,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fddc60095e824d14d9dfc0849356bbec,ntxv:3,isnm:True|UVIN-1282-OUT;n:type:ShaderForge.SFN_Tex2d,id:2300,x:31545,y:33206,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_2300,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8f4e70dd06f26cc429461f10f3ea0189,ntxv:0,isnm:False|UVIN-6119-UVOUT;n:type:ShaderForge.SFN_Panner,id:6119,x:31372,y:33206,varname:node_6119,prsc:2,spu:0.05,spv:0.01|UVIN-7543-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:931,x:31027,y:33091,varname:node_931,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:3816,x:31419,y:33041,varname:node_3816,prsc:2,uv:1;n:type:ShaderForge.SFN_Lerp,id:1282,x:31803,y:33206,varname:node_1282,prsc:2|A-3816-UVOUT,B-2300-R,T-3928-OUT;n:type:ShaderForge.SFN_Slider,id:3928,x:31448,y:33447,ptovrint:False,ptlb:intensity lerp,ptin:_intensitylerp,varname:node_3928,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02631867,max:1;n:type:ShaderForge.SFN_Color,id:3187,x:32010,y:33036,ptovrint:False,ptlb:normal color,ptin:_normalcolor,varname:node_3187,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:1,c4:0;n:type:ShaderForge.SFN_Lerp,id:5106,x:32332,y:33143,varname:node_5106,prsc:2|A-3187-RGB,B-2247-RGB,T-9711-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9711,x:32146,y:33370,ptovrint:False,ptlb:normal intensity,ptin:_normalintensity,varname:node_9711,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_TexCoord,id:4542,x:31424,y:31908,varname:node_4542,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:1434,x:31697,y:32047,varname:node_1434,prsc:2,spu:0.08,spv:0.01|UVIN-4539-UVOUT;n:type:ShaderForge.SFN_ToggleProperty,id:1681,x:32310,y:32577,ptovrint:False,ptlb:metallic,ptin:_metallic,varname:node_1681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Tex2d,id:1415,x:32009,y:32144,ptovrint:False,ptlb:lignes blanches,ptin:_lignesblanches,varname:node_1415,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8f02fe908314dd84c8d494ecb779e18e,ntxv:0,isnm:False|UVIN-8879-OUT;n:type:ShaderForge.SFN_Blend,id:6804,x:32381,y:32277,varname:node_6804,prsc:2,blmd:6,clmp:True|SRC-8687-OUT,DST-9684-OUT;n:type:ShaderForge.SFN_Add,id:8879,x:31810,y:32198,varname:node_8879,prsc:2|A-1434-UVOUT,B-1282-OUT;n:type:ShaderForge.SFN_UVTile,id:4539,x:31468,y:32161,varname:node_4539,prsc:2|UVIN-4542-UVOUT,WDT-4078-OUT,HGT-6842-OUT,TILE-7424-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4078,x:31138,y:32203,ptovrint:False,ptlb:width-blanc,ptin:_widthblanc,varname:node_4078,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:6842,x:31138,y:32289,ptovrint:False,ptlb:height-blanc,ptin:_heightblanc,varname:node_6842,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:7424,x:31144,y:32408,ptovrint:False,ptlb:tile,ptin:_tile,varname:node_7424,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:5381,x:32320,y:32976,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_5381,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_UVTile,id:7543,x:31214,y:33173,varname:node_7543,prsc:2|UVIN-931-UVOUT,WDT-6730-OUT,HGT-9439-OUT,TILE-904-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6730,x:30917,y:33291,ptovrint:False,ptlb:width_anim,ptin:_width_anim,varname:node_6730,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.05;n:type:ShaderForge.SFN_ValueProperty,id:9439,x:30917,y:33371,ptovrint:False,ptlb:height_anim,ptin:_height_anim,varname:node_9439,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.05;n:type:ShaderForge.SFN_ValueProperty,id:904,x:30917,y:33456,ptovrint:False,ptlb:tile_anim,ptin:_tile_anim,varname:node_904,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Desaturate,id:4424,x:31861,y:32371,varname:node_4424,prsc:2|COL-7736-RGB,DES-7294-OUT;n:type:ShaderForge.SFN_Slider,id:7294,x:31530,y:32572,ptovrint:False,ptlb:desaturate,ptin:_desaturate,varname:node_7294,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_HsvToRgb,id:1295,x:31934,y:32566,varname:node_1295,prsc:2|H-6815-OUT,S-8974-OUT,V-1488-OUT;n:type:ShaderForge.SFN_Slider,id:6815,x:31467,y:32686,ptovrint:False,ptlb:hue,ptin:_hue,varname:node_6815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:8974,x:31467,y:32781,ptovrint:False,ptlb:saturation,ptin:_saturation,varname:node_8974,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1488,x:31467,y:32890,ptovrint:False,ptlb:value,ptin:_value,varname:node_1488,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:9684,x:32096,y:32371,varname:node_9684,prsc:2|A-4424-OUT,B-1295-OUT;n:type:ShaderForge.SFN_Multiply,id:8687,x:32241,y:32097,varname:node_8687,prsc:2|A-5838-OUT,B-1415-RGB;n:type:ShaderForge.SFN_Slider,id:5838,x:31896,y:31945,ptovrint:False,ptlb:opacity white stripes,ptin:_opacitywhitestripes,varname:node_5838,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2451631,max:1;n:type:ShaderForge.SFN_Tex2d,id:1141,x:32143,y:32689,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:node_1141,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3192416866185f74f8ab37cbfe8d423d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3199,x:32371,y:32757,varname:node_3199,prsc:2|A-1141-R,B-1835-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4036,x:32534,y:32757,varname:node_4036,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3199-OUT;n:type:ShaderForge.SFN_Slider,id:1835,x:32022,y:32902,ptovrint:False,ptlb:roughness intensity,ptin:_roughnessintensity,varname:node_1835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4102564,max:2;proporder:7736-2247-2300-3928-3187-9711-1681-1415-4078-6842-7424-5381-6730-9439-904-7294-6815-8974-1488-5838-1141-1835;pass:END;sub:END;*/

Shader "Shader Forge/MS_Water" {
    Properties {
        _MainTex ("Base Color", 2D) = "white" {}
        _node_2247 ("node_2247", 2D) = "bump" {}
        [HideInInspector]_noise ("noise", 2D) = "white" {}
        _intensitylerp ("intensity lerp", Range(0, 1)) = 0.02631867
        [HideInInspector]_normalcolor ("normal color", Color) = (0,0,1,0)
        _normalintensity ("normal intensity", Float ) = 3
        [MaterialToggle] _metallic ("metallic", Float ) = 0
        _lignesblanches ("lignes blanches", 2D) = "white" {}
        _widthblanc ("width-blanc", Float ) = 0.5
        _heightblanc ("height-blanc", Float ) = 3
        [HideInInspector]_tile ("tile", Float ) = 1
        _opacity ("opacity", Float ) = 0.8
        _width_anim ("width_anim", Float ) = 0.05
        _height_anim ("height_anim", Float ) = 0.05
        [HideInInspector]_tile_anim ("tile_anim", Float ) = 1
        _desaturate ("desaturate", Range(0, 1)) = 0
        _hue ("hue", Range(-1, 1)) = 0
        _saturation ("saturation", Range(0, 1)) = 0
        _value ("value", Range(-1, 1)) = 0
        _opacitywhitestripes ("opacity white stripes", Range(0, 1)) = 0.2451631
        _Roughness ("Roughness", 2D) = "white" {}
        _roughnessintensity ("roughness intensity", Range(0, 2)) = 0.4102564
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _node_2247; uniform float4 _node_2247_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _intensitylerp;
            uniform float4 _normalcolor;
            uniform float _normalintensity;
            uniform fixed _metallic;
            uniform sampler2D _lignesblanches; uniform float4 _lignesblanches_ST;
            uniform float _widthblanc;
            uniform float _heightblanc;
            uniform float _tile;
            uniform float _opacity;
            uniform float _width_anim;
            uniform float _height_anim;
            uniform float _tile_anim;
            uniform float _desaturate;
            uniform float _hue;
            uniform float _saturation;
            uniform float _value;
            uniform float _opacitywhitestripes;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _roughnessintensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                UNITY_FOG_COORDS(7)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_4274 = _Time + _TimeEditor;
                float2 node_7543_tc_rcp = float2(1.0,1.0)/float2( _width_anim, _height_anim );
                float node_7543_ty = floor(_tile_anim * node_7543_tc_rcp.x);
                float node_7543_tx = _tile_anim - _width_anim * node_7543_ty;
                float2 node_7543 = (i.uv0 + float2(node_7543_tx, node_7543_ty)) * node_7543_tc_rcp;
                float2 node_6119 = (node_7543+node_4274.g*float2(0.05,0.01));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_6119, _noise));
                float2 node_1282 = lerp(i.uv1,float2(_noise_var.r,_noise_var.r),_intensitylerp);
                float3 _node_2247_var = UnpackNormal(tex2D(_node_2247,TRANSFORM_TEX(node_1282, _node_2247)));
                float3 normalLocal = lerp(_normalcolor.rgb,_node_2247_var.rgb,_normalintensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - (_Roughness_var.r*_roughnessintensity).r; // Convert roughness to gloss
                float perceptualRoughness = (_Roughness_var.r*_roughnessintensity).r;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _metallic;
                float specularMonochrome;
                float2 node_4539_tc_rcp = float2(1.0,1.0)/float2( _widthblanc, _heightblanc );
                float node_4539_ty = floor(_tile * node_4539_tc_rcp.x);
                float node_4539_tx = _tile - _widthblanc * node_4539_ty;
                float2 node_4539 = (i.uv0 + float2(node_4539_tx, node_4539_ty)) * node_4539_tc_rcp;
                float2 node_8879 = ((node_4539+node_4274.g*float2(0.08,0.01))+node_1282);
                float4 _lignesblanches_var = tex2D(_lignesblanches,TRANSFORM_TEX(node_8879, _lignesblanches));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1282, _MainTex));
                float3 diffuseColor = saturate((1.0-(1.0-(_opacitywhitestripes*_lignesblanches_var.rgb))*(1.0-(lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*_value))))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz)*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,_opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _node_2247; uniform float4 _node_2247_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _intensitylerp;
            uniform float4 _normalcolor;
            uniform float _normalintensity;
            uniform fixed _metallic;
            uniform sampler2D _lignesblanches; uniform float4 _lignesblanches_ST;
            uniform float _widthblanc;
            uniform float _heightblanc;
            uniform float _tile;
            uniform float _opacity;
            uniform float _width_anim;
            uniform float _height_anim;
            uniform float _tile_anim;
            uniform float _desaturate;
            uniform float _hue;
            uniform float _saturation;
            uniform float _value;
            uniform float _opacitywhitestripes;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _roughnessintensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_2249 = _Time + _TimeEditor;
                float2 node_7543_tc_rcp = float2(1.0,1.0)/float2( _width_anim, _height_anim );
                float node_7543_ty = floor(_tile_anim * node_7543_tc_rcp.x);
                float node_7543_tx = _tile_anim - _width_anim * node_7543_ty;
                float2 node_7543 = (i.uv0 + float2(node_7543_tx, node_7543_ty)) * node_7543_tc_rcp;
                float2 node_6119 = (node_7543+node_2249.g*float2(0.05,0.01));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_6119, _noise));
                float2 node_1282 = lerp(i.uv1,float2(_noise_var.r,_noise_var.r),_intensitylerp);
                float3 _node_2247_var = UnpackNormal(tex2D(_node_2247,TRANSFORM_TEX(node_1282, _node_2247)));
                float3 normalLocal = lerp(_normalcolor.rgb,_node_2247_var.rgb,_normalintensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - (_Roughness_var.r*_roughnessintensity).r; // Convert roughness to gloss
                float perceptualRoughness = (_Roughness_var.r*_roughnessintensity).r;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _metallic;
                float specularMonochrome;
                float2 node_4539_tc_rcp = float2(1.0,1.0)/float2( _widthblanc, _heightblanc );
                float node_4539_ty = floor(_tile * node_4539_tc_rcp.x);
                float node_4539_tx = _tile - _widthblanc * node_4539_ty;
                float2 node_4539 = (i.uv0 + float2(node_4539_tx, node_4539_ty)) * node_4539_tc_rcp;
                float2 node_8879 = ((node_4539+node_2249.g*float2(0.08,0.01))+node_1282);
                float4 _lignesblanches_var = tex2D(_lignesblanches,TRANSFORM_TEX(node_8879, _lignesblanches));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1282, _MainTex));
                float3 diffuseColor = saturate((1.0-(1.0-(_opacitywhitestripes*_lignesblanches_var.rgb))*(1.0-(lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*_value))))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * _opacity,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _intensitylerp;
            uniform fixed _metallic;
            uniform sampler2D _lignesblanches; uniform float4 _lignesblanches_ST;
            uniform float _widthblanc;
            uniform float _heightblanc;
            uniform float _tile;
            uniform float _width_anim;
            uniform float _height_anim;
            uniform float _tile_anim;
            uniform float _desaturate;
            uniform float _hue;
            uniform float _saturation;
            uniform float _value;
            uniform float _opacitywhitestripes;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _roughnessintensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 node_9096 = _Time + _TimeEditor;
                float2 node_4539_tc_rcp = float2(1.0,1.0)/float2( _widthblanc, _heightblanc );
                float node_4539_ty = floor(_tile * node_4539_tc_rcp.x);
                float node_4539_tx = _tile - _widthblanc * node_4539_ty;
                float2 node_4539 = (i.uv0 + float2(node_4539_tx, node_4539_ty)) * node_4539_tc_rcp;
                float2 node_7543_tc_rcp = float2(1.0,1.0)/float2( _width_anim, _height_anim );
                float node_7543_ty = floor(_tile_anim * node_7543_tc_rcp.x);
                float node_7543_tx = _tile_anim - _width_anim * node_7543_ty;
                float2 node_7543 = (i.uv0 + float2(node_7543_tx, node_7543_ty)) * node_7543_tc_rcp;
                float2 node_6119 = (node_7543+node_9096.g*float2(0.05,0.01));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_6119, _noise));
                float2 node_1282 = lerp(i.uv1,float2(_noise_var.r,_noise_var.r),_intensitylerp);
                float2 node_8879 = ((node_4539+node_9096.g*float2(0.08,0.01))+node_1282);
                float4 _lignesblanches_var = tex2D(_lignesblanches,TRANSFORM_TEX(node_8879, _lignesblanches));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1282, _MainTex));
                float3 diffColor = saturate((1.0-(1.0-(_opacitywhitestripes*_lignesblanches_var.rgb))*(1.0-(lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_saturation)*_value)))));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _metallic, specColor, specularMonochrome );
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float roughness = (_Roughness_var.r*_roughnessintensity).r;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
