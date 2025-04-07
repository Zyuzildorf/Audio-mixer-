using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void ChangeVolume(Slider slider)
    {
        string mixerGroupName = slider.name;
        
        if (slider.value == 0)
        {
            _audioMixer.SetFloat(mixerGroupName, -80);
        }
        else
        {
            _audioMixer.SetFloat(mixerGroupName, Mathf.Log10(slider.value) * 20);
        }
    }
}