using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `AudioDataPlayer`. Inherits from `AtomEventReference&lt;AudioDataPlayer, AudioDataPlayerVariable, AudioDataPlayerEvent, AudioDataPlayerVariableInstancer, AudioDataPlayerEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AudioDataPlayerEventReference : AtomEventReference<
        AudioDataPlayer,
        AudioDataPlayerVariable,
        AudioDataPlayerEvent,
        AudioDataPlayerVariableInstancer,
        AudioDataPlayerEventInstancer>, IGetEvent 
    { }
}
