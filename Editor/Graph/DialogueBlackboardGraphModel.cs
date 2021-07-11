using System.Collections.Generic;
using System.Linq;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;

namespace DialogueSystem
{
    class DialogueBlackboardGraphModel : BlackboardGraphModel
    {
        /// <inheritdoc />
        public DialogueBlackboardGraphModel(IGraphAssetModel graphAssetModel)
            : base(graphAssetModel) { }

        /// <inheritdoc />
        public override string GetBlackboardTitle()
        {
            return "Dialogue";
        }

        /// <inheritdoc />
        public override IEnumerable<IVariableDeclarationModel> GetSectionRows(string sectionName)
        {
            return Enumerable.Empty<IVariableDeclarationModel>();
        }
    }
}
