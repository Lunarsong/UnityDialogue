using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DialogueSystem
{
    [CustomEditor(typeof(DialogueAsset))]
    public class DialogueInspector : Editor
    {
        DialogueAsset dialogue => target as DialogueAsset;
        bool showActors = true;
        bool showConversation = true;
        GUIStyle richTextStyle;
        public override void OnInspectorGUI()
        {
            if (dialogue == null)
            {
                EditorGUILayout.LabelField("No dialogue to display.");
                return;
            }
            richTextStyle = new GUIStyle(GUI.skin.label);
            richTextStyle.richText = true;

            DisplayActors();            
            EditorGUILayout.Space();
            DisplayConversation();
        }

        private void DisplayConversation()
        {
            showConversation = EditorGUILayout.BeginFoldoutHeaderGroup(showConversation, "Conversation");
            if (!showConversation)
            {
                EditorGUILayout.EndFoldoutHeaderGroup();
                return;
            }
            if (dialogue.Start == null || dialogue.Start.Count == 0)
            {
                EditorGUILayout.HelpBox("Dialogue doesn't have any entries.", MessageType.Warning);
                EditorGUILayout.EndFoldoutHeaderGroup();
                return;
            }
            
            foreach (var startOption in dialogue.Start)
            {
                DisplayNode(startOption);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

        }

        private void DisplayActors()
        {
            showActors = EditorGUILayout.BeginFoldoutHeaderGroup(showActors, "Actors");
            if (!showActors)
            {
                EditorGUILayout.EndFoldoutHeaderGroup();
                return;
            }
            if (dialogue.Actors == null || dialogue.Actors.Count == 0)
            {
                EditorGUILayout.HelpBox("No actors defined in this dialogue.", MessageType.Warning);
                EditorGUILayout.EndFoldoutHeaderGroup();
                return;
            }
            foreach (Actor actor in dialogue.Actors)
            {
                EditorGUILayout.LabelField($"<b>{actor.Name}</b> ({actor.Type})", richTextStyle);

            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        void DisplayNode(Node node)
        {
            EditorGUILayout.LabelField($"<b>{node.Speaker.Name}</b>: {node.Line}", richTextStyle);
            EditorGUI.indentLevel++;
            foreach (Node child in node.Options)
            {
                DisplayNode(child);
            }
            EditorGUI.indentLevel--;
        }
    }
}