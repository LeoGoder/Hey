using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
