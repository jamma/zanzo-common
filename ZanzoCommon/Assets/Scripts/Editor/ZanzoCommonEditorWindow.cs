// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoCommonEditorWindow.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:02 on 2023/04/11
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using UnityEngine;
using UnityEditor;

using Zanzo.Common;

namespace Zanzo.Common.Editor
{
    [System.Serializable]
    public class ZanzoCommonPrefs
    {
        public const string PrefsKeyName = "Zanzo.Common.EditorWindowSettingsKey";
        public string enumDefinitions = string.Empty;
        public string enumDomainSource = string.Empty;
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: ZanzoCommonEditorWindow
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ZanzoCommonEditorWindow : EditorWindow
    {
        // Static / Constants  ----------------------------------------------------------------------------------------
        [MenuItem("Tools/Zanzo/Generate Enums", false, 1)]
        public static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(ZanzoCommonEditorWindow), false, "Zanzo Common");
            window.minSize = new Vector2(400, 400);
        }

        // Private Members  -------------------------------------------------------------------------------------------
        private bool _doEnumGeneration = false;
        private ZanzoCommonPrefs _prefs;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public virtual void OnEnable()
        {
            _prefs = LoadPrefs(ZanzoCommonPrefs.PrefsKeyName);
        }

        public virtual void OnDisable()
        {
            SavePrefs(ZanzoCommonPrefs.PrefsKeyName, _prefs);
        }

        protected virtual void ClearPrefs()
        {
            _prefs = new ZanzoCommonPrefs();
        }

        private bool CanGenerateEnums()
        {
            return !(string.IsNullOrEmpty(_prefs.enumDefinitions) || string.IsNullOrEmpty(_prefs.enumDomainSource));
        }

        private void OnGUI()
        {
            _prefs.enumDefinitions = EditorGUILayout.TextField("Enum Definitions", _prefs.enumDefinitions)?.Trim();
            _prefs.enumDomainSource = EditorGUILayout.TextField("Enum Domain Source", _prefs.enumDomainSource)?.Trim();

            var isDisabled = !CanGenerateEnums();
            EditorGUI.BeginDisabledGroup(isDisabled);
            try
            {
                _doEnumGeneration = GUILayout.Button("Generate", GUILayout.Width(100));
            }
            finally
            {
                EditorGUI.EndDisabledGroup();
            }

            if (_doEnumGeneration) GenerateEnumDomain();
        }

        public ZanzoCommonPrefs LoadPrefs(string key)
        {
            try
            {
                var xml = EditorPrefs.GetString(key);
                ZanzoCommonPrefs prefs = null;
                if (!string.IsNullOrEmpty(xml))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ZanzoCommonPrefs));
                    prefs = xmlSerializer.Deserialize(new StringReader(xml)) as ZanzoCommonPrefs;
                }
                return prefs ?? new ZanzoCommonPrefs();
            }
            catch (System.Exception)
            {
                return new ZanzoCommonPrefs();
            }
        }

        public void SavePrefs(string key, ZanzoCommonPrefs prefs)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ZanzoCommonPrefs));
            StringWriter writer = new StringWriter();
            xmlSerializer.Serialize(writer, prefs);
            EditorPrefs.SetString(key, writer.ToString());
        }

        private void GenerateEnumDomain()
        {
            Debug.Log($"Generating enum domain from: {_prefs.enumDefinitions} to src: {_prefs.enumDomainSource}");
        }
    }
}
