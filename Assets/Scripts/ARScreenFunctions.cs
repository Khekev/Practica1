using UnityEngine;
using UnityEngine.SceneManagement;

public class ARScreenFunctions : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "MainMenu";

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(menuSceneName, LoadSceneMode.Single);
    }
}