using System.Collections;
using System.Collections.Generic;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;

namespace DialogueSystem
{
    internal class DialogueGraphTemplate : GraphTemplate<DialogueStencil>
    {
        public DialogueGraphTemplate(string graphName = "Dialogue") : base(graphName)
        {
        }

        public override void InitBasicGraph(IGraphModel graphModelInterface)
        {
            base.InitBasicGraph(graphModelInterface);
            DialogueGraphModel graphModel = graphModelInterface as DialogueGraphModel;
            DialogueStartNodeModel startNode = graphModel.CreateNode<DialogueStartNodeModel>(nodeName: "Start", position: new Vector2(320 * 0.5f, 550 * 0.25f));
            graphModel.StartNode = startNode;
        }
    }
}