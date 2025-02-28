using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    InputAction pauseToggle;
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locks cursor 
        //Cursor.lockState = CursorLockMode.Locked; Doesn't work. Why?
        pauseToggle = InputSystem.actions.FindAction("Pause");
        Pause();
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

    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
