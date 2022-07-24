using UnityEngine;
using System;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `AudioDataPlayer`. Inherits from `AtomVariable&lt;AudioDataPlayer, AudioDataPlayerPair, AudioDataPlayerEvent, AudioDataPlayerPairEvent, AudioDataPlayerAudioDataPlayerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/AudioDataPlayer", fileName = "AudioDataPlayerVariable")]
    public sealed class AudioDataPlayerVariable : AtomVariable<AudioDataPlayer, AudioDataPlayerPair, AudioDataPlayerEvent, AudioDataPlayerPairEvent, AudioDataPlayerAudioDataPlayerFunction>
    {
        protected override bool ValueEquals(AudioDataPlayer other)
        {
            throw new NotImplementedException();
        }
    }
}
