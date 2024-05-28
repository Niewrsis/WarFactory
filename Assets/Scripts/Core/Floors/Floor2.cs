using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Floor2 : MonoBehaviour
{
    private ResourceBank _resourceBank;

    #region Referenses
    [SerializeField] private Button _clickButton;
    [SerializeField] private Button _upgradePowerButton;
    [SerializeField] private Button _upgradeTimerButton;
    [SerializeField] private TextMeshProUGUI _costPowerText;
    [SerializeField] private TextMeshProUGUI _costTimerText;
    [SerializeField] private TextMeshProUGUI _clickPowerText;
    [SerializeField] private GameObject _timerText;
    [SerializeField] private Image _fillBar;
    #endregion

    #region Settings
    [SerializeField] private float _clickPower = 1;
    [SerializeField] private float _upgradePowerCost = 10;
    [SerializeField] private float _upgradeTimerCost = 10;
    [SerializeField] private float _upgradePowerPercent = .2f;
    [SerializeField] private float _upgradeTimerPercent = .2f;
    [SerializeField] private float _timer = 5;
    [SerializeField] private int _upgradePowerPower = 1;
    [SerializeField] private int _upgradeTimerPower = 1;
    #endregion

    #region Saving
    private float _clickPowerEXTRA;
    private float _upgradePowerCostEXTRA;
    private float _upgradeTimerCostEXTRA;
    private float _upgradePowerPercentEXTRA;
    private float _upgradeTimerPercentEXTRA;
    private float _timerEXTRA;
    #endregion

    private float _money;
    private int _multiplier;
    private float _timerExtra;
    private bool _isActive = false;
    private bool _isPasiveIncome = false;

    private void Start()
    {
        _multiplier = PlayerPrefs.GetInt("Multiplier");

        _clickPowerEXTRA = _clickPower;
        _upgradePowerCostEXTRA = _upgradePowerCost;
        _upgradeTimerCostEXTRA = _upgradeTimerCost;
        _upgradePowerPercentEXTRA = _upgradePowerPercent;
        _upgradeTimerPercentEXTRA = _upgradeTimerPercent;
        _timerEXTRA = _timer;

        RebirthScript.OnRebirth += Rebirth;

        _timerExtra = _timer;

        _clickPowerText.text = $"{_clickPower}$";
        _timerText.SetActive(false);

        _costPowerText.text = $"{Mathf.RoundToInt(_upgradePowerCost)}$";
        _costTimerText.text = $"{Mathf.RoundToInt(_upgradeTimerCost)}$";

        _clickButton.onClick.AddListener(Clicked);
        _upgradePowerButton.onClick.AddListener(UpgradePower);
        _upgradeTimerButton.onClick.AddListener(UpgradeTimer);
    }
    private void Update()
    {
        _money = _resourceBank.Money;
        _multiplier = PlayerPrefs.GetInt("Multiplier");
    }
    private void Clicked()
    {
        if (_isActive) return;

        StartCoroutine(ClickedCor());
    }
    IEnumerator ClickedCor()
    {
        _isActive = true;
        _timerText.SetActive(true);
        for (float i = _timer; i > 0; i--)
        {
            _timer--;
            _timerText.GetComponent<TextMeshProUGUI>().text = $"{Mathf.RoundToInt(i)} sec.";
            yield return new WaitForSeconds(1);
            _fillBar.fillAmount -= 1 / _timerExtra;
        }
        _timerText.SetActive(false);
        _resourceBank.Money += _clickPower * _multiplier;
        _timer = _timerExtra;
        _fillBar.fillAmount = 1;
        _isActive = false;
    }
    private void UpgradePower()
    {
        if (_money >= _upgradePowerCost)
        {
            _resourceBank.Money -= _upgradePowerCost;
            _upgradePowerCost += _upgradePowerCost * _upgradePowerPercent;
            _costPowerText.text = $"{Mathf.RoundToInt(_upgradePowerCost)}$";
            _clickPower += _upgradePowerPower;
            _clickPowerText.text = $"{_clickPower}$";
        }
    }
    private void UpgradeTimer()
    {
        if (_isPasiveIncome == true) return;

        if (_money >= _upgradeTimerCost)
        {
            _resourceBank.Money -= _upgradeTimerCost;
            _upgradeTimerCost += _upgradeTimerCost * _upgradeTimerPercent;
            _costTimerText.text = $"{Mathf.RoundToInt(_upgradeTimerCost)}$";
            _timer -= _upgradeTimerPower;
            _timerExtra = _timer;
            if (_timer <= 1)
            {
                StartCoroutine(PassiveIncome());
                _isPasiveIncome = true;
                _costTimerText.text = "";
                _timerText.SetActive(true);
                _timerText.GetComponent<TextMeshProUGUI>().text = $"Auto";
                _upgradeTimerButton.enabled = false;
                _clickButton.enabled = false;
            }
        }
    }
    IEnumerator PassiveIncome()
    {
        while (_isPasiveIncome)
        {
            _resourceBank.Money += _clickPower * _multiplier;
            yield return new WaitForSeconds(1);
        }
    }

    private void Rebirth()
    {
        _clickPower = _clickPowerEXTRA;
        _upgradePowerCost = _upgradePowerCostEXTRA;
        _upgradeTimerCost = _upgradeTimerCostEXTRA;
        _upgradePowerPercent = _upgradePowerPercentEXTRA;
        _upgradeTimerPercent = _upgradeTimerPercentEXTRA;
        _timerExtra = _timerEXTRA;
        _isPasiveIncome = false;
        _upgradeTimerButton.enabled = true;
        _clickButton.enabled = true;
    }    
    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
