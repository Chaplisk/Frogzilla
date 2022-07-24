using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFrog : MonoBehaviour
{
    [SerializeField] private float _jumpInterval;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Vector3 _playerOffset;

    private GameObject _player;
    private float _timer;

    private void Awake()
    {
        _player = GameObject.Find("CharacterController");
        _timer = Random.Range(0.0f, _jumpInterval);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= _jumpInterval)
        {
            Vector2 f = ((_player.transform.position + _playerOffset) - transform.position).normalized;

            _rigid.AddForce(f * _jumpForce, ForceMode2D.Impulse);

            _timer = 0.0f;
        }
    }
}
