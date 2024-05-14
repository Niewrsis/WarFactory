using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorsChanging : MonoBehaviour
{
    private ResourceBank _resourceBank;

    [SerializeField] private GameObject[] _floors;
    [SerializeField] private TextMeshProUGUI _floorsText;
    private int _floorsIndex = 0;

    #region LockSystem
    [SerializeField] private GameObject[] _locked;
    [SerializeField] private GameObject[] _unlocked;
    [SerializeField] private Button[] _button;
    [SerializeField] private TextMeshProUGUI[] _costText;
    [SerializeField] private int[] _cost;

    private bool _isLocked2 = true;
    private bool _isLocked3 = true;
    private bool _isLocked4 = true;
    private bool _isLocked5 = true;
    #endregion

    private void Start()
    {
        for (int i = 1; i < _locked.Length; i++)
        {
            _costText[i].text = $"{_cost[i]}$";
        }

        _button[0].onClick.AddListener(Locked2);
        _button[1].onClick.AddListener(Locked3);
        _button[2].onClick.AddListener(Locked4);
        _button[3].onClick.AddListener(Locked5);
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
        CheckLock(_floorsIndex);
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
                if (_isLocked2 == true)
                {
                    _unlocked[index].SetActive(false);
                    _locked[index].SetActive(true);
                }
                else
                {
                    _locked[index].SetActive(false);
                    _unlocked[index].SetActive(true);
                }
                break;
            case 1:
                if (_isLocked3 == true)
                {
                    _unlocked[index].SetActive(false);
                    _locked[index].SetActive(true);
                }
                else
                {
                    _locked[index].SetActive(false);
                    _unlocked[index].SetActive(true);
                }
                break;
            case 2:
                if (_isLocked4 == true)
                {
                    _unlocked[index].SetActive(false);
                    _locked[index].SetActive(true);
                }
                else
                {
                    _locked[index].SetActive(false);
                    _unlocked[index].SetActive(true);
                }
                break;
            case 3:
                if (_isLocked5 == true)
                {
                    _unlocked[index].SetActive(false);
                    _locked[index].SetActive(true);
                }
                else
                {
                    _locked[index].SetActive(false);
                    _unlocked[index].SetActive(true);
                }
                break;
        }
    }
    private void Locked2()
    {
        if (_resourceBank.Money < _cost[0]) return;
        else if (_resourceBank.Money >= _cost[0])
        {
            _resourceBank.Money -= _cost[0];
            _isLocked2 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked3() 
    {
        if (_resourceBank.Money < _cost[1]) return;
        else if (_resourceBank.Money >= _cost[1])
        {
            _resourceBank.Money -= _cost[1];
            _isLocked3 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked4() 
    {
        if (_resourceBank.Money < _cost[2]) return;
        else if (_resourceBank.Money >= _cost[2])
        {
            _resourceBank.Money -= _cost[2];
            _isLocked4 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    private void Locked5() 
    {
        if (_resourceBank.Money < _cost[3]) return;
        else if (_resourceBank.Money >= _cost[3])
        {
            _resourceBank.Money -= _cost[3];
            _isLocked5 = false;
            CheckLock(_floorsIndex - 1);
        }
    }
    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
