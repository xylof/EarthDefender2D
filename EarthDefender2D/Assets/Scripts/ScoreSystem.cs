using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public int Score
    {
        get { return int.Parse(scoreText.text); }
    }

    public void UpdateScore(int pointsToAdd)
    {
        scoreText.text = (int.Parse(scoreText.text) + pointsToAdd).ToString();
        UpdateScoreTextColor();
    }

    private void UpdateScoreTextColor()
    {
        if (int.Parse(scoreText.text) > 0)
            scoreText.color = Color.yellow;
        else if (int.Parse(scoreText.text) == 0)
            scoreText.color = Color.white;
        else
            scoreText.color = Color.red;
    }
}
