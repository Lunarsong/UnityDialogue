using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    class DialogueStencil : Stencil
    {
        public static string toolName = "Dialogue Editor";

        public override string ToolName => toolName;

        /// <inheritdoc />
        public override IBlackboardGraphModel CreateBlackboardGraphModel(IGraphAssetModel graphAssetModel)
        {
            return new DialogueBlackboardGraphModel(graphAssetModel);
        }

        public static readonly string k_GraphName = "Dialogue";

        public override IGraphProcessor CreateGraphProcessor()
        {
            return new DialogueGraphProcessor();
        }
    }
}
