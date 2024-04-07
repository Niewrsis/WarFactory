using UnityEngine;

public class SetActiveMainScere : MonoBehaviour
{
    [SerializeField] private GameObject _skilTreeScren;

    private void Awake()
    {
        _skilTreeScren.SetActive(false);
    }
}
