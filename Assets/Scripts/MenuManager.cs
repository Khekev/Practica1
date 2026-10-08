using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        LoadAppropriateMenu();
    }

    private void LoadAppropriateMenu()
    {
        // 16:9    ~ 0.5625
        // 4:3     ~ 0.75
        // 448:207 ~ 0.4621
        float aspectRatio = (float)Screen.width / Screen.height;

        if (aspectRatio < 0.5f)
            SceneManager.LoadSceneAsync("MainMenuLarge", LoadSceneMode.Additive);
        else if (aspectRatio < 0.6f)
            SceneManager.LoadSceneAsync("MainMenuPhones", LoadSceneMode.Additive);
        else
            SceneManager.LoadSceneAsync("MainMenuTablets", LoadSceneMode.Additive);
    }

    public void LoadMinigame(string sceneName)
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        if (aspectRatio < 0.5f)
            SceneManager.UnloadSceneAsync("MainMenuLarge");
        else if (aspectRatio < 0.6f)
            SceneManager.UnloadSceneAsync("MainMenuPhones");
        else
            SceneManager.UnloadSceneAsync("MainMenuTablets");

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}