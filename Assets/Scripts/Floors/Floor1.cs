using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Floor1 : MonoBehaviour
{
    private ResourceBank _resourceBank;

    [SerializeField] private Button _clickButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _clickPowerText;

    private float _money;
    private float _clickPower = 1;
    private float _upgradeCost = 10;
    private int _multiplier;

    private void Start()
    {
        _clickPowerText.text = $"{_clickPower}$";
        _costText.text = $"{Math.Round(_upgradeCost, 1)}$";
        _clickButton.onClick.AddListener(Clicked);
        _upgradeButton.onClick.AddListener(Upgrade);
    }
    private void Update()
    {
        _money = _resourceBank.Money;
        _multiplier = _resourceBank.Multiplier;
    }
    private void Clicked()
    {
        _resourceBank.Money += _clickPower * _multiplier;
    }
    private void Upgrade()
    {
        if (_money >= _upgradeCost)
        {
            _resourceBank.Money -= _upgradeCost;
            _upgradeCost += _upgradeCost * (float).2;
            _costText.text = $"{Math.Round(_upgradeCost, 1)}$";
            _clickPower += 1;
            _clickPowerText.text = $"{_clickPower}$";
        }
    }
    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
