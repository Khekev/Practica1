using UnityEngine;
using UnityEngine.SceneManagement;

public class ARScreenFunctions : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "MainMenu";
    private BootLoader bootLoader;

    private void Start()
    {
        bootLoader = FindAnyObjectByType<BootLoader>();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(menuSceneName, LoadSceneMode.Single);
    }
    
    public void ChangeBootLoaderInt(int value)
    {
        bootLoader.changeExample(value);
    }
}