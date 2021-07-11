using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    class DialogueNodeInspectorFields : FieldsInspector
    {
        DropdownField m_ActorsField;
        Dictionary<string, DialogueActorModel> m_ActorNameToAction;
        public static DialogueNodeInspectorFields Create(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
        {
            if (model is DialogueNodeModel)
            {
                return new DialogueNodeInspectorFields(name, model, ownerElement, parentClassName);
            }
            return null;
        }

        DialogueNodeInspectorFields(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
            : base(name, model, ownerElement, parentClassName) { }

        protected override void BuildPartUI(VisualElement parent)
        {
            base.BuildPartUI(parent);

            List<string> options = new List<string>();
            m_ActorNameToAction = new Dictionary<string, DialogueActorModel>();
            foreach (INodeModel node in m_Model.GraphModel.NodeModels)
            {
                if (node is DialogueActorModel actor)
                {
                    options.Add(actor.Name);
                    m_ActorNameToAction.Add(actor.Name, actor);
                }
            }
            m_ActorsField = new DropdownField("Speaker", options, 0);
            m_ActorsField.RegisterValueChangedCallback(OnSpeakerChanged);
            Root.Add(m_ActorsField);
        }

        private void OnSpeakerChanged(ChangeEvent<string> evt)
        {
            DialogueNodeModel node = m_Model as DialogueNodeModel;
            DialogueActorModel actor = m_ActorNameToAction[evt.newValue];
            node.Speaker = actor;
            var command = new SetModelFieldCommand(actor, node, nameof(DialogueNodeModel.m_Speaker));
            m_OwnerElement.CommandDispatcher.Dispatch(command);
        }

        /// <inheritdoc />
        protected override void UpdatePartFromModel()
        {
            DialogueNodeModel node = m_Model as DialogueNodeModel;
            base.UpdatePartFromModel();
            if (node.Speaker != null)
            {
                m_ActorsField.SetValueWithoutNotify(node.Speaker.Name);
            } else
            {
                m_ActorsField.SetValueWithoutNotify("Undefined");
            }            
        }

        protected override IEnumerable<BaseModelPropertyField> GetFields()
        {
            if (m_Model is DialogueNodeModel dialogueNodeModel)
            {
                yield return new ModelPropertyField<string>(
                    m_OwnerElement.CommandDispatcher,
                    dialogueNodeModel,
                    nameof(DialogueNodeModel.DialogueLine),
                    ObjectNames.NicifyVariableName(nameof(DialogueNodeModel.DialogueLine)),
                    (e, f) =>
                    {
                        var command = new SetModelFieldCommand(e, f.Model, nameof(DialogueNodeModel.m_DialogueLine));
                        f.Dispatcher.Dispatch(command);
                    });
            }
        }
    }
}
