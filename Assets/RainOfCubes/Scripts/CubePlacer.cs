using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private Collider _platform;
    [SerializeField] private float _height;

    private Bounds _platformBounds;

    private void Awake()
    {
        _platformBounds = _platform.bounds;
    }

    private void FixedUpdate()
    {
        PlaceCube();
    }

    private void PlaceCube()
    {
        Cube cube = _pool.Get();
        cube.transform.position = GetRandomSpawnPoint(_platformBounds);

        cube.gameObject.SetActive(true);
    }

    private Vector3 GetRandomSpawnPoint(Bounds platformBounds)
    {
        float positionX = Random.Range(platformBounds.min.x, platformBounds.max.x);
        float positionZ = Random.Range(platformBounds.min.z, platformBounds.max.z);

        return new Vector3(positionX, _height, positionZ);
    }
}