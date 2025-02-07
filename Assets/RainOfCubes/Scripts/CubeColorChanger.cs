using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _timerOnColor;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    public void Reset()
    {
        _material.color = _defaultColor;
    }

    public void SetTimerOnColor()
    {
        _material.color = _timerOnColor;
    }
}
