using UnityEngine;

public class SetActiveMainScere : MonoBehaviour
{
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _skilTreeScren;
    [SerializeField] private GameObject _economyTreeScreen;
    [SerializeField] private GameObject _millitaryTreeScreen;
    [SerializeField] private GameObject _techTreeScreen;

    private void Awake()
    {
        _mainScreen.SetActive(true);

        _skilTreeScren.SetActive(false);
        _economyTreeScreen.SetActive(false);
        _techTreeScreen.SetActive(false);
        _millitaryTreeScreen.SetActive(false);
    }
}
