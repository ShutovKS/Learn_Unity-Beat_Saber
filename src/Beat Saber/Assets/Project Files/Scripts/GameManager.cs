using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Action OnGameOver;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnHealthChanged;

    [SerializeField] private bool isDebug;
    [SerializeField] private int healthOnStart = 3;
    [SerializeField] private AudioSource audioSource;

    [field: Space, SerializeField] public GameData GameData { get; private set; }

    private bool _isDead;
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
        
        if (audioSource != null)
        {
            StartCoroutine(AudioClipOnComplete());
        }
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

        if (_health <= 0 && !_isDead)
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        _isDead = true;
        OnGameOver?.Invoke();

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(0);
    }

    private IEnumerator AudioClipOnComplete()
    {
        var clipLength = audioSource.clip.length;

        yield return new WaitForSeconds(clipLength);
        
        StartCoroutine(GameOver());
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