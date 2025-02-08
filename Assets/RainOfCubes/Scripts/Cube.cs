using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubeColorChanger))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> TimerHasExpired;

    [SerializeField] private float _minTimeToReset;
    [SerializeField] private float _maxTimeToReset;
    [SerializeField] private int _platformLayer;

    private Coroutine _waitToResetCoroutine;
    private Rigidbody _rigidbody;
    private CubeColorChanger _colorChanger;

    private void OnValidate()
    {
        if (_maxTimeToReset < _minTimeToReset)
            _maxTimeToReset = _minTimeToReset;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colorChanger = GetComponent<CubeColorChanger>();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _platformLayer && _waitToResetCoroutine == null)
        {
            _colorChanger.SetTimerOnColor();
            StartTimerToReset();
        }
    }

    private void StartTimerToReset()
    {
        _waitToResetCoroutine = StartCoroutine(WaitToResetCoroutine());
    }

    private IEnumerator WaitToResetCoroutine()
    {
        yield return new WaitForSeconds(GetTimeToReset());

        gameObject.SetActive(false);
        TimerHasExpired?.Invoke(this);
    }

    private float GetTimeToReset()
    {
        return UnityEngine.Random.Range(_minTimeToReset, _maxTimeToReset);
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        _waitToResetCoroutine = null;
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        _colorChanger.Reset();
    }
}