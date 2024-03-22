using TMPro;
using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [Header("Ссылка на текст где будет отображаться количество жизней")]
    [SerializeField] private TextMeshProUGUI healthText;
    [Header("Ссылка на текст где будет отображаться количество очков")]
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        GameManager.Instance.OnHealthChanged += health =>
        {
            healthText.text = $"{health}";
        };
        
        GameManager.Instance.OnScoreChanged += score =>
        {
            scoreText.text = $"{score}";
        };
    }
}
