using UnityEngine;

public class CubesSpawnerRandom : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab1;
    [SerializeField] private GameObject cubePrefab2;
    
    [Space, SerializeField] private Transform[] spawnPoints;

    [Space, SerializeField] private float beat = 0.5f;

    private float _timer;

    private void Update()
    {
        if (_timer > beat)
        {
            var cubePrefab = Random.Range(0, 2) == 0 ? cubePrefab1 : cubePrefab2;
            
            Instantiate(cubePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            
            _timer -= beat;
        }

        _timer += Time.deltaTime;
    }
}