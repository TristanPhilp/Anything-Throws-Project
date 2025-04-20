using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public PlayerController playerController;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public bool isPauseMenuOpen = false;
    //public bool isMainMenu = true;
    InputAction pauseToggle;
    public Slider SliderY;
    public Slider SliderX;
    public Slider VolumeSlider;
    public Toggle FullScreenToggle;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        pauseToggle = InputSystem.actions.FindAction("Pause");
        Cursor.lockState = CursorLockMode.Locked;

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height )
            {
                currentResolutionIndex = i;
            
            }
        }

        resolutionDropdown.AddOptions(options);
       //resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetMouseSensitivityY();
        SetMouseSensitivityX();
        SetVolume();
        
        //SetFullScreen();
    }

    //updates pause menu
    public void Update()
    {
        

        if (pauseToggle.WasPressedThisFrame())
        {

            isPauseMenuOpen = !isPauseMenuOpen;
            if (isPauseMenuOpen == true)
            {
                
                Pause();
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
        
                
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    //pauses game
    void Pause()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPauseMenuOpen = true;
    }

    //resumes game
    public void Resume()
    {
        
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        Time.timeScale = 1;
        isPauseMenuOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //returns to menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    //sets volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        KeepVariables.volumeFloat = volume;
    }

    public void SetVolume()
    {
        VolumeSlider.value = KeepVariables.volumeFloat;
    }

    //sets fullscreen
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        KeepVariables.fullScreen = isFullScreen;
    }

    /**public void SetFullScreen()
    {
        if (KeepVariables.fullScreen == true)
            FullScreenToggle.isOn = true;
        else
            FullScreenToggle.isOn = false;
    }**/

    //sets mouseSensX
    public void SetMouseSensitivityX(float senX)
    {
        KeepVariables.sensX = senX;
        playerController.horizSensitivity = senX;
    }

    public void SetMouseSensitivityX()
    {
        SliderX.value = KeepVariables.sensX;
    }

    //sets Mouse SensY
    public void SetMouseSensitivityY(float senY)
    {
        playerController.vertSensitivity = senY;
        KeepVariables.sensY = playerController.vertSensitivity;
    }

    public void SetMouseSensitivityY()
    {
        SliderY.value = KeepVariables.sensY;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
}
