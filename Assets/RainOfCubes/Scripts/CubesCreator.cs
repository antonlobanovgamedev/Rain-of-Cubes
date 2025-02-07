using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube[] Create(int count)
    {
        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
            cubes[i] = Create();

        return cubes;
    }

    public Cube Create()
    {
        Cube cube = Instantiate(_cubePrefab, transform);

        cube.gameObject.SetActive(false);

        return cube;
    }
}
