
﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace SolarEngine
{
	[CustomEditor(typeof(SolarEngineSettings))]
	public class SolarEngineSettingsEditor : Editor
	{

        SerializedProperty iOSUrlIdentifier;
        SerializedProperty iOSUrlSchemes;
        SerializedProperty iOSUniversalLinksDomains;

        void OnEnable()
        {
            iOSUrlIdentifier = serializedObject.FindProperty("_iOSUrlIdentifier");
            iOSUrlSchemes = serializedObject.FindProperty("_iOSUrlSchemes");
            iOSUniversalLinksDomains = serializedObject.FindProperty("_iOSUniversalLinksDomains");
        }

        public override void OnInspectorGUI ()
		{
            this.iOSGUI();
        }

        public void iOSGUI()
        {
            GUIStyle darkerCyanTextFieldStyles = new GUIStyle(EditorStyles.boldLabel);
            darkerCyanTextFieldStyles.normal.textColor = new Color(0f / 255f, 190f / 255f, 190f / 255f);

            EditorGUILayout.Space();    
            EditorGUILayout.LabelField("DEEP LINKING:", darkerCyanTextFieldStyles);
            EditorGUI.indentLevel += 1;
            EditorGUILayout.PropertyField(iOSUrlIdentifier,
                new GUIContent("iOS URL Identifier",
                "Value of CFBundleURLName property of the root CFBundleURLTypes element. " +
                "If not needed otherwise, value should be your bundle ID."),
                true);
            EditorGUILayout.PropertyField(iOSUrlSchemes,
                new GUIContent("iOS URL Schemes",
                    "URL schemes handled by your app. " +
                    "Make sure to enter just the scheme name without :// part at the end."),
                true);
            EditorGUILayout.PropertyField(iOSUniversalLinksDomains,
                new GUIContent("iOS Universal Links Domains",
                    "Associated domains handled by your app. State just the domain part without applinks: part in front."),
                true);
          
            EditorGUI.indentLevel -= 1;
            serializedObject.ApplyModifiedProperties();
        }
    }

}
