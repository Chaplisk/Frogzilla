using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `AudioDataPlayer`. Inherits from `AtomEvent&lt;AudioDataPlayer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/AudioDataPlayer", fileName = "AudioDataPlayerEvent")]
    public sealed class AudioDataPlayerEvent : AtomEvent<AudioDataPlayer>
    {
    }
}
