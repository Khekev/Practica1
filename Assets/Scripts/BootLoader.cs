using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "MainMenu";
    [SerializeField] private int example;

    private void Awake()
    {
        // Prevent duplicates if this somehow gets instantiated again
        if (FindObjectsOfType<BootLoader>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Load the menu scene after boot
        SceneManager.LoadSceneAsync(menuSceneName, LoadSceneMode.Single);
    }

    public void changeExample(int exampleNum)

    { 
        example = exampleNum;
    }
}