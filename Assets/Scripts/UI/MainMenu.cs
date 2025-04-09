using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    InputAction pauseToggle;
    public GameObject menu;
    Scene scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        //locks cursor 
        pauseToggle = InputSystem.actions.FindAction("Pause");
        if (scene.buildIndex != 0)
        {
            
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseToggle.WasPressedThisFrame())
        {
            if (Time.timeScale <= 0.5)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    //resumes game
    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    //starts game form start menu
    public void PlayGame()
    {
     
        SceneManager.LoadScene(1);
    }
    
    //quits game
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    //opens options menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menu.SetActive(false);
    }

}
