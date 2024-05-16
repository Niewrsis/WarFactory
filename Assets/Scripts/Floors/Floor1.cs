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
    private int _multiplier;
    [SerializeField] private float _clickPower = 1;
    [SerializeField] private float _upgradeCost = 10;
    [SerializeField] private float _upgradePercent = .2f;

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
            _resourceBank.Money -= (int)_upgradeCost;
            _upgradeCost += _upgradeCost * _upgradePercent;
            _costText.text = $"{Mathf.RoundToInt(_upgradeCost)}$";
            _clickPower += 1;
            _clickPowerText.text = $"{_clickPower}$";
        }
    }
    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
