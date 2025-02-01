using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _timerOnColor;
    [SerializeField] private float _minTimeToDisable;
    [SerializeField] private float _maxTimeToDisable;
    [SerializeField] private int _platformLayer;

    private Coroutine _timerToDisableCoroutine;
    private Material _material;

    private void OnValidate()
    {
        if (_maxTimeToDisable < _minTimeToDisable)
            _maxTimeToDisable = _minTimeToDisable;
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnDisable()
    {
        Reset();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _platformLayer && _timerToDisableCoroutine == null)
        {
            SetTimerOnColor();
            StartTimerToDisable();
        }
    }

    private void StartTimerToDisable()
    {
        _timerToDisableCoroutine = StartCoroutine(TimerToDisableCoroutine());
    }

    private IEnumerator TimerToDisableCoroutine()
    {
        yield return new WaitForSeconds(GetTimeToDisable());

        gameObject.SetActive(false);
    }

    private void SetTimerOnColor()
    {
        _material.color = _timerOnColor;
    }

    private float GetTimeToDisable()
    {
        return Random.Range(_minTimeToDisable, _maxTimeToDisable);
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        _material.color = _defaultColor;
        _timerToDisableCoroutine = null;
    }
}
