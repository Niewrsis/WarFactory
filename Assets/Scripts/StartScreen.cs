using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    public void StartGame() => StartCoroutine(_levelLoader.LoadLevel(1));
    public void ExitGame() => Application.Quit();
}
