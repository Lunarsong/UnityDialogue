using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    class ActorNode : UnityEditor.GraphToolsFoundation.Overdrive.Node
    {
        public static readonly string titleIconContainerPartName = "title-icon-container";
        public static readonly string contentContainerPartName = "content-container";
        /// <summary>
        /// The name of the top container for vertical ports.
        /// </summary>
        public static readonly string topPortContainerPartName = "top-vertical-port-container";

        /// <summary>
        /// The name of the bottom container for vertical ports.
        /// </summary>
        public static readonly string bottomPortContainerPartName = "bottom-vertical-port-container";
        protected override void BuildPartList()
        {
            PartList.AppendPart(VerticalPortContainerPart.Create(topPortContainerPartName, PortDirection.Input, Model, this, ussClassName));

            PartList.AppendPart(DialogueModelUIPart.Create(contentContainerPartName, Model as DialogueActorModel, this, ussClassName));

            PartList.AppendPart(VerticalPortContainerPart.Create(bottomPortContainerPartName, PortDirection.Output, Model, this, ussClassName));
        }
        protected override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);

            if (!(Model is DialogueActorModel actor))
                return;
        }
    }
}
