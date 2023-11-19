using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string HIGH_SCORE_FILE_PATH = "/high_score_data.json";
    private static ScoreManager INSTANCE = null;

    public static ScoreManager GetInstance()
    {
        return INSTANCE;
    }

    private string highScorePersistentPath;
    private string currentName = "";
    private HighScoreData highScoreData;

    private void Awake()
    {
        if (INSTANCE != null)
        {
            return;
        }

        highScorePersistentPath = Application.persistentDataPath + HIGH_SCORE_FILE_PATH;
        ReadHighScore();
        INSTANCE = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentName(string name)
    {
        this.currentName = name;
    }

    public string GetCurrentName()
    {
        return currentName;
    }

    public void NotifyFinalScore(int score)
    {
        if (score > highScoreData.score)
        {
            highScoreData = new HighScoreData(currentName, score);
            File.WriteAllText(highScorePersistentPath, JsonUtility.ToJson(highScoreData));
        }
    }

    public HighScoreData GetHighScoreData()
    {
        return highScoreData;
    }

    private void ReadHighScore()
    {
        if (File.Exists(highScorePersistentPath))
        {
            highScoreData = JsonUtility.FromJson<HighScoreData>(File.ReadAllText(highScorePersistentPath));
        } else
        {
            highScoreData = new HighScoreData("", 0);
        }
    }
}
