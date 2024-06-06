using TMPro;
using UnityEngine;

public class FloorsChanging : MonoBehaviour
{
    private ResourceBank _resourceBank;

    [SerializeField] private GameObject[] _floors;
    [SerializeField] private TextMeshProUGUI _floorsText;
    private int _floorsIndex = 0;

    #region LockSystem
    [SerializeField] private LockSystem[] _lockOptions;

    private bool _isLocked2 = true;
    private bool _isLocked3 = true;
    private bool _isLocked4 = true;
    private bool _isLocked5 = true;
    #endregion

    private void Start()
    {
        RebirthScript.OnRebirth += Rebirth;

        for (int i = 1; i < _lockOptions.Length; i++) 
            _lockOptions[i].CostText.text = $"{Formatter.FormatNumberToString(_lockOptions[i].Cost)}$";

        _lockOptions[0].Button.onClick.AddListener(Locked2);
        _lockOptions[1].Button.onClick.AddListener(Locked3);
        _lockOptions[2].Button.onClick.AddListener(Locked4);
        _lockOptions[3].Button.onClick.AddListener(Locked5);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) & _floorsIndex != _floors.Length - 1) ChangeUp();
        if (Input.GetKeyDown(KeyCode.DownArrow) & _floorsIndex != 0) ChangeDown();
    }
    public void ChangeUp()
    {
        _floors[_floorsIndex].SetActive(false);
        _floorsIndex++;
        _floors[_floorsIndex].SetActive(true);
        FloorsText(_floorsIndex);
        if (_floorsIndex == 0) return;
        CheckLock(_floorsIndex - 1);
    }
    public void ChangeDown()
    {
        _floors[_floorsIndex].SetActive(false);
        _floorsIndex--;
        _floors[_floorsIndex].SetActive(true);
        FloorsText(_floorsIndex);
        CheckLock(_floorsIndex - 1);
    }
    private void FloorsText(int index)
    {
        switch (index)
        {
            case 0:
                _floorsText.text = "I";
                break;
            case 1:
                _floorsText.text = "II";
                break;
            case 2:
                _floorsText.text = "III";
                break;
            case 3:
                _floorsText.text = "IV";
                break;
            case 4:
                _floorsText.text = "V";
                break;
        }
    }
    private void CheckLock(int index)
    {
        switch (index)
        {
            case 0:
                 _lockOptions[index].Unlocked.SetActive(_isLocked2 != true);
                 _lockOptions[index].Locked.SetActive(_isLocked2 == true);
                break;
            case 1:
                 _lockOptions[index].Unlocked.SetActive(_isLocked3 != true);
                 _lockOptions[index].Locked.SetActive(_isLocked3 == true);
                break;
            case 2:
                 _lockOptions[index].Unlocked.SetActive(_isLocked4 != true);
                 _lockOptions[index].Locked.SetActive(_isLocked4 == true);
                break;
            case 3:
                 _lockOptions[index].Unlocked.SetActive(_isLocked5 != true);
                 _lockOptions[index].Locked.SetActive(_isLocked5 == true);
                break;
        }
    }
    private void Locked2()
    {
        if (_resourceBank.Money < _lockOptions[0].Cost) return;

        else if (_resourceBank.Money >= _lockOptions[0].Cost)
        {
            _resourceBank.Money -= _lockOptions[0].Cost;
            _isLocked2 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked3() 
    {
        if (_resourceBank.Money < _lockOptions[1].Cost) return;
        else if (_resourceBank.Money >= _lockOptions[1].Cost)
        {
            _resourceBank.Money -= _lockOptions[1].Cost;
            _isLocked3 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked4() 
    {
        if (_resourceBank.Money < _lockOptions[2].Cost) return;
        else if (_resourceBank.Money >= _lockOptions[2].Cost)
        {
            _resourceBank.Money -= _lockOptions[2].Cost;
            _isLocked4 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked5() 
    {
        if (_resourceBank.Money < _lockOptions[3].Cost) return;
        else if (_resourceBank.Money >= _lockOptions[3].Cost)
        {
            _resourceBank.Money -= _lockOptions[3].Cost;
            _isLocked5 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Rebirth()
    {
        _isLocked2 = true;
        _isLocked3 = true;
        _isLocked4 = true;
        _isLocked5 = true;

        _floorsIndex = 0;
        FloorsText(_floorsIndex);

        for (int i = 1; i < _floors.Length; i++)
            _floors[i].SetActive(false);

        _floors[0].SetActive(true);

        for (int i = 1; i < _lockOptions.Length; i++)
            _lockOptions[i].CostText.text = $"{Formatter.FormatNumberToString(_lockOptions[i].Cost)}$";
    }
    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
