using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `AudioDataPlayer`. Inherits from `AtomEventInstancer&lt;AudioDataPlayer, AudioDataPlayerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/AudioDataPlayer Event Instancer")]
    public class AudioDataPlayerEventInstancer : AtomEventInstancer<AudioDataPlayer, AudioDataPlayerEvent> { }
}
