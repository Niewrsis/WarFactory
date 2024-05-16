using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    [SerializeField] private GameObject _wideUp, _wideDown;
    private float _transitionTime = 1f;
    private void Awake()
    {
        _wideUp.SetActive(true);
        _wideDown.SetActive(true);
    }
    public IEnumerator LoadLevel(int index)
    {
        Debug.Log("1234");
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(index);
    }
}
