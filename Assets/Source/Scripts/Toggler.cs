using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Toggler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;

    private const string MasterMixerGroup = "Master";

    private Toggle _toggle;
    private int _maxVolume;
    private int _minVolume;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _maxVolume = 0;
        _minVolume = -80;
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(delegate { ToggleVolume(); });
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(delegate { ToggleVolume(); });
    }

    public void ToggleVolume()
    {
        if (_toggle.isOn)
        {
            _masterMixer.audioMixer.SetFloat(MasterMixerGroup, _maxVolume);
        }
        else
        {
            _masterMixer.audioMixer.SetFloat(MasterMixerGroup, _minVolume);
        }
    }
}