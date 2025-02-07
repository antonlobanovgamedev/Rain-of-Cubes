using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesCreator))]
public class CubesPool : MonoBehaviour
{
    [SerializeField] private int _initCapacity;

    private List<Cube> _pool;
    private CubesCreator _spawner;

    private void Awake()
    {
        _pool = new List<Cube>(_initCapacity);
        _spawner = GetComponent<CubesCreator>();
    }

    private void Start()
    {
        _pool.AddRange(_spawner.Create(_initCapacity));
    }

    public Cube Get()
    {
        if (TryGetNotActiveCube(out Cube cube))
        {
            return cube;
        }
        else
        {
            Cube newCube = _spawner.Create();
            _pool.Add(newCube);

            return newCube;
        }
    }

    private bool TryGetNotActiveCube(out Cube notActiveCube)
    {
        notActiveCube = null;

        foreach (Cube cube in _pool)
            if (cube.gameObject.activeSelf == false)
            {
                notActiveCube = cube;

                break;
            }

        return notActiveCube != null;
    }
}
