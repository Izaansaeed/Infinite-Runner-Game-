using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    void Start()
    {
        if (restartButton != null)
        {
            Text restartButtonText = restartButton.GetComponentInChildren<Text>();
            if (restartButtonText != null)
            {
                restartButtonText.text = "Restart";
            }
            else
            {
                Debug.LogError("Text component not found in the restart button.");
            }
        }
        else
        {
            Debug.LogError("Restart button reference is not assigned in the Inspector.");
        }

        if (quitButton != null)
        {
            Text quitButtonText = quitButton.GetComponentInChildren<Text>();
            if (quitButtonText != null)
            {
                quitButtonText.text = "Quit";
            }
            else
            {
                Debug.LogError("Text component not found in the quit button.");
            }
        }
        else
        {
            Debug.LogError("Quit button reference is not assigned in the Inspector.");
        }

        HideRestartButton();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void HideRestartButton()
    {
        restartButton.gameObject.SetActive(false);
    }
}
