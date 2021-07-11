using System;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    [Serializable]
    /*[SearcherItem(typeof(DialogueStencil), SearcherContext.Graph, "Dialogue Node")]*/
    public class DialogueStartNodeModel : NodeModel
    {
        protected override void OnDefineNode()
        {
            this.SetCapability(UnityEditor.GraphToolsFoundation.Overdrive.Capabilities.Deletable, false);
            base.OnDefineNode();
            this.AddExecutionOutputPort("Out", orientation: PortOrientation.Vertical);
        }
    }
}
