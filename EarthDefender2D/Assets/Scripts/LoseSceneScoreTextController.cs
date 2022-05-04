using TMPro;
using UnityEngine;

public class LoseSceneScoreTextController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI LoseSceneScoreText;

    void Start()
    {
        LoseSceneScoreText.text = ScoreHandler.Score.ToString();
    }
}
