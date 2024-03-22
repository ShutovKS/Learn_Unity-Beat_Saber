using TMPro;
using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [SerializeField, Header("Ссылка на текст где будет отображаться количество жизней")]
    private TextMeshProUGUI healthText;

    [SerializeField, Header("Ссылка на текст где будет отображаться количество очков")]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.Instance.OnHealthChanged += health => healthText.text = $"{health}";

        GameManager.Instance.OnScoreChanged += score => scoreText.text = $"{score}";
    }
}