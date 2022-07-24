#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AudioDataPlayer`. Inherits from `AtomEventEditor&lt;AudioDataPlayer, AudioDataPlayerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(AudioDataPlayerEvent))]
    public sealed class AudioDataPlayerEventEditor : AtomEventEditor<AudioDataPlayer, AudioDataPlayerEvent> { }
}
#endif
