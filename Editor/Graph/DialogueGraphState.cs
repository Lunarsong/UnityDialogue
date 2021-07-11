using System;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.CommandStateObserver;

namespace DialogueSystem
{
    class DialogueGraphState : GraphToolState
    {
        /// <inheritdoc />
        public DialogueGraphState(Hash128 graphViewEditorWindowGUID, Preferences preferences)
            : base(graphViewEditorWindowGUID, preferences) { }

        /// <inheritdoc />
        public override void RegisterCommandHandlers(Dispatcher dispatcher)
        {
            base.RegisterCommandHandlers(dispatcher);

            if (!(dispatcher is CommandDispatcher commandDispatcher))
                return;

            commandDispatcher.RegisterCommandHandler<AddPortCommand>(AddPortCommand.DefaultHandler);
            commandDispatcher.RegisterCommandHandler<RemovePortCommand>(RemovePortCommand.DefaultHandler);
        }
    }
}
