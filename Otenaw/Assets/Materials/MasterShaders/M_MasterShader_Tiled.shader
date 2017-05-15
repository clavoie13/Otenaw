// Shader created with Shader Forge v1.33 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.33;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32762,y:32662,varname:node_2865,prsc:2|diff-4114-OUT,spec-5693-OUT,gloss-97-OUT,normal-5513-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31729,y:32103,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c9fdd0725a30f0c40b425ee4b1567a3a,ntxv:0,isnm:False|UVIN-6372-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32049,y:33161,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2caac7317f1a1694e95fe73d02d5a72b,ntxv:3,isnm:True|UVIN-6372-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5229,x:30919,y:31950,varname:node_5229,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:310,x:30919,y:32306,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:2136,x:30919,y:32141,ptovrint:False,ptlb:Width,ptin:_Width,varname:_UCoord_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Rotator,id:6372,x:31411,y:32134,varname:node_6372,prsc:2|UVIN-3735-UVOUT,ANG-7764-OUT;n:type:ShaderForge.SFN_UVTile,id:3735,x:31212,y:32134,varname:node_3735,prsc:2|UVIN-5229-UVOUT,WDT-2136-OUT,HGT-9899-OUT,TILE-310-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9899,x:30919,y:32226,ptovrint:False,ptlb:Height,ptin:_Height,varname:node_9899,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:168,x:32049,y:32980,ptovrint:False,ptlb:normal_color,ptin:_normal_color,varname:node_168,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:1,c4:0;n:type:ShaderForge.SFN_Lerp,id:5513,x:32508,y:32979,varname:node_5513,prsc:2|A-168-RGB,B-5964-RGB,T-8324-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8324,x:32304,y:33174,ptovrint:False,ptlb:normal intensity,ptin:_normalintensity,varname:node_8324,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_HsvToRgb,id:9494,x:31939,y:32332,varname:node_9494,prsc:2|H-7017-OUT,S-6692-OUT,V-1372-OUT;n:type:ShaderForge.SFN_Slider,id:7017,x:31538,y:32459,ptovrint:False,ptlb:Hue,ptin:_Hue,varname:node_7017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6692,x:31538,y:32553,ptovrint:False,ptlb:Saturation,ptin:_Saturation,varname:node_6692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1372,x:31538,y:32648,ptovrint:False,ptlb:Value,ptin:_Value,varname:node_1372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:4114,x:32164,y:32238,varname:node_4114,prsc:2|A-4572-OUT,B-9494-OUT;n:type:ShaderForge.SFN_Desaturate,id:4572,x:31949,y:32181,varname:node_4572,prsc:2|COL-7736-RGB,DES-1508-OUT;n:type:ShaderForge.SFN_Slider,id:1508,x:31538,y:32330,ptovrint:False,ptlb:desaturate,ptin:_desaturate,varname:node_1508,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ValueProperty,id:7764,x:31190,y:32329,ptovrint:False,ptlb:Rotation,ptin:_Rotation,varname:node_7764,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ToggleProperty,id:5693,x:32173,y:32529,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_5693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Tex2d,id:5066,x:32116,y:32645,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:node_5066,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:49f4ec82d19d4c34b84d5b2c743e2dc1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5716,x:32346,y:32719,varname:node_5716,prsc:2|A-5066-RGB,B-53-OUT;n:type:ShaderForge.SFN_ValueProperty,id:53,x:32116,y:32830,ptovrint:False,ptlb:Roughness intensity,ptin:_Roughnessintensity,varname:node_53,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:97,x:32508,y:32719,varname:node_97,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5716-OUT;proporder:5964-7736-5066-7764-310-2136-9899-168-8324-1508-7017-6692-1372-5693-53;pass:END;sub:END;*/

