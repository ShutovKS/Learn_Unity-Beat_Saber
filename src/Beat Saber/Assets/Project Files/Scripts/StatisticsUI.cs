using TMPro;
using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
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
