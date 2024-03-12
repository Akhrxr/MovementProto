using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider Volume;
    bool MuteVol;

    void Start() {

        if (!PlayerPrefs.HasKey("musicVolume")) 
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else 
        {
            Load();
        }
    }


    public void ChangeVolume() 
    {
        if (!MuteVol) 
        {
            AudioListener.volume = Volume.value;
        }
        Save();
    }

    public void Mute(bool Muted)
    {
        MuteVol = Muted;
        if (Muted) 
        {
            AudioListener.volume = 0;
        }
        else 
        {
            AudioListener.volume = Volume.value;
        }
    }
    private void Load()
    {
        Volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", Volume.value);
    }
}
