using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class Actor
    {
        public string Name;
        public ActorTypes Type;

    }
    public enum ActorTypes
    {
        Player,
        NPC
    }
}