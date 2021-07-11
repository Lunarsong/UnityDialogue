using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    class ActorNodeInspectorFields : FieldsInspector
    {
        public static ActorNodeInspectorFields Create(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
        {
            if (model is DialogueActorModel)
            {
                return new ActorNodeInspectorFields(name, model, ownerElement, parentClassName);
            }
            return null;
        }

        ActorNodeInspectorFields(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
            : base(name, model, ownerElement, parentClassName) { }

        protected override IEnumerable<BaseModelPropertyField> GetFields()
        {
            if (m_Model is DialogueActorModel actor)
            {
                yield return new ModelPropertyField<string>(
                    m_OwnerElement.CommandDispatcher,
                    actor,
                    nameof(DialogueActorModel.Name),
                    ObjectNames.NicifyVariableName(nameof(DialogueActorModel.Name)),
                    (e, f) =>
                    {
                        var command = new SetModelFieldCommand(e, f.Model, nameof(DialogueActorModel.m_Name));
                        f.Dispatcher.Dispatch(command);
                    });

                yield return new ModelPropertyField<ActorTypes>(
                    m_OwnerElement.CommandDispatcher,
                    actor,
                    nameof(DialogueActorModel.ActorType),
                    ObjectNames.NicifyVariableName(nameof(DialogueActorModel.ActorType)),
                    (e, f) =>
                    {
                        var command = new SetModelFieldCommand(e, f.Model, nameof(DialogueActorModel.m_ActorType));
                        f.Dispatcher.Dispatch(command);
                    });
            }
        }
    }
}
