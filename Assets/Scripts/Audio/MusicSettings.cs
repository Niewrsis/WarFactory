using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private int _musicVolume;

    private void Start()
    {
        _musicVolume = PlayerPrefs.GetInt("MasterVolume", _musicVolume);
    }

    public void MusicVolumeChange()
    {
        PlayerPrefs.SetInt("MasterVolume", _musicVolume);
    }
}