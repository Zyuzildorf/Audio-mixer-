using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(delegate { OnButtonPressed(); });
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(delegate { OnButtonPressed(); });
    }

    public void OnButtonPressed()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.Play();
    }
}