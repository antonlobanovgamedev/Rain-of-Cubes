using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour 
{
    [SerializeField] private int _initCapacity;
    [SerializeField] private Cube _cubePrefab;

    private List<Cube> _pool;

    private void Awake()
    {
        _pool = new List<Cube>(_initCapacity);
    }

    private void Start()
    {
        CreateCubes(_initCapacity);
    }

    public Cube GetCube()
    {
        if (TryGetNotActiveCube(out Cube cube))
            return cube;
        else
            return CreateCube();
    }

    private void CreateCubes(int count)
    {
        for (int i = 0; i < _pool.Count; i++)
            CreateCube();
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab, transform);

        cube.gameObject.SetActive(false);
        _pool.Add(cube);

        return cube;
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
