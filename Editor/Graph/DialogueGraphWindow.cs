using System.Collections.Generic;
using UnityEditor;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine;

namespace DialogueSystem
{
    class DialogueGraphWindow : GraphViewEditorWindow
    {
        [InitializeOnLoadMethod]
        static void RegisterTool()
        {
            ShortcutHelper.RegisterDefaultShortcuts<DialogueGraphWindow>(DialogueStencil.toolName);
        }

        [MenuItem("Game/Dialogue", false)]
        public static void ShowRecipeGraphWindow()
        {
            FindOrCreateGraphWindow<DialogueGraphWindow>();
        }

        protected override void OnEnable()
        {
            EditorToolName = "Dialogue";
            base.OnEnable();
        }

        protected override GraphView CreateGraphView()
        {
            return new DialogueGraphView(this, CommandDispatcher, EditorToolName);
        }

        protected override BlankPage CreateBlankPage()
        {
            var onboardingProviders = new List<OnboardingProvider> { new DialogueOnboardingProvider() };

            return new BlankPage(CommandDispatcher, onboardingProviders);
        }

        /// <inheritdoc />
        protected override bool CanHandleAssetType(IGraphAssetModel asset)
        {
            return asset is DialogueGraphAssetModel;
        }

        /// <inheritdoc />
        protected override GraphToolState CreateInitialState()
        {
            var prefs = Preferences.CreatePreferences(EditorToolName);
            return new DialogueGraphState(GUID, prefs);
        }
    }
}
