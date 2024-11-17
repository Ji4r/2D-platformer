using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static void LoadScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public static void RestartScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);

        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public static void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
