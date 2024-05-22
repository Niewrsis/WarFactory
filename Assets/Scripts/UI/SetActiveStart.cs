using UnityEngine;

public class SetActiveStart : MonoBehaviour
{
    [SerializeField] private GameObject _firstFloor;
    [SerializeField] private GameObject _secondFloor;
    [SerializeField] private GameObject _thirdFloor;
    [SerializeField] private GameObject _fourthFloor;
    [SerializeField] private GameObject _fifthFloor;

    [SerializeField] private GameObject[] _settings;
    private void Start()
    {
        _firstFloor.SetActive(true);
        _secondFloor.SetActive(false);
        _thirdFloor.SetActive(false);
        _fourthFloor.SetActive(false);
        _fifthFloor.SetActive(false);

        for (int i = 0;  i < _settings.Length; i++) _settings[i].SetActive(false);
    }
}
