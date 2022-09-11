using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;

    public Ball ball;
    public StartFocus startFocus;

    public Text computerScoreText;
    public Text playerScoreText;

    private void Start()
    {
        this.ball.Reset();
        StartRound();
    }

    public void PlayerScores() 
    {
        this.ball.Reset();

        _playerScore += 1;
        playerScoreText.text = _playerScore.ToString();

        StartRound();
    }

    public void ComputerScores() 
    {
        this.ball.Reset();

        _computerScore += 1;
        computerScoreText.text = _computerScore.ToString();

        StartRound();
    }

    private void StartRound() 
    {
        startFocus.DisplayFocus();
    }
}
