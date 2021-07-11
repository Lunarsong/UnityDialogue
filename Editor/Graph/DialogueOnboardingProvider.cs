using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    class DialogueOnboardingProvider : OnboardingProvider
    {
        public override VisualElement CreateOnboardingElements(CommandDispatcher store)
        {
            var template = new DialogueGraphTemplate(DialogueStencil.k_GraphName);
            return AddNewGraphButton<DialogueGraphAssetModel>(template);
        }
    }
}
