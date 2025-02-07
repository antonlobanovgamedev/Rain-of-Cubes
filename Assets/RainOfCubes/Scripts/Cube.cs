using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubeColorChanger))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minTimeToDisable;
    [SerializeField] private float _maxTimeToDisable;
    [SerializeField] private int _platformLayer;

    private Coroutine _timerToDisableCoroutine;
    private CubeColorChanger _colorChanger;

    private void OnValidate()
    {
        if (_maxTimeToDisable < _minTimeToDisable)
            _maxTimeToDisable = _minTimeToDisable;
    }

    private void Awake()
    {
        _colorChanger = GetComponent<CubeColorChanger>();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _platformLayer && _timerToDisableCoroutine == null)
        {
            _colorChanger.SetTimerOnColor();
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

    private float GetTimeToDisable()
    {
        return Random.Range(_minTimeToDisable, _maxTimeToDisable);
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        _timerToDisableCoroutine = null;

        _colorChanger.Reset();
    }
}
