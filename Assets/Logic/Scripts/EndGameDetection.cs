using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndGameDetection : MonoBehaviour
{
    [SerializeField] private List<Temple> _temples;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _duration;

    private bool _gameEnded;
    private float _endTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsTemplesValidated() && _gameEnded == false)
        {
            _gameEnded = true;
            StartCoroutine(EndBehavior());
        }
    }

    private void Update()
    {
        if(_gameEnded)
        {
            _endTimer += Time.deltaTime;
        }
    }

    public void RestartGame(InputAction.CallbackContext context)
    {
        if(context.performed && _gameEnded && _endTimer >= 2.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private bool IsTemplesValidated()
    {
        bool validated = true;

        foreach(Temple t in _temples)
        {
            if(t.Completed == false)
            {
                validated = false;
                break;
            }
        }

        return validated;
    }

    private IEnumerator EndBehavior()
    {
        float timer = 0.0f;

        while(timer < _duration)
        {
            _canvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, timer / _duration);

            timer += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = 1.0f;
    }
}
