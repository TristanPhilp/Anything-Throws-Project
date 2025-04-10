using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   // InputAction pauseToggle;
    public GameObject menu;
    public AudioMixer audioMixer;
    public PlayerController playerController;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;

            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    //resumes game
    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        KeepVariables.volumeFloat = volume;
    }

    //sets fullscreen
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //sets mouseSensX
    public void SetMouseSensitivityX(float senX)
    {
        playerController.horizSensitivity = senX;
        KeepVariables.sensX = senX;
    }

    //sets Mouse SensY
    public void SetMouseSensitivityY(float senY)
    {
        playerController.vertSensitivity = senY;
        KeepVariables.sensY = senY;
    }


    public void SetResolution(int resolutionIndex)
    {

        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

}
