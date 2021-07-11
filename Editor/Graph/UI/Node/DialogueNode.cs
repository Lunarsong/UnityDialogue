using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    class DialogueNode : UnityEditor.GraphToolsFoundation.Overdrive.    Node
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

            PartList.AppendPart(DialogueModelUIPart.Create(contentContainerPartName, Model as DialogueNodeModel, this, ussClassName));

            PartList.AppendPart(VerticalPortContainerPart.Create(bottomPortContainerPartName, PortDirection.Output, Model, this, ussClassName));
        }
        protected override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);

            if (!(Model is DialogueNodeModel dialogueNodeModel))
                return;

            /*if (evt.menu.MenuItems().Count > 0)
                evt.menu.AppendSeparator();

            evt.menu.AppendAction("Input/Add Port", action =>
            {
                CommandDispatcher.Dispatch(new AddPortCommand(PortDirection.Input, PortOrientation.Horizontal, dialogueNodeModel));
            });

            evt.menu.AppendAction("Input/Add Vertical Port", action =>
            {
                CommandDispatcher.Dispatch(new AddPortCommand(PortDirection.Input, PortOrientation.Vertical, dialogueNodeModel));
            });

            evt.menu.AppendAction("Input/Remove Port", action =>
            {
                CommandDispatcher.Dispatch(new RemovePortCommand(PortDirection.Input, PortOrientation.Horizontal, dialogueNodeModel));
            }, a => dialogueNodeModel.InputCount > 0 ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);

            evt.menu.AppendAction("Input/Remove Vertical Port", action =>
            {
                CommandDispatcher.Dispatch(new RemovePortCommand(PortDirection.Input, PortOrientation.Vertical, dialogueNodeModel));
            }, a => dialogueNodeModel.VerticalInputCount > 0 ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);

            evt.menu.AppendAction("Output/Add Port", action =>
            {
                CommandDispatcher.Dispatch(new AddPortCommand(PortDirection.Output, PortOrientation.Horizontal, dialogueNodeModel));
            });

            evt.menu.AppendAction("Output/Add Vertical Port", action =>
            {
                CommandDispatcher.Dispatch(new AddPortCommand(PortDirection.Output, PortOrientation.Vertical, dialogueNodeModel));
            });

            evt.menu.AppendAction("Output/Remove Port", action =>
            {
                CommandDispatcher.Dispatch(new RemovePortCommand(PortDirection.Output, PortOrientation.Horizontal, dialogueNodeModel));
            }, a => dialogueNodeModel.OutputCount > 0 ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);

            evt.menu.AppendAction("Output/Remove Vertical Port", action =>
            {
                CommandDispatcher.Dispatch(new RemovePortCommand(PortDirection.Output, PortOrientation.Vertical, dialogueNodeModel));
            }, a => dialogueNodeModel.VerticalOutputCount > 0 ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);*/
        }
    }
}
