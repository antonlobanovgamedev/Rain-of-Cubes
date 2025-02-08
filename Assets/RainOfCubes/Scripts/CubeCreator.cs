using UnityEngine;

public class CubeCreator
{
    private Cube _cubePrefab;
    private Transform _parent;

    public CubeCreator(Cube cubePrefab, Transform parent)
    {
        _cubePrefab = cubePrefab;
        _parent = parent;
    }

    public Cube[] Create(int count)
    {
        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
            cubes[i] = Create();

        return cubes;
    }

    public Cube Create()
    {
        Cube cube = Object.Instantiate(_cubePrefab, _parent);

        cube.gameObject.SetActive(false);

        return cube;
    }
}