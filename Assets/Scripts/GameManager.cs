using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

}
