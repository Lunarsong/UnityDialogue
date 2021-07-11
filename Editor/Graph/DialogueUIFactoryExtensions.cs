using System;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    [GraphElementsExtensionMethodsCache(typeof(DialogueGraphView))]
    static class DialogueUIFactoryExtensions
    {
        public static IModelUI CreateNode(this ElementBuilder elementBuilder, CommandDispatcher store, DialogueNodeModel model)
        {
            IModelUI ui = new DialogueNode();
            ui.SetupBuildAndUpdate(model, store, elementBuilder.View, elementBuilder.Context);
            return ui;
        }
    }
}
