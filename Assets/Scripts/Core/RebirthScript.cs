using TMPro;
using UnityEngine;
using UnityEngine.UI;

public delegate void RebirthDel();
public class RebirthScript : MonoBehaviour
{
    private ResourceBank _resourceBank;
    public static event RebirthDel OnRebirth;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _multiplierText;

    [SerializeField] private int _cost;
    private int _multiplier = 1;

    private void Start()
    {
        _costText.text = $"{_cost}$";
        _multiplierText.text = $"x{_multiplier}";
        _button.onClick.AddListener(Rebirth);
    }
    private void Rebirth()
    {
        if (_resourceBank.Money < _cost) return;
        _multiplier++;
        PlayerPrefs.SetInt("Multiplier", _multiplier);
        _costText.text = $"{_cost}$";
        _multiplierText.text = $"x{_multiplier}";
        _resourceBank.Money = 0;
        OnRebirth?.Invoke();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Multiplier", 1);
    }
    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
