using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Set variable value Action of type `AudioDataPlayer`. Inherits from `SetVariableValue&lt;AudioDataPlayer, AudioDataPlayerPair, AudioDataPlayerVariable, AudioDataPlayerConstant, AudioDataPlayerReference, AudioDataPlayerEvent, AudioDataPlayerPairEvent, AudioDataPlayerVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/AudioDataPlayer", fileName = "SetAudioDataPlayerVariableValue")]
    public sealed class SetAudioDataPlayerVariableValue : SetVariableValue<
        AudioDataPlayer,
        AudioDataPlayerPair,
        AudioDataPlayerVariable,
        AudioDataPlayerConstant,
        AudioDataPlayerReference,
        AudioDataPlayerEvent,
        AudioDataPlayerPairEvent,
        AudioDataPlayerAudioDataPlayerFunction,
        AudioDataPlayerVariableInstancer>
    { }
}
