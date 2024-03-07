using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Button _clickerZone;
    private ResourceBank _resourceBank;

    private void Start()
    {
        _clickerZone.onClick.AddListener(ClickerMethod);
    }

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }

    private void ClickerMethod()
    {
        _resourceBank.Money++;
    }
}
