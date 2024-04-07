using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    [SerializeField] private TextMeshProUGUI _moneyFieldTree;

    [SerializeField] private TextMeshProUGUI _moneyFieldEconomy;
    [SerializeField] private TextMeshProUGUI _gen1FieldEconomy;
    [SerializeField] private TextMeshProUGUI _gen2FieldEconomy;
    [SerializeField] private TextMeshProUGUI _gen3FieldEconomy;
    [SerializeField] private TextMeshProUGUI _gen4FieldEconomy;

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
        _gen1FieldEconomy.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _gen2FieldEconomy.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _gen3FieldEconomy.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _gen4FieldEconomy.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);

        _moneyFieldMillitary.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
        _moneyFieldTech.text = StringNumbersFormatter.FormatNumber(_resourceBank.Money);
    }
}
