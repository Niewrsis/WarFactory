using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    private ResourceBank _resourceBank;

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }

    void Update()
    {
        _moneyField.text = _resourceBank.Money.ToString();
    }
}
