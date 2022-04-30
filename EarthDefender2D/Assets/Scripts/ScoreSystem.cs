using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void UpdateScore(int pointsToAdd)
    {
        scoreText.text = (int.Parse(scoreText.text) + pointsToAdd).ToString();
    }
}
