using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider sliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = sliderVolume.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", sliderVolume.value);
    }

    private void Load()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
