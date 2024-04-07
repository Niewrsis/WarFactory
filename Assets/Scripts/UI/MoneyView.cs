using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    [SerializeField] private TextMeshProUGUI _moneyFieldTree;
    private ResourceBank _resourceBank;

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }

    void Update()
    {
        _moneyField.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldTree.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
    }
}
