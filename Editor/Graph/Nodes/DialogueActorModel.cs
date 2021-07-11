using System;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    [Serializable]
    [SearcherItem(typeof(DialogueStencil), SearcherContext.Graph, "Actor")]
    public class DialogueActorModel : NodeModel, IRenamable
    {
        [SerializeField]
        internal string m_Name = "New Actor";
        public string Name {
            get => m_Name;
            set => m_Name = value;
        }

        public override string Title { get => Name; set => Name = value; }

        [SerializeField]
        internal ActorTypes m_ActorType = ActorTypes.NPC;
        public ActorTypes ActorType { get => m_ActorType; set => m_ActorType = value; }
        protected override void OnDefineNode()
        {
            base.OnDefineNode();
            this.SetCapability(UnityEditor.GraphToolsFoundation.Overdrive.Capabilities.Renamable, true);
        }
        public void Rename(string name)
        {
            Name = name;
        }
    }
}
