using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityAtoms;

public class IntroBehavior : MonoBehaviour
{
    [SerializeField] private List<Dialog> _dialogs = new List<Dialog>();
    [SerializeField] private PlayableDirector _playableDirector;

    [SerializeField] private AudioDataPlayerEvent _playSound;

    private int _dialogIndex = -1;
    private bool _introFinished;

    private void Awake()
    {
        foreach (Dialog d in _dialogs)
            d.canvas.SetActive(false);
    }

    public void PassDialog(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_dialogIndex >= _dialogs.Count - 1 && _introFinished == false)
            {
                _playableDirector.Play();

                foreach (Dialog d in _dialogs)
                    d.canvas.SetActive(false);

                _introFinished = true;
            }

            if(_introFinished == false)
                NextDialog();
        }
    }

    private void NextDialog()
    {
        if (_introFinished)
            return;

        if(_dialogIndex >= 0)
        {
            _dialogs[_dialogIndex].canvas.SetActive(false);
            _dialogs[_dialogIndex].cam.SetActive(false);
        }

        ++_dialogIndex;

        _dialogs[_dialogIndex].canvas.SetActive(true);
        _dialogs[_dialogIndex].cam.SetActive(true);
        _dialogs[_dialogIndex].tmp.text = _dialogs[_dialogIndex].text;

        _playSound.Raise(new AudioDataPlayer(_dialogs[_dialogIndex].sound, transform.position));
    }
}

[System.Serializable]
public class Dialog
{
    public GameObject canvas;
    [TextArea] public string text;
    public TextMeshProUGUI tmp;
    public GameObject cam;
    public AudioData sound;
}
