using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Toggler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    
    public void ToggleVolume(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _masterMixer.audioMixer.SetFloat("Master", 0);
        }
        else
        {
            _masterMixer.audioMixer.SetFloat("Master", -80);
        }
    }
}