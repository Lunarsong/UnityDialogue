using System;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    [Serializable]
    [SearcherItem(typeof(DialogueStencil), SearcherContext.Graph, "Dialogue Node")]
    public class DialogueNodeModel : NodeModel
    {
        [SerializeField]
        internal string m_DialogueLine;
        public string DialogueLine {
            get => m_DialogueLine;
            set => m_DialogueLine = value;
        }

        [SerializeReference]
        internal DialogueActorModel m_Speaker;
        public DialogueActorModel Speaker {
            get => m_Speaker;
            set => m_Speaker = value;
        }

        protected override void OnDefineNode()
        {
            base.OnDefineNode();

            /*for (var i = 0; i < m_InputCount; i++)
                this.AddDataInputPort("In " + (i + 1), TypeHandle.Vector2, options: PortModelOptions.NoEmbeddedConstant);

            for (var i = 0; i < m_OutputCount; i++)
                this.AddDataOutputPort("Out " + (i + 1), TypeHandle.Vector2, options: PortModelOptions.NoEmbeddedConstant);*/

            this.AddExecutionInputPort("In", orientation: PortOrientation.Vertical);
            this.AddExecutionOutputPort("Out", orientation: PortOrientation.Vertical);
        }
    }
}
