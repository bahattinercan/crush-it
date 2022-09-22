using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text finalScoreText;

    public void SetupPanel(bool isPlayerWin, int finalScore)
    {
        if (isPlayerWin)
            titleText.text = "Win!";
        else
            titleText.text = "Lose!";

        finalScoreText.text = "Score:" + finalScore;
    }
}