using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField, Header("Ссылка на кнопку для запуска игры")]
    private Button startButton;

    [SerializeField, Header("Ссылка на кнопку для выхода из игры")]
    private Button quitButton;

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