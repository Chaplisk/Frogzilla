using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temple : MonoBehaviour
{
    [SerializeField] private float _fillSpeed;
    [SerializeField] private int _babySpawned;

    [SerializeField] private SpriteRenderer _temple1;
    [SerializeField] private SpriteRenderer _temple2;
    [SerializeField] private SpriteRenderer _temple3;

    [SerializeField] private GameObject _particles;

    [SerializeField] private Image _fill;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private List<GameObject> _babyFrogs = new List<GameObject>();
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _t2RestorationTarget, _t3RestorationTarget;
    [SerializeField] private float _transitionDuration;

    [SerializeField] private float _health;
    private bool _t2Restored, _t3Restored;

    private void Start()
    {
        SetTempleAlpha(_temple1, 1.0f);
        SetTempleAlpha(_temple2, 0.0f);
        SetTempleAlpha(_temple3, 0.0f);
    }

    private void Update()
    {
        if(_t2Restored == false && _health >= _t2RestorationTarget)
        {
            StartCoroutine(FadeTemple(_temple1, 0.0f, _transitionDuration));
            StartCoroutine(FadeTemple(_temple2, 1.0f, _transitionDuration));
            _t2Restored = true;
        }
        else if(_t3Restored == false && _health >= _t3RestorationTarget)
        {
            StartCoroutine(FadeTemple(_temple2, 0.0f, _transitionDuration));
            StartCoroutine(FadeTemple(_temple3, 1.0f, _transitionDuration));
            _t3Restored = true;

            for(int x = 0; x < _babySpawned; x++)
            {
                int randomIndex = Random.Range(0, _babyFrogs.Count);
                GameObject newBaby = Instantiate(_babyFrogs[randomIndex], _spawnPoint.position, _babyFrogs[randomIndex].transform.rotation);
            }

            StartCoroutine(FadeCanvasGroup(_canvasGroup, 0.0f, 1.0f));

            _particles.SetActive(true);
        }

        _fill.fillAmount = _health / _t3RestorationTarget;
    }

    private void SetTempleAlpha(SpriteRenderer r, float a)
    {
        Color tColor = r.color;
        tColor.a = a;
        r.color = tColor;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup g, float a, float d)
    {
        float timer = 0.0f;
        float baseAlpha = g.alpha;

        while(timer < d)
        {

            g.alpha = Mathf.Lerp(baseAlpha, a, timer / d);

            timer += Time.deltaTime;
            yield return null;
        }

        g.alpha = a;
    }

    private IEnumerator FadeTemple(SpriteRenderer r, float alphaTarget, float duration)
    {
        float timer = 0.0f;
        float initialAlpha = r.color.a;

        while(timer < duration)
        {
            timer += Time.deltaTime;

            SetTempleAlpha(r, Mathf.Lerp(initialAlpha, alphaTarget, timer / duration));

            yield return null;
        }

        SetTempleAlpha(r, alphaTarget);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (_t3Restored)
            return;

        if(other.layer == LayerMask.NameToLayer("Water"))
        {
            _health += _fillSpeed;
        }
    }
}
