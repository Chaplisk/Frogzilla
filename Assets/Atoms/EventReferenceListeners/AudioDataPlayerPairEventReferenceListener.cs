using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `AudioDataPlayerPair`. Inherits from `AtomEventReferenceListener&lt;AudioDataPlayerPair, AudioDataPlayerPairEvent, AudioDataPlayerPairEventReference, AudioDataPlayerPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/AudioDataPlayerPair Event Reference Listener")]
    public sealed class AudioDataPlayerPairEventReferenceListener : AtomEventReferenceListener<
        AudioDataPlayerPair,
        AudioDataPlayerPairEvent,
        AudioDataPlayerPairEventReference,
        AudioDataPlayerPairUnityEvent>
    { }
}
