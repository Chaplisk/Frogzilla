#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `AudioDataPlayer`. Inherits from `AtomDrawer&lt;AudioDataPlayerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioDataPlayerVariable))]
    public class AudioDataPlayerVariableDrawer : VariableDrawer<AudioDataPlayerVariable> { }
}
#endif
