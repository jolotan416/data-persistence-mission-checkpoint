using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

# if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameErrorText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    public void Start()
    {
        nameErrorText.enabled = false;
    }

    public void ValidateName()
    {
        string trimmedName = nameText.text.Trim();
        if (trimmedName.Length <= 1)
        {
            nameErrorText.enabled = true;
        } else
        {
            ScoreManager.GetInstance().SetCurrentName(trimmedName);
            // Main scene is set at index 1
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
