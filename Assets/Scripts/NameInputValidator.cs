using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameInputValidator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI errorText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    public void Start()
    {
        errorText.enabled = false;
    }

    public void ValidateName()
    {
        string trimmedName = nameText.text.Trim();
        if (trimmedName.Length <= 1)
        {
            errorText.enabled = true;
        } else
        {
            ScoreManager.GetInstance().SetCurrentName(trimmedName);
            // Main scene is set at index 1
            SceneManager.LoadScene(1);
        }
    }
}
