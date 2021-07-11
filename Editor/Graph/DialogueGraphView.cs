using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine;

namespace DialogueSystem
{
    class DialogueGraphView : GraphView
    {
        public DialogueGraphView(GraphViewEditorWindow window, CommandDispatcher commandDispatcher, string graphViewName)
            : base(window, commandDispatcher, graphViewName)
        {
            SetupZoom(0.05f, 5.0f, 5.0f);
        }
    }
}
