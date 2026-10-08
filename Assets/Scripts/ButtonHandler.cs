using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private MenuManager menuManager;

    private void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    public void LoadMinigame(string sceneName)
    {
        if (menuManager != null)
            menuManager.LoadMinigame(sceneName);
    }

    public void QuitApp()
    {
        if (menuManager != null)
            menuManager.QuitApp();
    }
}