using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanelTitle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMP_Dropdown resolutionsDropdown;

    public static float musicVolume = 0.5f;
    public static float sfxVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //set the sliders to a value so they dont default to 1
        if (sfxSlider != null) sfxSlider.value = sfxVolume;
        if (musicSlider != null) musicSlider.value = musicVolume;

        //if we have resolutions
        if (resolutionsDropdown)
        {
            //fill the dropdown menu with the resolutions
            resolutionsDropdown.ClearOptions();
            List<string> resoStrings = new List<string>();
            foreach (var res in Screen.resolutions)
            {
                resoStrings.Add(res.width + "x" + res.height);
            }
            resolutionsDropdown.AddOptions(resoStrings);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //change volume if slider has changed
        if (sfxSlider != null) sfxVolume = sfxSlider.value;
        if (musicSlider != null) musicVolume = musicSlider.value;
    }

    public void ToggleSettingsPanelTitle()
    {
        settingsPanelTitle.SetActive(!settingsPanelTitle.activeSelf);
    }

    public void ChangeResolution()
    {
        Screen.SetResolution(Screen.resolutions[resolutionsDropdown.value].width, Screen.resolutions[resolutionsDropdown.value].height, false);
    }
}
