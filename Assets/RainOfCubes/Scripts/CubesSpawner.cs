using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private CubesPool _pool;
    [SerializeField] private Collider _platform;
    [SerializeField] private float _height;

    private Bounds _platformBounds;

    private void Awake()
    {
        _platformBounds = _platform.bounds;
    }

    private void FixedUpdate()
    {
        SpawnCube();
    }

    private void SpawnCube()
    {
        Cube cube = _pool.GetCube();
        cube.transform.position = GetRandomSpawnPoint(_platformBounds);
        cube.gameObject.SetActive(true);
    }

    private Vector3 GetRandomSpawnPoint(Bounds platformBounds)
    {
        float positionX = Random.Range(platformBounds.min.x, platformBounds.max.x);
        float positionZ = Random.Range(platformBounds.min.z, platformBounds.max.z);

        return new Vector3 (positionX, _height, positionZ);
    }
}
