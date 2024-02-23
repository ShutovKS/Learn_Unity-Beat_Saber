using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawnerRandom : MonoBehaviour
{
    [Header("Экземпляры появляющихся кубов.")]
    [SerializeField] private GameObject[] cubesPrefabs;

    [Header("Ссылки на объекты из которых будут появляться кубы.")]
    [Space, SerializeField] private Transform[] spawnPoints;
    
    [Header("Частота появления кубов.")]
    [Space, SerializeField] private float beat = 1f;
    
    private bool _isHandler = true;
    private float _timer;

    private void Start()
    {
        GameManager.Instance.OnGameOver += () => _isHandler = false;
        
        if (cubesPrefabs.Length == 0)
        {
            Debug.LogError("Префабы кубов не назначены!");
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Точки появления не назначаются!");
        }
    }

    private void Update()
    {
        if (_isHandler && _timer > beat)
        {
            var rotation = 90 * Random.Range(0, 4);
            var cubePrefab = cubesPrefabs[Random.Range(0, cubesPrefabs.Length)];
            var spawnPointPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            var instantiate = Instantiate(cubePrefab, spawnPointPosition, Quaternion.identity);
            instantiate.transform.Rotate(0, 0, rotation);
            
            _timer -= beat;
        }

        _timer += Time.deltaTime;
    }
}