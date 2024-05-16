using TMPro;
using UnityEngine;
public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    private ResourceBank _resourceBank;

    void Update()
    {
        _moneyField.text = Formatter.FormatNumberToString(_resourceBank.Money) + "$";
    }

    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
