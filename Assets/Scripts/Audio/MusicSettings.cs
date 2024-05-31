using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private float _musicVolume;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TextMeshProUGUI _volumePercentText;
    private GameObject _audioSource;
    private void Awake()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Music");
        DontDestroyOnLoad(_audioSource);
    }
    private void Start()
    {
        _musicVolume = PlayerPrefs.GetFloat("MasterVolume", _musicVolume);
        _volumeSlider.value = _musicVolume;
    }

    public void MusicVolumeChange()
    {
        PlayerPrefs.SetFloat("MasterVolume", _musicVolume);
        _musicVolume = _volumeSlider.value;
        _audioSource.GetComponent<AudioSource>().volume = _musicVolume / 100;
        _volumePercentText.text = $"{Mathf.RoundToInt(_musicVolume)}%";
    }
    private void OnApplicationQuit() => PlayerPrefs.SetFloat("MasterVolume", 100f);
}