using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;

    public Ball ball;
    public StartFocus startFocus;

    public TextMeshProUGUI computerScoreText;
    public TextMeshProUGUI playerScoreText;
    public AudioSource goalSoundEffect;

    private void Start()
    {
        this.ball.Reset();
        StartRound();
    }

    public void PlayerScores() 
    {
        goalSoundEffect.Play();
        this.ball.Reset();

        _playerScore += 1;
        playerScoreText.text = _playerScore.ToString();
        StartCoroutine(Flicker(playerScoreText));

        if(_playerScore >= 5)
        {
            StartCoroutine(WaitAndShowScene("WinningScreen"));
        }
        else
        {
            StartRound();
        }
    }

    public void ComputerScores() 
    {

        goalSoundEffect.Play();
        this.ball.Reset();

        _computerScore += 1;
        computerScoreText.text = _computerScore.ToString();
        StartCoroutine(Flicker(computerScoreText));

        if(_computerScore >= 5)
        {
            StartCoroutine(WaitAndShowScene("LosingScreen"));
        }
        else
        {
            StartRound();
        }
    }

    private void StartRound() 
    {
        startFocus.DisplayFocus();
    }

    private void Update()
    {
        
    }

    private IEnumerator Flicker(TextMeshProUGUI textObject)
    {
        for(int i = 0; i < 4; i++) {
            textObject.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            textObject.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private IEnumerator WaitAndShowScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
