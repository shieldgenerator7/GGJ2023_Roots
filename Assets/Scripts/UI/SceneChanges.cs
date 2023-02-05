
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
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
        SceneManager.LoadScene("Cerdits");
    }
}
