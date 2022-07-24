using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Value List of type `AudioDataPlayer`. Inherits from `AtomValueList&lt;AudioDataPlayer, AudioDataPlayerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/AudioDataPlayer", fileName = "AudioDataPlayerValueList")]
    public sealed class AudioDataPlayerValueList : AtomValueList<AudioDataPlayer, AudioDataPlayerEvent> { }
}
