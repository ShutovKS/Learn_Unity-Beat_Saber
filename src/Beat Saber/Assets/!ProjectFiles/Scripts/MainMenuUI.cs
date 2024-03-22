using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Ссылка на кнопку для запуска игры")]
    [SerializeField] private Button startButton;
    [Header("Ссылка на кнопку для выхода из игры")]
    [SerializeField] private Button quitButton;
    
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    
    private void StartGame()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene(1);
    }
    
    private void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
