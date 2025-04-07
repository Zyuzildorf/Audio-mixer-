using UnityEngine;
using UnityEngine.UI;

public class ButtonsSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void OnButtonPressed(Button button)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.Play();
    }
}