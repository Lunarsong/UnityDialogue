using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueAsset : ScriptableObject
    {
        [SerializeReference]
        public List<Actor> Actors = new List<Actor>();

        [SerializeReference]
        public List<Node> Start = new List<Node>();
    }
}