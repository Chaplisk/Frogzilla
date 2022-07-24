using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `AudioDataPlayer`. Inherits from `AtomEventReferenceListener&lt;AudioDataPlayer, AudioDataPlayerEvent, AudioDataPlayerEventReference, AudioDataPlayerUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/AudioDataPlayer Event Reference Listener")]
    public sealed class AudioDataPlayerEventReferenceListener : AtomEventReferenceListener<
        AudioDataPlayer,
        AudioDataPlayerEvent,
        AudioDataPlayerEventReference,
        AudioDataPlayerUnityEvent>
    { }
}
