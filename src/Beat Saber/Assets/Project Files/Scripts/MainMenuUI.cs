using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
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
