// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoCommonEditorWindow.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:02 on 2023/04/11
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;
using UnityEditor;

using Zanzo.Common;

namespace Zanzo.Common.Editor
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: ZanzoCommonEditorWindow
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ZanzoCommonEditorWindow : EditorWindow
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;
        // // [MenuItem("Tools/Zanzo/Generate Enums", false -1)]
        // public static void GenerateEnums()
        // {
        // }
        [MenuItem("Tools/Zanzo/Generate Enums", false, 1)]
        public static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(ZanzoCommonEditorWindow), false, "Zanzo Common");
            window.minSize = new Vector2(400, 400);
        }

        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;
        // [Serializable]
        private string _enumDomainFile;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------
        // public bool SomeProperty
        // {
        //     get
        //     {
        //         return _somePrivateMember;
        //     }
        //     set
        //     {
        //         _somePrivateMember = value;
        //     }
        // }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }

        private void OnEnable()
        {
            // GetWindow(typeof(EnumGenWin));
        }

        private void OnGUI()
        {
            // GUILayout.Space(20);
            // prefs.playerName = EditorGUILayout.TextField(PlayerNameLabel, prefs.playerName)?.Trim();
            _enumDomainFile = EditorGUILayout.TextField("Enum Domain File", _enumDomainFile)?.Trim();
            GUILayout.Button("Generate", GUILayout.Width(100));

            // var isReady = IsReadyToConvert();
            // EditorGUI.BeginDisabledGroup(!isReady);
            // try
            // {
            //     convertNow = GUILayout.Button("Import", GUILayout.Width(100));
            // }
            // finally
            // {
            //     EditorGUI.EndDisabledGroup();
            // }
        }

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
