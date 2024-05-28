using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static RebirthScript;

public class Floor1 : MonoBehaviour
{
    private ResourceBank _resourceBank;

    #region Referenses
    [SerializeField] private Button _clickButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _clickPowerText;
    #endregion

    private float _money;
    private int _multiplier;

    #region Settings
    [SerializeField] private float _clickPower = 1;
    [SerializeField] private float _upgradeCost = 10;
    [SerializeField] private float _upgradePercent = .2f;
    #endregion

    #region Saving
    private float _clickPowerEXTRA;
    private float _upgradeCostEXTRA;
    private float _upgradePercentEXTRA;
    #endregion

    private void Awake()
    {
        _clickPowerEXTRA = _clickPower;
        _upgradeCostEXTRA = _upgradeCost;
        _upgradePercentEXTRA = _upgradePercent;
    }
    private void Start()
    {
        RebirthScript.OnRebirth += Rebirth;

        _clickPowerText.text = $"{_clickPower}$";
        _costText.text = $"{Math.Round(_upgradeCost, 1)}$";
        _clickButton.onClick.AddListener(Clicked);
        _upgradeButton.onClick.AddListener(Upgrade);
    }
    private void Update()
    {
        _money = _resourceBank.Money;
        _multiplier = PlayerPrefs.GetInt("Multiplier");
    }
    private void Clicked() => _resourceBank.Money += _clickPower * _multiplier;
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

    private void Rebirth()
    {
        _clickPower = _clickPowerEXTRA;
        _upgradeCost = _upgradeCostEXTRA;
        _upgradePercent = _upgradePercentEXTRA;

        _costText.text = $"{Mathf.RoundToInt(_upgradeCost)}$";
        _clickPowerText.text = $"{_clickPower}$";
    }
    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
