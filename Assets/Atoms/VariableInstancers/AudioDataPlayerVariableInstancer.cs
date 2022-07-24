using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Variable Instancer of type `AudioDataPlayer`. Inherits from `AtomVariableInstancer&lt;AudioDataPlayerVariable, AudioDataPlayerPair, AudioDataPlayer, AudioDataPlayerEvent, AudioDataPlayerPairEvent, AudioDataPlayerAudioDataPlayerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/AudioDataPlayer Variable Instancer")]
    public class AudioDataPlayerVariableInstancer : AtomVariableInstancer<
        AudioDataPlayerVariable,
        AudioDataPlayerPair,
        AudioDataPlayer,
        AudioDataPlayerEvent,
        AudioDataPlayerPairEvent,
        AudioDataPlayerAudioDataPlayerFunction>
    { }
}
