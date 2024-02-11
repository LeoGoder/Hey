using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public void Start()
    {
        //permet de r�cup�rer les diff�rentes r�solutions possible, la fonction distinct permet d'�viter les doublons
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); 
        resolutionDropdown.ClearOptions();

        //formatage de resolutions pour etre utilisable par AddOption()
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            // get la r�solution la plus adapt� � l'�cran
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                currentResolutionIndex = i;
        }

        //affiche toutes les possibilit� de r�solution
        resolutionDropdown.AddOptions(options);
        //set la r�solution adapt� � l'�cran 
        resolutionDropdown.value = currentResolutionIndex;
        //permet de rafraichir l'affichage du dropdown avec la bonne valeur 
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    // change le niveau de volume de l'audioMixer
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
