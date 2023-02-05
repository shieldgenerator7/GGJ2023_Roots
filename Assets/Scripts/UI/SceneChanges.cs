
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void WinScene()
    {
        SceneManager.LoadScene("win");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
