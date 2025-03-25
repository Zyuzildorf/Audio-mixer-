using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _soundsMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;

    public void ChangeMasterVolume(Slider slider)
    {
        _masterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(slider.value) * 20);
    }

    public void ChangeSoundButtonsVolume(Slider slider)
    {
        _soundsMixer.audioMixer.SetFloat("SoundsVolume", Mathf.Log10(slider.value) * 20);
    }

    public void ChangeBackgroundMusicVolume(Slider slider)
    {
        _musicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(slider.value) * 20);
    }
    
    public void ToggleVolume(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _musicMixer.audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            _musicMixer.audioMixer.SetFloat("MasterVolume", -79);
        }
    }
}