using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;

    /**** Play Scene Components ****/
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject scoreObject;
    TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject valueObject;
    TextMeshProUGUI valueText;

    /**** Score Canvas Components ****/
    TextMeshProUGUI finalScoreText;
    TextMeshProUGUI highScoreText;


    private void Start()
    {
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        valueText = valueObject.GetComponent<TextMeshProUGUI>();
    }

    /**** Button Functions ****/
    public void StartGame()
    {
        gameplayManager.StartGame();
        startButton.SetActive(false);
    }

    public void ReplayGame()
    {
        gameplayManager.ReplayGame();
    }

    /**** Score Functions ****/
    public void UpdateScore(int updatedScore)
    {
        scoreText.text = updatedScore.ToString(); 
    }

    public void UpdateValue(int updatedValue)
    {
        valueText.text = "=" + updatedValue.ToString();
    }

    public void ShowFinalScore(int finalScore, int highScore)
    {
        finalScoreText = GameObject.Find("PlayerScoreValue").GetComponent<TextMeshProUGUI>();
        finalScoreText.text = finalScore.ToString();

        highScoreText = GameObject.Find("HighScoreValue").GetComponent<TextMeshProUGUI>();
        highScoreText.text = highScore.ToString();
    }
}
