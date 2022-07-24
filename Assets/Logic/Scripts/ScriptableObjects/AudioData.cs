using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class ClipBank
{
    public List<AudioClip> Clips = new List<AudioClip>();
}

[CreateAssetMenu(menuName = "ScriptableObjects/Audio/AudioData")]
public class AudioData : ScriptableObject
{
    public float delay;

    //Variables de l'inspecteur
    [SerializeField] string _audioGroup = string.Empty;
    [SerializeField] private bool _useVolumeRange;

    [HideIf("_useVolumeRange")]
    [SerializeField] [Range(0.0f, 1.0f)] float _volume = 1.0f;
    [ShowIf("_useVolumeRange")]
    [MinMaxSlider(0.0f, 1.0f)][SerializeField] private Vector2 _volumeRange;

    [SerializeField] [Range(0.0f, 1.0f)] float _spatialBlend = 0.5f;
    [SerializeField] private bool _usePitchRange;

    [HideIf("_usePitchRange")]
    [SerializeField] private float _pitch = 1.0f;
    [ShowIf("_usePitchRange")]
    [MinMaxSlider(0.75f, 1.25f)][SerializeField] Vector2 _pitchRange = new Vector2(1.0f, 1.0f);

    [SerializeField] [Range(0, 256)] int _priority = 128;
    [SerializeField] List<ClipBank> _audioClipBanks = new List<ClipBank>();

    public bool spatialize = true;



    public string audioGroup { get { return _audioGroup; } }
    public float volume { get { return _useVolumeRange ? Random.Range(_volumeRange.x, _volumeRange.y) : _volume; } }
    public float spatialBlend { get { return _spatialBlend; } }

    public float pitch { get { return _usePitchRange ? Random.Range(_pitchRange.x, _pitchRange.y) : _pitch; } }
    public int priority { get { return _priority; } }
    public int bankCount { get { return _audioClipBanks.Count; } }

    [HideInInspector] public float volumeMultiplier = -1f;

    private List<AudioClip> _clipsLeftToPlay;
    private AudioClip _lastClipPlayed;

    public AudioData DeepCopyWithCustomVolume(float customVolume)
    {
        AudioData dc = new AudioData();

        dc._audioGroup = _audioGroup;
        dc._useVolumeRange = _useVolumeRange;
        dc._volume = customVolume;
        dc._volumeRange = _volumeRange;
        dc._spatialBlend = _spatialBlend;
        dc._usePitchRange = _usePitchRange;
        dc._pitch = _pitch;
        dc._pitchRange = _pitchRange;
        dc._priority = _priority;
        dc._audioClipBanks = _audioClipBanks;

        return dc;
    }

    public bool checkIfAudioClipExist
    {
        get
        {
            if (_audioClipBanks == null || _audioClipBanks.Count <= 0) return false;
            if (_audioClipBanks[0].Clips.Count == 0) return false;

            foreach (AudioClip clip in _audioClipBanks[0].Clips)
                if (clip == null)
                    return false;

            return true;
        }
    }

    public AudioClip audioClip
    {
        get
        {
            if (_audioClipBanks == null || _audioClipBanks.Count <= 0) return null;
            if (_audioClipBanks[0].Clips.Count == 0) return null;

            if(_clipsLeftToPlay == null || _clipsLeftToPlay.Count == 0)
            {
                _clipsLeftToPlay = new List<AudioClip>();
                foreach(AudioClip cl in _audioClipBanks[0].Clips)
                {
                    if(_lastClipPlayed != cl)
                        _clipsLeftToPlay.Add(cl);
                }
            }

            AudioClip clip;

            if (_audioClipBanks[0].Clips.Count == 1)
            {
                clip = _audioClipBanks[0].Clips[0];
            }
            else
            {
                int randomIndex = Random.Range(0, _clipsLeftToPlay.Count);
                clip = _clipsLeftToPlay[randomIndex];
                _lastClipPlayed = clip;

                _clipsLeftToPlay.RemoveAt(randomIndex);
            }

            return clip;
        }
    }
}