Shader "Shader Forge/M_MasterShader_Tiled" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _MainTex ("Base Color", 2D) = "white" {}
        _Roughness ("Roughness", 2D) = "white" {}
        _Rotation ("Rotation", Float ) = 0
        _Tiling ("Tiling", Float ) = 1
        _Width ("Width", Float ) = 1
        _Height ("Height", Float ) = 1
        [HideInInspector]_normal_color ("normal_color", Color) = (0,0,1,0)
        _normalintensity ("normal intensity", Float ) = 0
        _desaturate ("desaturate", Range(0, 1)) = 0
        _Hue ("Hue", Range(0, 1)) = 0
        _Saturation ("Saturation", Range(0, 1)) = 0
        _Value ("Value", Range(0, 1)) = 0
        [MaterialToggle] _Metallic ("Metallic", Float ) = 0
        _Roughnessintensity ("Roughness intensity", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Tiling;
            uniform float _Width;
            uniform float _Height;
            uniform float4 _normal_color;
            uniform float _normalintensity;
            uniform float _Hue;
            uniform float _Saturation;
            uniform float _Value;
            uniform float _desaturate;
            uniform float _Rotation;
            uniform fixed _Metallic;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _Roughnessintensity;
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
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_6372_ang = _Rotation;
                float node_6372_spd = 1.0;
                float node_6372_cos = cos(node_6372_spd*node_6372_ang);
                float node_6372_sin = sin(node_6372_spd*node_6372_ang);
                float2 node_6372_piv = float2(0.5,0.5);
                float2 node_3735_tc_rcp = float2(1.0,1.0)/float2( _Width, _Height );
                float node_3735_ty = floor(_Tiling * node_3735_tc_rcp.x);
                float node_3735_tx = _Tiling - _Width * node_3735_ty;
                float2 node_3735 = (i.uv0 + float2(node_3735_tx, node_3735_ty)) * node_3735_tc_rcp;
                float2 node_6372 = (mul(node_3735-node_6372_piv,float2x2( node_6372_cos, -node_6372_sin, node_6372_sin, node_6372_cos))+node_6372_piv);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_6372, _BumpMap)));
                float3 normalLocal = lerp(_normal_color.rgb,_BumpMap_var.rgb,_normalintensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - (_Roughness_var.rgb*_Roughnessintensity).r; // Convert roughness to gloss
                float perceptualRoughness = (_Roughness_var.rgb*_Roughnessintensity).r;
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
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6372, _MainTex));
                float3 diffuseColor = (lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_Hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_Saturation)*_Value)); // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            Cull Off
            
            
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Tiling;
            uniform float _Width;
            uniform float _Height;
            uniform float4 _normal_color;
            uniform float _normalintensity;
            uniform float _Hue;
            uniform float _Saturation;
            uniform float _Value;
            uniform float _desaturate;
            uniform float _Rotation;
            uniform fixed _Metallic;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _Roughnessintensity;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_6372_ang = _Rotation;
                float node_6372_spd = 1.0;
                float node_6372_cos = cos(node_6372_spd*node_6372_ang);
                float node_6372_sin = sin(node_6372_spd*node_6372_ang);
                float2 node_6372_piv = float2(0.5,0.5);
                float2 node_3735_tc_rcp = float2(1.0,1.0)/float2( _Width, _Height );
                float node_3735_ty = floor(_Tiling * node_3735_tc_rcp.x);
                float node_3735_tx = _Tiling - _Width * node_3735_ty;
                float2 node_3735 = (i.uv0 + float2(node_3735_tx, node_3735_ty)) * node_3735_tc_rcp;
                float2 node_6372 = (mul(node_3735-node_6372_piv,float2x2( node_6372_cos, -node_6372_sin, node_6372_sin, node_6372_cos))+node_6372_piv);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_6372, _BumpMap)));
                float3 normalLocal = lerp(_normal_color.rgb,_BumpMap_var.rgb,_normalintensity);
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
                float gloss = 1.0 - (_Roughness_var.rgb*_Roughnessintensity).r; // Convert roughness to gloss
                float perceptualRoughness = (_Roughness_var.rgb*_Roughnessintensity).r;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6372, _MainTex));
                float3 diffuseColor = (lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_Hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_Saturation)*_Value)); // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Tiling;
            uniform float _Width;
            uniform float _Height;
            uniform float _Hue;
            uniform float _Saturation;
            uniform float _Value;
            uniform float _desaturate;
            uniform float _Rotation;
            uniform fixed _Metallic;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform float _Roughnessintensity;
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
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_6372_ang = _Rotation;
                float node_6372_spd = 1.0;
                float node_6372_cos = cos(node_6372_spd*node_6372_ang);
                float node_6372_sin = sin(node_6372_spd*node_6372_ang);
                float2 node_6372_piv = float2(0.5,0.5);
                float2 node_3735_tc_rcp = float2(1.0,1.0)/float2( _Width, _Height );
                float node_3735_ty = floor(_Tiling * node_3735_tc_rcp.x);
                float node_3735_tx = _Tiling - _Width * node_3735_ty;
                float2 node_3735 = (i.uv0 + float2(node_3735_tx, node_3735_ty)) * node_3735_tc_rcp;
                float2 node_6372 = (mul(node_3735-node_6372_piv,float2x2( node_6372_cos, -node_6372_sin, node_6372_sin, node_6372_cos))+node_6372_piv);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6372, _MainTex));
                float3 diffColor = (lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_desaturate)+(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(_Hue+float3(0.0,-1.0/3.0,1.0/3.0)))-1),_Saturation)*_Value));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float roughness = (_Roughness_var.rgb*_Roughnessintensity).r;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
