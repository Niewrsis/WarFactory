using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    [SerializeField] private TextMeshProUGUI _moneyFieldTree;
    [SerializeField] private TextMeshProUGUI _moneyFieldEconomy;
    [SerializeField] private TextMeshProUGUI _moneyFieldMillitary;
    [SerializeField] private TextMeshProUGUI _moneyFieldTech;
    private ResourceBank _resourceBank;

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }

    void Update()
    {
        _moneyField.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldTree.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldEconomy.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldMillitary.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldTech.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
    }
}
