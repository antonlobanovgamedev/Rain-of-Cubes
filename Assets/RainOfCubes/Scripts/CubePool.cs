using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private int _initCapacity;
    [SerializeField] private Cube _cubePrefab;

    private Stack<Cube> _pool;
    private CubeCreator _spawner;

    private void Awake()
    {
        _pool = new Stack<Cube>(_initCapacity);
        _spawner = new CubeCreator(_cubePrefab, transform);
    }

    private void Start()
    {
        foreach (Cube cube in _spawner.Create(_initCapacity))
            Release(cube);
    }

    public Cube Get()
    {
        Cube cube = null;

        if (_pool.Count != 0)
            cube = _pool.Pop();
        else
            cube = _spawner.Create();

        cube.TimerHasExpired += Release;

        return cube;
    }

    public void Release(Cube cube)
    {
        _pool.Push(cube);

        cube.TimerHasExpired -= Release;
    }
}
