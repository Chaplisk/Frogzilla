using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Reference of type `AudioDataPlayer`. Inherits from `AtomReference&lt;AudioDataPlayer, AudioDataPlayerPair, AudioDataPlayerConstant, AudioDataPlayerVariable, AudioDataPlayerEvent, AudioDataPlayerPairEvent, AudioDataPlayerAudioDataPlayerFunction, AudioDataPlayerVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AudioDataPlayerReference : AtomReference<
        AudioDataPlayer,
        AudioDataPlayerPair,
        AudioDataPlayerConstant,
        AudioDataPlayerVariable,
        AudioDataPlayerEvent,
        AudioDataPlayerPairEvent,
        AudioDataPlayerAudioDataPlayerFunction,
        AudioDataPlayerVariableInstancer>, IEquatable<AudioDataPlayerReference>
    {
        public AudioDataPlayerReference() : base() { }
        public AudioDataPlayerReference(AudioDataPlayer value) : base(value) { }
        public bool Equals(AudioDataPlayerReference other) { return base.Equals(other); }
        protected override bool ValueEquals(AudioDataPlayer other)
        {
            throw new NotImplementedException();
        }
    }
}
