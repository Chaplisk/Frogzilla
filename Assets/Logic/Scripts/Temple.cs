using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms;

public class Temple : MonoBehaviour
{
    public bool Completed => _t3Restored;

    [SerializeField] private float _fillSpeed;
    [SerializeField] private int _babySpawned;

    [SerializeField] private SpriteRenderer _temple1;
    [SerializeField] private SpriteRenderer _temple2;
    [SerializeField] private SpriteRenderer _temple3;

    [SerializeField] private List<SpriteRenderer> _livingThings = new List<SpriteRenderer>();
    [SerializeField] private List<SpriteRenderer> _deadThings = new List<SpriteRenderer>();

    [SerializeField] private GameObject _particles;
    [SerializeField] private List<ParticleSystem> _leavesParticles = new List<ParticleSystem>();

    [SerializeField] private Image _fill;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _mask;
    [SerializeField] private float _maskScaleDuration;
    [SerializeField] private float _maskScaleRotationSpeed;
    [SerializeField] private Vector3 _maskTargetScale;

    [SerializeField] private List<GameObject> _babyFrogs = new List<GameObject>();
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _t2RestorationTarget, _t3RestorationTarget;
    [SerializeField] private float _transitionDuration;
    [SerializeField] private float _deadLivingTransitionDuration;

    [SerializeField] private AudioDataPlayerEvent _playSound;
    [SerializeField] private AudioData _templeCompleted;

    [SerializeField] private float _health;
    private bool _t2Restored, _t3Restored;

    private float _lastWaterParticleHitTimer = 999f;

    private void Start()
    {
        SetSpriteAlpha(_temple1, 1.0f);
        SetSpriteAlpha(_temple2, 0.0f);
        SetSpriteAlpha(_temple3, 0.0f);

        _mask.transform.localScale = Vector3.zero;

        foreach (SpriteRenderer sr in _livingThings)
            SetSpriteAlpha(sr, 0.0f);

        foreach (SpriteRenderer sr in _deadThings)
            SetSpriteAlpha(sr, 1.0f);
    }

    private void Update()
    {
        _lastWaterParticleHitTimer += Time.deltaTime;

        if(_t2Restored == false && _health >= _t2RestorationTarget)
        {
            StartCoroutine(FadeSprite(_temple1, 0.0f, _transitionDuration));
            StartCoroutine(FadeSprite(_temple2, 1.0f, _transitionDuration));
            _t2Restored = true;
        }
        else if(_t3Restored == false && _health >= _t3RestorationTarget)
        {
            StartCoroutine(FadeSprite(_temple2, 0.0f, _transitionDuration));
            StartCoroutine(FadeSprite(_temple3, 1.0f, _transitionDuration));
            _t3Restored = true;

            for(int x = 0; x < _babySpawned; x++)
            {
                int randomIndex = Random.Range(0, _babyFrogs.Count);
                GameObject newBaby = Instantiate(_babyFrogs[randomIndex], _spawnPoint.position, _babyFrogs[randomIndex].transform.rotation);
            }

            StartCoroutine(FadeCanvasGroup(_canvasGroup, 0.0f, 1.0f));

            _particles.SetActive(true);
            StartCoroutine(SetGameObjectScale(_mask, _maskTargetScale, _maskScaleDuration));

            foreach (SpriteRenderer sr in _deadThings)
                StartCoroutine(FadeSprite(sr, 0.0f, _deadLivingTransitionDuration));

            foreach (SpriteRenderer sr in _livingThings)
                StartCoroutine(FadeSprite(sr, 1.0f, _deadLivingTransitionDuration));

            _playSound.Raise(new AudioDataPlayer(_templeCompleted, transform.position));
        }

        _fill.fillAmount = _health / _t3RestorationTarget;

        foreach (ParticleSystem ps in _leavesParticles)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = _lastWaterParticleHitTimer < 1.0f;
        }
    }

    private IEnumerator SetGameObjectScale(GameObject o, Vector3 scale, float duration)
    {
        float timer = 0.0f;
        Vector3 baseScale = o.transform.localScale;

        while(timer < duration)
        {
            o.transform.Rotate(new Vector3(0, 0, _maskScaleRotationSpeed * Time.deltaTime));
            o.transform.localScale = Vector3.Lerp(baseScale, scale, timer / duration);

            timer += Time.deltaTime;
            yield return null;
        }

        o.transform.localScale = scale;
    }

    private void SetSpriteAlpha(SpriteRenderer r, float a)
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

    private IEnumerator FadeSprite(SpriteRenderer r, float alphaTarget, float duration)
    {
        float timer = 0.0f;
        float initialAlpha = r.color.a;

        while(timer < duration)
        {
            timer += Time.deltaTime;

            SetSpriteAlpha(r, Mathf.Lerp(initialAlpha, alphaTarget, timer / duration));

            yield return null;
        }

        SetSpriteAlpha(r, alphaTarget);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (_t3Restored)
            return;

        if(other.layer == LayerMask.NameToLayer("Water"))
        {
            _health += _fillSpeed;
        }

        _lastWaterParticleHitTimer = 0.0f;
    }
}
