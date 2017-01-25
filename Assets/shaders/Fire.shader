// HOI DEZE SHADER IS VAN MIJ a.k.a Tim Bajmat
// Ik zal nog even kijken naar een 2e displacementmap en scrollrichtingen
// deze zitten er nog niet in maar ik ga wel even kijken

Shader "Custom/Fire" {
	Properties {

		// Je normale texture die op je objecten gaan
		[Header(Main Texture)]
		_MainTex("MainTex", 2D) = "white" {}
		// Albedo kleur die mixt met je shaderkleur
		_Color("Color", Color) = (1,1,1,1)

		[Space(10)] // Niet veel bijzonders
		[Header(Distort Texture)] // Niet veel bijzonders

		//  Je distort texture
		_DistortMap("DistortMap", 2D) = "white" {}
		//  Distort strength
		_Strength("Strength", Range(0,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		// Variabelen >
		sampler2D _MainTex;
		float4 _Color;

		sampler2D _DistortMap;
		float _Strength;
		// < Variabelen 

		struct Input {
			// Maps waarvan je uv's nodig hebt gaan hier
			float2 uv_DistortMap;
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Distort Magic ~~~
			// Simpel gezegd: hij pakt de pixel naast de ander pixel steeds (snapje?)
			// En beweegt deze over time, hierdoor distort het effect
			float2 distuv = float2(IN.uv_DistortMap.x + _Time.x * 2, IN.uv_DistortMap.y + _Time.x * 2);
			float2 disp = tex2D(_DistortMap, distuv).xy;
			disp = ((disp * 2) - 1) * _Strength;

			// Hier return je je main texture + hij voegt op de uv waarde de displacementwaarde toe
			// Ook vermenigvuldigen we de c.rgb en c.a met _Color
			// Hierdoor kan je de maintext wat meer tinten geven
			float4 c = tex2D(_MainTex, IN.uv_MainTex + disp);
			o.Albedo = c.rgb * _Color.rgb;
			o.Alpha = c.a * _Color.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
