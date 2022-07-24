#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `AudioDataPlayer`. Inherits from `AtomDrawer&lt;AudioDataPlayerConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioDataPlayerConstant))]
    public class AudioDataPlayerConstantDrawer : VariableDrawer<AudioDataPlayerConstant> { }
}
#endif
