using System;
using UnityEngine;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;AudioDataPlayer&gt;`. Inherits from `IPair&lt;AudioDataPlayer&gt;`.
    /// </summary>
    [Serializable]
    public struct AudioDataPlayerPair : IPair<AudioDataPlayer>
    {
        public AudioDataPlayer Item1 { get => _item1; set => _item1 = value; }
        public AudioDataPlayer Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private AudioDataPlayer _item1;
        [SerializeField]
        private AudioDataPlayer _item2;

        public void Deconstruct(out AudioDataPlayer item1, out AudioDataPlayer item2) { item1 = Item1; item2 = Item2; }
    }
}