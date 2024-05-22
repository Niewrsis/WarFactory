using UnityEngine;

public class SetActiveStart : MonoBehaviour
{
    [SerializeField] private GameObject _firstFloor;
    [SerializeField] private GameObject[] _floors;

    [SerializeField] private GameObject[] _settings;
    private void Start()
    {
        _firstFloor.SetActive(true);

        for (int i = 0; i < _floors.Length; i++) _floors[i].SetActive(false);
        for (int i = 0;  i < _settings.Length; i++) _settings[i].SetActive(false);
    }
}
