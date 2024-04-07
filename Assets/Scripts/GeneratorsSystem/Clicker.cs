using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] private long _moneyPub;
    [SerializeField] private Button _clickerZone;
    private ResourceBank _resourceBank;

    private void Start()
    {
        _moneyPub += _resourceBank.Money;
        _clickerZone.onClick.AddListener(ClickerMethod);
    }

    private void Update()
    {
        if (_resourceBank.Money != _moneyPub)
        {
            _resourceBank.Money = _moneyPub;
        }
    }

    private void ClickerMethod()
    {
        _moneyPub++;
    }
    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
