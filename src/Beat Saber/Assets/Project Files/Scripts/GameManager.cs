using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Action OnGameOver;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnHealthChanged;
    
    [SerializeField] private bool isDebug;
    [SerializeField] private int healthOnStart = 3;
    
    [field: Space, SerializeField] public GameData GameData { get; private set; }

    private int _score;
    private int _health;

    private void Awake()
    {
        InitializedSingleton();

        OnScoreChanged += score =>
        {
            if (isDebug)
            {
                Debug.Log($"Score: {score}");
            }
        };

        OnHealthChanged += health =>
        {
            if (isDebug)
            {
                Debug.Log($"Health: {health}");
            }
        };
    }

    private void Start()
    {
        _health = healthOnStart;
        OnHealthChanged?.Invoke(_health);
    }

    public void OnHitCorrectSaber()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void OnHitDestroy()
    {
        _health--;
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            OnGameOver?.Invoke();
        }
    }

    private void InitializedSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}