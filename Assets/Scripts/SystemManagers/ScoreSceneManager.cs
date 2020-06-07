using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreSceneManager : MonoBehaviour
{
    private ScoringControl scoringControl;
    private UIManager uiManager;

    [SerializeField]
    private Button replayButton;


    private void Start()
    {
        GameObject systemManagers = GameObject.Find("SystemManagers");
        scoringControl = systemManagers.GetComponent<ScoringControl>();
        uiManager = systemManagers.GetComponent<UIManager>();

        replayButton.onClick.AddListener(uiManager.ReplayGame);

        SetScores();
    }

    void SetScores()
    {
        int playerScore = scoringControl.currentScore;
        int highScore = GetHighScore(playerScore);

        uiManager.ShowFinalScore(playerScore, highScore);
    }

    private int GetHighScore(int playerScore)
    {
        int highScore = 0;
        bool newHighScore = false;
        bool fileExists = File.Exists(Application.persistentDataPath + "/HighScore.json");

        //If file exists, check if the new score is higher than old high score
        if (fileExists)
        {
            string highScoreText = System.IO.File.ReadAllText(Application.persistentDataPath + "/HighScore.json");
            HighScoreData oldScoreData = JsonUtility.FromJson<HighScoreData>(highScoreText);
            int oldHighScore = oldScoreData.highScore;

            if (playerScore > oldHighScore)
            {
                newHighScore = true;
            }
            else
            {
                highScore = oldHighScore;
            }
        }
        if (!fileExists || newHighScore)
        {
            highScore = SaveHighScore(playerScore);
        }

        return highScore;
    }

    public int SaveHighScore(int highScore)
    {
        HighScoreData highScoreData = new HighScoreData(highScore);
        string dataText = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/HighScore.json", dataText);

        return highScore;
    }
}
