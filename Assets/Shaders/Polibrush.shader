// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Polibrush"
{
	Properties
	{
		_tierraTextura("tierra Textura", 2D) = "white" {}
		_texturaPasto("textura Pasto", 2D) = "white" {}
		_escala("escala", Float) = 160
		_normaltierra("normal tierra", 2D) = "bump" {}
		_normalPasto("normal Pasto", 2D) = "bump" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform sampler2D _normaltierra;
		uniform float _escala;
		uniform sampler2D _normalPasto;
		uniform sampler2D _tierraTextura;
		uniform sampler2D _texturaPasto;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_cast_0 = (_escala).xx;
			float2 uv_TexCoord48 = i.uv_texcoord * temp_cast_0;
			float4 lerpResult42 = lerp( tex2D( _tierraTextura, uv_TexCoord48 ) , tex2D( _texturaPasto, uv_TexCoord48 ) , i.vertexColor);
			float3 lerpResult52 = lerp( UnpackNormal( tex2D( _normaltierra, uv_TexCoord48 ) ) , UnpackNormal( tex2D( _normalPasto, uv_TexCoord48 ) ) , lerpResult42.rgb);
			o.Normal = lerpResult52;
			o.Albedo = lerpResult42.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
180;73;1103;678;404.6657;355.4425;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;49;180.8943,-107.815;Inherit;False;Property;_escala;escala;8;0;Create;True;0;0;0;False;0;False;160;160;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;41;546.0026,-67.67226;Inherit;True;Property;_texturaPasto;textura Pasto;7;0;Create;True;0;0;0;False;0;False;None;46c9b2c471a59f24cbe88eae93a32f60;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode;40;535.5474,-290.343;Inherit;True;Property;_tierraTextura;tierra Textura;6;0;Create;True;0;0;0;False;0;False;None;3f24b311153434aed806d09b6893d22f;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TextureCoordinatesNode;48;323.556,-129.5495;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;45;931.032,108.6697;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;46;795.9669,-75.72416;Inherit;True;Property;_TextureSample0;Texture Sample 0;8;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;47;789.9669,-289.7242;Inherit;True;Property;_TextureSample1;Texture Sample 1;9;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;51;549.9672,335.1487;Inherit;True;Property;_normalPasto;normal Pasto;10;0;Create;True;0;0;0;False;0;False;-1;None;ae0e7acc3616ba441a70994eb662f6e3;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;50;547.0549,128.6112;Inherit;True;Property;_normaltierra;normal tierra;9;0;Create;True;0;0;0;False;0;False;-1;None;7bd42aa6a5eb44497a785c4c020d77ec;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;18;-694.3001,-274.4005;Inherit;False;654.6006;551.7;Comment;6;13;16;14;17;15;12;;0.0967871,0.8207547,0.8207547,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;37;-712.3245,336.1205;Inherit;False;720.5718;374.7415;Comment;3;36;34;33;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;35;-733.5608,-637.4383;Inherit;False;739.3585;342.1595;Comment;4;31;30;28;29;;1,1,1,1;0;0
Node;AmplifyShaderEditor.LerpOp;42;1170.455,-95.95937;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;31;-192.2029,-587.438;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;28;-683.5609,-550.2999;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TriplanarNode;33;-400.7519,469.0982;Inherit;True;Spherical;World;False;Top Texture 0;_TopTexture0;white;-1;None;Mid Texture 0;_MidTexture0;white;-1;None;Bot Texture 0;_BotTexture0;white;-1;None;Triplanar Sampler;Tangent;10;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;9;FLOAT3;0,0,0;False;8;FLOAT;1;False;3;FLOAT2;1,1;False;4;FLOAT;1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;12;-221.6996,-154.2003;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-638.1625,-411.2784;Inherit;False;Property;_Float1;Float 1;3;0;Create;True;0;0;0;False;0;False;0.25;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-398.7039,-584.7268;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;52;1029.45,311.9756;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;14;-639.7001,-48.1002;Inherit;False;Property;_Color1;Color 1;0;0;Create;True;0;0;0;False;0;False;0,0,0,0;0.3965379,0.6320754,0.5929756,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-637.9995,161.2995;Inherit;False;Property;_Float0;Float 0;2;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;17;-416.6006,-47.35868;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;34;-662.3245,386.1205;Inherit;True;Property;_Texture0;Texture 0;4;0;Create;True;0;0;0;False;0;False;None;3f24b311153434aed806d09b6893d22f;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;36;-608.2008,594.8623;Inherit;False;Property;_Float3;Float 3;5;0;Create;True;0;0;0;False;0;False;6.2;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;13;-644.3001,-224.4005;Inherit;False;Property;_Color0;Color 0;1;0;Create;True;0;0;0;False;0;False;0,0,0,0;0.5,0.3406134,0.2004717,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;16;-412.6999,-217.6587;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1518.086,-249.5751;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Polibrush;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;48;0;49;0
WireConnection;46;0;41;0
WireConnection;46;1;48;0
WireConnection;47;0;40;0
WireConnection;47;1;48;0
WireConnection;51;1;48;0
WireConnection;50;1;48;0
WireConnection;42;0;47;0
WireConnection;42;1;46;0
WireConnection;42;2;45;0
WireConnection;31;0;29;0
WireConnection;33;0;34;0
WireConnection;33;3;36;0
WireConnection;12;0;16;0
WireConnection;12;1;17;0
WireConnection;12;2;15;0
WireConnection;29;0;28;1
WireConnection;29;1;30;0
WireConnection;52;0;50;0
WireConnection;52;1;51;0
WireConnection;52;2;42;0
WireConnection;17;0;14;0
WireConnection;16;0;13;0
WireConnection;0;0;42;0
WireConnection;0;1;52;0
ASEEND*/
//CHKSM=F3A00B2242EEF5B165506A39EF86C7E2324AE5C0