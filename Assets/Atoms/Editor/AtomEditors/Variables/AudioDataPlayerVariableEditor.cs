using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `AudioDataPlayer`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(AudioDataPlayerVariable))]
    public sealed class AudioDataPlayerVariableEditor : AtomVariableEditor<AudioDataPlayer, AudioDataPlayerPair> { }
}
