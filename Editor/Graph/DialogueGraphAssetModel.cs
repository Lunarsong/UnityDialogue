using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;

namespace DialogueSystem
{
    class DialogueGraphAssetModel : GraphAssetModel
    {
        [MenuItem("Assets/Create/Game Data/Dialogue")]
        public static void CreateGraph(MenuCommand menuCommand)
        {
            const string path = "Assets";
            var template = new DialogueGraphTemplate(DialogueStencil.k_GraphName);
            CommandDispatcher commandDispatcher = null;
            if (EditorWindow.HasOpenInstances<DialogueGraphWindow>())
            {
                var window = EditorWindow.GetWindow<DialogueGraphWindow>();
                if (window != null)
                {
                    commandDispatcher = window.CommandDispatcher;
                }
            }

            GraphAssetCreationHelpers<DialogueGraphAssetModel>.CreateInProjectWindow(template, commandDispatcher, path);
        }

        [OnOpenAsset(1)]
        public static bool OpenGraphAsset(int instanceId, int line)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceId);
            if (obj is DialogueGraphAssetModel graphAssetModel)
            {
                var window = GraphViewEditorWindow.FindOrCreateGraphWindow<DialogueGraphWindow>();
                window.SetCurrentSelection(graphAssetModel, GraphViewEditorWindow.OpenMode.OpenAndFocus);
                return window != null;
            }

            return false;
        }

        protected override Type GraphModelType => typeof(DialogueGraphModel);
    }
}
