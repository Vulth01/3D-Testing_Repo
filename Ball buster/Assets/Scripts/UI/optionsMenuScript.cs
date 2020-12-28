using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionsMenuScript : MonoBehaviour
{
    public SoundClass soundClassInitialiser;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Slider VolumeSlider;
    Resolution[] resolutions;//istantiating an array of tyoe resolution

    void Start()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));//setting the playerprefs volume from the last session to the current
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");



        qualityDropdown.value = PlayerPrefs.GetInt("QualityIndex");//setting the dropdown to the playerprefs from last session
        if (PlayerPrefs.GetInt("QualityIndex") == 100)// default will return as 100 if it doesnt have a value 
        {
            PlayerPrefs.SetInt("QualityIndex", 2);//sets the playerprefs to the default index (High) in the project settings 
            qualityDropdown.value = 2;// setting the default value of the dropdown to be the default in the project settings
        }



        resolutions = Screen.resolutions;// making the arrays elements = to the screens display informations resolution options
        resolutionDropdown.ClearOptions();//clearing the dropdowns options
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();//create a new list of strings to store the resolutions to add them to the uiDropdown
        for (int i = 0; i < resolutions.Length; i++)// loop the length of the array 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;// make a new string to save the newly formatted resolution option
            options.Add(option);// add the temporary option to the list
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }


        }


        resolutionDropdown.AddOptions(options);//assin the options in the list to the dropdown
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void setResolutionFunction(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); // we dont do this because we made our own class system to play audio that bypasses audioMixers
        PlayerPrefs.DeleteKey("Volume");//deleting the previous playerprefs volume key
        PlayerPrefs.SetFloat("Volume", volume);//using playerprefs to save the players selected volume

    }
    public void SetGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);//setting the quality level to the dropbox index 
        PlayerPrefs.DeleteKey("QualityIndex");
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);

    }
    public void SetFullscreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;

    }
}
