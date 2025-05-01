using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Toggler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private VolumeSettings _masterVolumeSettings;

    private bool _isMuted = false;
    private Toggle _toggle;

    public bool IsMuted => _isMuted;
    public event Action Muted; 
    public event Action Unmuted; 
    
    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleVolume);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleVolume);
    }

    public void ToggleVolume(bool isOn)
    {
        if (isOn)
        {
            _isMuted = false;
            Unmuted?.Invoke();
        }
        else
        {
            _isMuted = true;
            Muted?.Invoke();
        }
    }
}