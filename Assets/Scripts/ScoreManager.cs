using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager INSTANCE = null;

    public static ScoreManager GetInstance()
    {
        return INSTANCE;
    }

    private string currentName = "";

    private void Awake()
    {
        if (INSTANCE != null)
        {
            return;
        }

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
}
