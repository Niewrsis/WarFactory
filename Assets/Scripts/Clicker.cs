using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Button _clickerZone;
    private int _clickIncome = 1;
    private ResourceBank _resourceBank;

    private void Start()
    {
        _clickerZone.onClick.AddListener(ClickerMethod);
    }

    private void ClickerMethod()
    {
        _resourceBank.Money += _clickIncome;
    }
    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
