using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damageSpeed;
    [SerializeField] private List<SpriteRenderer> _fireSprites = new List<SpriteRenderer>();
    [SerializeField] private float _disparitionDuration;
    [SerializeField] Collider2D _collider;
    [SerializeField] private ParticleSystem _smokeParticle;

    private bool _extinguished;
    private float _lastDamagedTimer = 999f;

    private void OnParticleCollision(GameObject other)
    {
        if (_extinguished)
            return;

        if (other.layer == LayerMask.NameToLayer("Water"))
        {
            _health -= _damageSpeed;
            _lastDamagedTimer = 0.0f;
        }
    }

    private void Update()
    {
        _lastDamagedTimer += Time.deltaTime;

        if(_health <= 0.0f && _extinguished == false)
        {
            StartCoroutine(Disparition());
            _extinguished = true;
        }

        ParticleSystem.EmissionModule em = _smokeParticle.emission;
        em.enabled = _lastDamagedTimer <= 1.0f;
    }

    private IEnumerator Disparition()
    {
        float timer = 0.0f;

        while(timer <= _disparitionDuration)
        {
            foreach(SpriteRenderer r in _fireSprites)
            {
                Color c = r.color;
                c.a = Mathf.Lerp(1.0f, 0.0f, timer / _disparitionDuration);
                r.color = c;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        foreach (SpriteRenderer r in _fireSprites)
        {
            Color c = r.color;
            c.a = 0.0f;
            r.color = c;
        }

        _collider.enabled = false;
    }
}
