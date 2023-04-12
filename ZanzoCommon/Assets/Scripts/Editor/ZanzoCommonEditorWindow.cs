// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoCommonEditorWindow.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:02 on 2023/04/11
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using UnityEngine;
using UnityEditor;

using Zanzo.Common;
using Zanzo.Common.Config;

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
            EnumDefinitions enumDefs = null;
            Debug.Log($"Generating enum domain from: {_prefs.enumDefinitions} to src: {_prefs.enumDomainSource}");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(EnumDefinitions));
                using (FileStream stream = new FileStream(_prefs.enumDefinitions, FileMode.Open))
                {
                    enumDefs = serializer.Deserialize(stream) as EnumDefinitions;
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Exception loading config file: " + e);
            }

            if (enumDefs == null)
            {
                Debug.Log($"Error: Could not parse enums from definition file: {_prefs.enumDefinitions}");
                return;
            }

            var src = new StringBuilder();
            GenerateEnumDomainBegin(src, enumDefs);

            var isFirst = true;
            var sortedEnums = enumDefs.Enum.OrderBy(e => e.Name).ToList();
            foreach (var enm in sortedEnums)
            {
                if (!isFirst) src.Append("\n\n");
                GenerateEnum(src, enm);
                isFirst = false;
                // Debug.Log($"Parsing enum: {enm.Name}");
                // var sortedEntries = enm.Entry.OrderBy(e => e.Name).ToList();
                // foreach (var entry in sortedEntries)
                // {
                //     Debug.Log($"Parsing entry: {enm.Name}.{entry.Name}");
                // }
            }

            GenerateEnumDomainEnd(src, enumDefs);

            var srcFileDir = Path.GetDirectoryName(_prefs.enumDomainSource);
            if (!File.Exists(srcFileDir)) Directory.CreateDirectory(srcFileDir);
            // Directory.CreateDirectory(Path.GetDirectoryName(path));

            File.WriteAllText(_prefs.enumDomainSource, src.ToString());
            // using (FileStream fs = File.Create(_prefs.enumDomainSource))
            // {
            //     // writing data in string
            //     // string dataasstring = "data"; //your data
            //     byte[] info = new UTF8Encoding(true).GetBytes(src.ToString());
            //     fs.Write(info, 0, info.Length);

            //     // writing data in bytes already
            //     byte[] data = new byte[] { 0x0 };
            //     fs.Write(data, 0, data.Length);
            // }

        }

        private void GenerateEnumDomainBegin(StringBuilder src, EnumDefinitions enumDefs)
        {
            if (!string.IsNullOrEmpty(enumDefs.Namespace))
            {
                var namespaceTokens = new List<string>(enumDefs.Namespace.Split("."));
                // namespaceTokens.ForEach(tkn => ConvertSnakeToPascalCase(tkn));
                var formattedNsTokens = namespaceTokens.Select(tkn => ConvertSnakeToPascalCase(tkn)).ToList();
                var formattedNamespace = string.Join(".", formattedNsTokens);
                src.Append(
$@"namespace {formattedNamespace}
{{
");
            }
        }

        private void GenerateEnum(StringBuilder src, Zanzo.Common.Config.Enum enm)
        {
            // // +----------------------------------------------------------------------------
            // // + Enum: ActionButtonState
            // // +----------------------------------------------------------------------------
            // public enum ActionButtonState: int
            // {
            //     Ui,
            //     Gameplay,
            // }

            // public static partial class ActionButtonStateExt
            // {
            //     public static bool IsUi(this ActionButtonState entry)
            //     {
            //         return entry == ActionButtonState.Ui;
            //     }

            //     public static bool IsGameplay(this ActionButtonState entry)
            //     {
            //         return entry == ActionButtonState.Gameplay;
            //     }
            // }
            var formattedEnumName = ConvertSnakeToPascalCase(enm.Name);

            src.Append($"    // + Enum: {formattedEnumName}\n");
            src.Append($"    public enum {formattedEnumName}: int\n");
            src.Append( "    {\n");
// // $@"    // + Enum: {formattedEnumName}
//     public enum {formattedEnumName}: int
//     {{
// ");
            var sortedEntries = enm.Entry.OrderBy(e => e.Name).ToList();
            foreach (var entry in sortedEntries)
            {
                var formattedEntryName = ConvertSnakeToPascalCase(entry.Name);
                src.Append($"        {formattedEntryName},\n");
                // Debug.Log($"Parsing entry: {enm.Name}.{entry.Name}");
            }

            src.Append("    }\n\n");

            var enumExtClassName = $"{formattedEnumName}Ext";
            src.Append($"    public static partial class {enumExtClassName}\n");
            src.Append( "    {\n");


//             src.Append(
// $@"
//         public static partial class {enumExtClassName}
//         {{
// ");
            foreach (var entry in sortedEntries)
            {
                var formattedEntryName = ConvertSnakeToPascalCase(entry.Name);
                src.Append($"        public static bool Is{formattedEntryName}(this {formattedEnumName} entry) => entry == {formattedEnumName}.{formattedEntryName};\n");
//                 src.Append(
// $"        public static bool Is{formattedEntryName}(this {formattedEnumName} entry) => entry == {formattedEnumName}.{formattedEntryName};\n");
                // src.Append($"            {formattedEntryName},\n");
                // Debug.Log($"Parsing entry: {enm.Name}.{entry.Name}");
            }

            src.Append("    }\n");
        }

        private void GenerateEnumDomainEnd(StringBuilder src, EnumDefinitions enumDefs)
        {
            if (!string.IsNullOrEmpty(enumDefs.Namespace))
            {
                src.Append("}");
            }
        }

        private string ConvertSnakeToPascalCase(string str)
        {
            return str.Split(
                new[] { "_" },
                StringSplitOptions.RemoveEmptyEntries)
                    .Select(
                        s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)
                    ).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }
    }
}
