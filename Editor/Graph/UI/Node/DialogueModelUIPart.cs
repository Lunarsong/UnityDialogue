using System.Collections.Generic;
using UnityEditor;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    public class DialogueModelUIPart : BaseModelUIPart
    {
        VisualElement m_Root;
        List<BaseModelPropertyField> m_Fields;

        public static readonly string ussClassName = "dialogue-inspector-fields";

        /// <inheritdoc />
        public override VisualElement Root => m_Root;
        //ModelPropertyField<string> m_DialogueStringField;
        EditableLabel m_DialogueStringField;
        public static DialogueModelUIPart Create(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
        {
            if (model is INodeModel)
            {
                return new DialogueModelUIPart(name, model, ownerElement, parentClassName);
            }

            return null;
        }
        protected DialogueModelUIPart(string name, IGraphElementModel model, IModelUI ownerElement, string parentClassName)
            : base(name, model, ownerElement, parentClassName) { }

        protected override void BuildPartUI(VisualElement parent)
        {
            DialogueNodeModel dialogueNode = m_Model as DialogueNodeModel;
            m_Root = new VisualElement { name = PartName };
            m_Root.AddToClassList(ussClassName);
            m_Root.AddToClassList(m_ParentClassName.WithUssElement(PartName));

            //m_DialogueStringField = new ModelPropertyField<string>(m_OwnerElement.CommandDispatcher, m_Model, "", null);
            //m_Root.Add(m_DialogueStringField);

            m_DialogueStringField = new EditableLabel();
            m_DialogueStringField.multiline = true;
            m_DialogueStringField.SetValueWithoutNotify(dialogueNode.DialogueLine);
            m_DialogueStringField.RegisterCallback<ChangeEvent<string>>(OnEditDialogue);
            Root.Add(m_DialogueStringField);

            parent.Add(m_Root);
        }

        private void OnEditDialogue(ChangeEvent<string> evt)
        {
            var command = new SetModelFieldCommand(evt.newValue, m_Model, nameof(DialogueNodeModel.m_DialogueLine));
            m_OwnerElement.CommandDispatcher.Dispatch(command);
        }

        protected override void UpdatePartFromModel()
        {
            DialogueNodeModel dialogueNode = m_Model as DialogueNodeModel;
            m_DialogueStringField.SetValueWithoutNotify(dialogueNode.DialogueLine);
        }

        protected override void PostBuildPartUI()
        {
            base.PostBuildPartUI();

            var stylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dialogue/Editor/UI/Node/DialogueNodePart.uss");
            if (stylesheet != null)
            {
                Root.styleSheets.Add(stylesheet);
            }
        }
    }
}
