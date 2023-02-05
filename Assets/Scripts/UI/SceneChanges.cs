
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

    public enum Scene
    {
        MainMenu,
        Intro,
        Play,
        Win,
        Credits,
    }

    public void goToScene(Scene scene)
    {
        switch (scene)
        {
            case Scene.MainMenu:
                MainMenuScene();
                break;
            case Scene.Intro:
                IntroScene();
                break;
            case Scene.Play:
                PlayScene();
                break;
            case Scene.Win:
                WinScene();
                break;
            case Scene.Credits:
                CreditsScene();
                break;

        }
    }
}
