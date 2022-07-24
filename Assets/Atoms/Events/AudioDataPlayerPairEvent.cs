using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `AudioDataPlayerPair`. Inherits from `AtomEvent&lt;AudioDataPlayerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/AudioDataPlayerPair", fileName = "AudioDataPlayerPairEvent")]
    public sealed class AudioDataPlayerPairEvent : AtomEvent<AudioDataPlayerPair>
    {
    }
}
