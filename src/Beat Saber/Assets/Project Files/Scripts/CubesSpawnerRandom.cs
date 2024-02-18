using UnityEngine;

public class CubesSpawnerRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] cubesPrefabs;

    [Space, SerializeField] private Transform[] spawnPoints;

    [Space, SerializeField] private float beat = 0.5f;

    private float _timer;

    private void Start()
    {
        if (cubesPrefabs.Length == 0)
        {
            Debug.LogError("Cubes prefabs are not assigned!");
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Spawn points are not assigned!");
        }
    }

    private void Update()
    {
        if (_timer > beat)
        {
            var cubePrefab = cubesPrefabs[Random.Range(0, cubesPrefabs.Length)];
            var spawnPointPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            var instantiate = Instantiate(cubePrefab, spawnPointPosition, Quaternion.identity);
            var cube = instantiate.GetComponent<Cube>();
            cube.SetUpActions(
                () => Debug.Log("Cube is clicked!"),
                () => Debug.Log("Cube is missed!")
            );
            
            _timer -= beat;
        }

        _timer += Time.deltaTime;
    }
}