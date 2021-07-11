using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEngine;
using UnityEngine.GraphToolsFoundation.Overdrive;

namespace DialogueSystem
{
    public class DialogueGraphProcessor : IGraphProcessor
    {
        public GraphProcessingResult ProcessGraph(IGraphModel graphModel)
        {
            DialogueGraphModel graph = graphModel as DialogueGraphModel;
            DialogueGraphAssetModel assetModel = graphModel.AssetModel as DialogueGraphAssetModel;
            if (graph.StartNode == null)
            {
                return new GraphProcessingResult();
            }
            DialogueAsset dialogue = GetOrCreateRuntimeAsset(assetModel);
            dialogue.Start.Clear();
            dialogue.Actors.Clear();

            // Create the dictionaries
            Dictionary<DialogueActorModel, Actor> actorModelToActor = new Dictionary<DialogueActorModel, Actor>();
            Dictionary<INodeModel, Node> nodeModelToNode = new Dictionary<INodeModel, Node>();
            foreach (INodeModel nodeModel in graphModel.NodeModels)
            { 
                if (nodeModel is DialogueActorModel actorModel)
                {
                    Actor actor = new Actor();
                    actor.Name = actorModel.Name;
                    actor.Type = actorModel.ActorType;
                    dialogue.Actors.Add(actor);
                    actorModelToActor.Add(actorModel, actor);
                }
                else if (nodeModel is DialogueNodeModel dialogueNodeModel)
                {
                    Node node = new Node();
                    node.Line = dialogueNodeModel.DialogueLine;
                    nodeModelToNode.Add(dialogueNodeModel, node);
                }
            }

            // Process the nodes.
            foreach (INodeModel nodeModel in graphModel.NodeModels)
            {
                if (nodeModel is DialogueNodeModel dialogueNodeModel)
                {
                    Node node = nodeModelToNode[dialogueNodeModel];
                    if (dialogueNodeModel.Speaker == null)
                    {
                        Debug.Log("Undefined actor as speaker.");
                    }
                    else
                    {
                        node.Speaker = actorModelToActor[dialogueNodeModel.Speaker];
                    }
                    List<DialogueNodeModel> connections = GetConnections(dialogueNodeModel, graphModel);
                    foreach (DialogueNodeModel connectedNode in connections)
                    {
                        node.Options.Add(nodeModelToNode[connectedNode]);
                    }
                }
            }

            // Set the start node.
            List<DialogueNodeModel> startModels = GetConnections(graph.StartNode, graphModel);
            foreach(DialogueNodeModel startOption in startModels)
            {
                dialogue.Start.Add(nodeModelToNode[startOption]);
            }

            EditorUtility.SetDirty(dialogue);
            return new GraphProcessingResult();
        }

        protected static List<DialogueNodeModel> GetConnections(NodeModel node, IGraphModel graphModel)
        {
            List<DialogueNodeModel> connections = new List<DialogueNodeModel>();            
            foreach (IPortModel port in node.GetOutputPorts())
            {
                foreach (IEdgeModel edge in port.GetConnectedEdges())
                {
                    if (graphModel.TryGetModelFromGuid(edge.ToNodeGuid, out IGraphElementModel connectedModel))
                    {
                        DialogueNodeModel connectedNodeModel = connectedModel as DialogueNodeModel;
                        connections.Add(connectedNodeModel);
                    }
                }
            }
            return connections;
        }

        static DialogueAsset GetOrCreateRuntimeAsset(DialogueGraphAssetModel assetObject)
        {
            string assetPath = AssetDatabase.GetAssetPath(assetObject);
            DialogueAsset tree = AssetDatabase.LoadAssetAtPath<DialogueAsset>(assetPath);
            if (tree == null)
            {
                tree = ScriptableObject.CreateInstance<DialogueAsset>();
                AssetDatabase.AddObjectToAsset(tree, assetObject);
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(assetObject));
            }
            tree.name = assetObject.name;
            return tree;
        }
    }
}