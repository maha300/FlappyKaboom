using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float interval = 5f;
    public int scorePerTick = 10;
    public FishDeath fish;

    private int score = 0;

    void Start()
    {
        InvokeRepeating(nameof(AddScore), interval, interval);
        scoreText.text = "0";
    }

    void AddScore()
    {
        if (!fish.isDead)
        {
            score += scorePerTick;
            scoreText.text = score.ToString();
        }
    }
}

