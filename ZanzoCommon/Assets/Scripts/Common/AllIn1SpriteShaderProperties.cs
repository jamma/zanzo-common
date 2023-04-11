// +-------------------------------------------------------------------------------------------------------------------
// + File: AllIn1SpriteShaderProperties.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 15:30 on 2023/03/29
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: AllIn1SpriteShaderProperties
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class AllIn1SpriteShaderProperties : ZanzoObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------

        // General Material Properties
        public const string _MainTex = "_MainTex";
        public const string _MainColor = "_Color";
        public const string _GeneralAlpha = "_Alpha";

        // Color Effects
        public const string _GlowColor = "_GlowColor";
        public const string _Glow = "_Glow";
        public const string _GlowGlobal = "_GlowGlobal";

        public const string _GlowTexUsed = "_GlowTexUsed";
        public const string _GlowTex = "_GlowTex";

        // Private Members  -------------------------------------------------------------------------------------------
        // private Material Material;
        // private bool _isMaterialInstanced;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------
        public Material Material { get; private set; }
        public Texture MainTexture { get => GetMaterialTexture(_MainTex); set => SetMaterialTexture(_MainTex, value); }
        public Color MainColor { get => GetMaterialColor(_MainColor); set => SetMaterialColor(_MainColor, value); }
        public float GeneralAlpha { get => GetMaterialFloat(_GeneralAlpha); set => SetMaterialFloat(_GeneralAlpha, value); }


		// _GlowColor("Glow Color", Color) = (1,1,1,1) //3
		// _Glow("Glow Color Intensity", Range(0,100)) = 10 //4
        // _GlowGlobal("Global Glow Intensity", Range(1,100)) = 1 //5
		// [NoScaleOffset] _GlowTex("Glow Texture", 2D) = "white" {} //6
        // Color Effects
        // public const string GlowColor = "_GlowColor";
        // public const string Glow = "_Glow";
        // public const string GlowGlobal = "_GlowGlobal";
        // public Texture MainTexture { get => GetMaterialTexture(MainTex); set => SetMaterialTexture(MainTex, value); }
        public Color GlowColor { get => GetMaterialColor(_GlowColor); set => SetMaterialColor(_GlowColor, value); }
        public float Glow { get => GetMaterialFloat(_Glow); set => SetMaterialFloat(_Glow, value); }
        public float GlowGlobal { get => GetMaterialFloat(_GlowGlobal); set => SetMaterialFloat(_GlowGlobal, value); }


        // public Texture MainTexture { get => GetMaterialTexture(MainTex); set => SetMaterialTexture(MainTex, value); }
        // public Texture MainTexture { get => GetMaterialTexture(MainTex); set => SetMaterialTexture(MainTex, value); }
        // public Texture MainTexture { get => GetMaterialTexture(MainTex); set => SetMaterialTexture(MainTex, value); }

        // // General Material Properties
        // public const string MainTex = "_MainTex";
        // public const string MainColor = "_Color";
        // public const string GeneralAlpha = "_Alpha";

        // // Color Effects
        // public const string GlowColor = "_GlowColor";
        // public const string Glow = "_Glow";
        // public const string GlowGlobal = "_GlowGlobal";

        // public const string GlowTexUsed = "_GlowTexUsed";
        // public const string GlowTex = "_GlowTex";


        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public override void Initialize()
        {
            Material = GetComponent<Renderer>().material;
        }

        // public void InstanceMaterial()
        // {
        //     // Not entirely sure how to do this yet,
        //     // figure this out when you have to get individual asteroid glow
        //     // stuff working.
        // }

        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public float GetMaterialFloat(string name) => Material.GetFloat(name);
        public void SetMaterialFloat(string name, float value) => Material.SetFloat(name, value);

        public Color GetMaterialColor(string name) => Material.GetColor(name);
        public void SetMaterialColor(string name, Color value) => Material.SetColor(name, value);

        public Texture GetMaterialTexture(string name) => Material.GetTexture(name);
        public void SetMaterialTexture(string name, Texture value) => Material.SetTexture(name, value);

        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        // Order: https://docs.unity3d.com/Manual/ExecutionOrder.html
        // void Awake()
        // {
        // }

        // void OnEnable()
        // {
        // }

        // void OnDisable()
        // {
        // }

        // void Start()
        // {
        //     Initialize();
        // }

        // void Update()
        // {
        // }

        // void FixedUpdate()
        // {
        // }

        // void LateUpdate()
        // {
        // }

        // void OnApplicationQuit()
        // {
        // }

        // void OnDisable()
        // {
        // }
    }
}
