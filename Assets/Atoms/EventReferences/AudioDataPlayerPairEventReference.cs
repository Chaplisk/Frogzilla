using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `AudioDataPlayerPair`. Inherits from `AtomEventReference&lt;AudioDataPlayerPair, AudioDataPlayerVariable, AudioDataPlayerPairEvent, AudioDataPlayerVariableInstancer, AudioDataPlayerPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AudioDataPlayerPairEventReference : AtomEventReference<
        AudioDataPlayerPair,
        AudioDataPlayerVariable,
        AudioDataPlayerPairEvent,
        AudioDataPlayerVariableInstancer,
        AudioDataPlayerPairEventInstancer>, IGetEvent 
    { }
}
