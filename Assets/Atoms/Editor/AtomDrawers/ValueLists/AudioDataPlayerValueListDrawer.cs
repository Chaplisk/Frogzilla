#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `AudioDataPlayer`. Inherits from `AtomDrawer&lt;AudioDataPlayerValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioDataPlayerValueList))]
    public class AudioDataPlayerValueListDrawer : AtomDrawer<AudioDataPlayerValueList> { }
}
#endif
