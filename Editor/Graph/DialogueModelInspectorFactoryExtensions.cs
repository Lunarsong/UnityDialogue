using System.Collections;
using System.Collections.Generic;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine;

namespace DialogueSystem
{
    [GraphElementsExtensionMethodsCache(typeof(ModelInspectorView))]
    public static class DialogueModelInspectorFactoryExtensions
    {
        public static IModelUI CreateDialogueNodeInspector(this ElementBuilder elementBuilder, CommandDispatcher dispatcher, DialogueNodeModel model)
        {
            //ModelUI ui = UnityEditor.GraphToolsFoundation.Overdrive.ModelInspectorFactoryExtensions.CreateNodeInspector(elementBuilder, dispatcher, model) as ModelUI;

            var ui = new ModelInspector();
            ui.Setup(model, dispatcher, elementBuilder.View as ModelInspectorView, elementBuilder.Context);
            ui.PartList.AppendPart(DialogueNodeInspectorFields.Create("dialogue-node-fields", model, ui, ModelInspector.ussClassName));
            ui.BuildUI();
            ui.UpdateFromModel();

            return ui;
        }

        public static IModelUI CreateDialogueNodeInspector(this ElementBuilder elementBuilder, CommandDispatcher dispatcher, DialogueStartNodeModel model)
        {
            var ui = new ModelInspector();
            ui.Setup(model, dispatcher, elementBuilder.View as ModelInspectorView, elementBuilder.Context);
            ui.BuildUI();
            ui.UpdateFromModel();
            return ui;
        }

        public static IModelUI CreateDialogueNodeInspector(this ElementBuilder elementBuilder, CommandDispatcher dispatcher, DialogueActorModel model)
        {
            var ui = new ModelInspector();
            ui.Setup(model, dispatcher, elementBuilder.View as ModelInspectorView, elementBuilder.Context);
            ui.PartList.AppendPart(ActorNodeInspectorFields.Create("actor-fields", model, ui, ModelInspector.ussClassName));
            ui.BuildUI();
            ui.UpdateFromModel();
            return ui;
        }
    }
}
