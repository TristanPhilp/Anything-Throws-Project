using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SaveScene()
    {

        PlayerPrefs.SetInt("SceneSaved", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SaveSystem.SaveScene(SceneManager.GetSceneByBuildIndex(1));
    }
    
    public void LoadScene()
    {
        Save data = SaveSystem.LoadScene();

    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerScene(Scene scene)
    { 
    
    }

    public void SaveNextScene()
    {

        PlayerPrefs.SetInt("SceneSaved", SceneManager.GetActiveScene().buildIndex + 1);

    }

    


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
