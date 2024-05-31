using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private GameObject _options;
    [SerializeField] private GameObject _musicSettings;
    //[SerializeField] private GameObject _tutorial;
    private void Start()
    {
        _options.SetActive(false);
        _musicSettings.SetActive(false);
    }
    public void StartGame() => StartCoroutine(_levelLoader.LoadLevel(1));
    public void ExitGame() => Application.Quit();
}
