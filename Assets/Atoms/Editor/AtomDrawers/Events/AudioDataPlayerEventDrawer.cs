#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AudioDataPlayer`. Inherits from `AtomDrawer&lt;AudioDataPlayerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioDataPlayerEvent))]
    public class AudioDataPlayerEventDrawer : AtomDrawer<AudioDataPlayerEvent> { }
}
#endif
