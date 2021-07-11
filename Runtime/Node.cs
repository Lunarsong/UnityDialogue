using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class Node
    {
        [SerializeReference]
        public Actor Speaker;

        public string Line;

        [SerializeReference]
        public List<Node> Options = new List<Node>();
    }
}