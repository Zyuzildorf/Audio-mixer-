using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Slider _slider;
    private int _minVolume;
    private int _convertCoefficient;
    private string _mixerGroupName;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _minVolume = -80;
        _convertCoefficient = 20;
        _mixerGroupName = _slider.name;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        _mixerGroupName = _slider.name;

        if (_slider.value == 0)
        {
            _audioMixer.SetFloat(_mixerGroupName, _minVolume);
        }
        else
        {
            _audioMixer.SetFloat(_mixerGroupName, Mathf.Log10(_slider.value) * _convertCoefficient);
        }
    }
}