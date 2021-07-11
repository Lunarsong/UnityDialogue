using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;

namespace DialogueSystem
{
    class DialogueGraphModel : GraphModel
    {
        [SerializeReference]
        public DialogueStartNodeModel StartNode;

        protected override bool IsCompatiblePort(IPortModel startPortModel, IPortModel compatiblePortModel)
        {
            return startPortModel.DataTypeHandle == compatiblePortModel.DataTypeHandle;
        }
    }
}
