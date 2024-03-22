using UnityEngine;
using Random = UnityEngine.Random;

namespace Beat_Saber.Scripts
{
    public class CubesSpawnerRandom : MonoBehaviour
    {
        [SerializeField, Header("Экземпляры появляющихся кубов.")]
        private GameObject[] cubesPrefabs;

        [Space, SerializeField, Header("Ссылки на объекты из которых будут появляться кубы.")]
        private Transform[] spawnPoints;

        [Space, SerializeField, Header("Частота появления кубов.")]
        private float beat = 1f;

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
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                var instantiate = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
                instantiate.transform.Rotate(0, 0, rotation);

                _timer -= beat;
            }

            _timer += Time.deltaTime;
        }
    }
}