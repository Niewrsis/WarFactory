using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorsChanging : MonoBehaviour
{
    [SerializeField] private GameObject[] _floors;
    [SerializeField] private TextMeshProUGUI _floorsText;

    private int _floorsIndex = 0;
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
    }
    public void ChangeDown()
    {
        _floors[_floorsIndex].SetActive(false);
        _floorsIndex--;
        _floors[_floorsIndex].SetActive(true);
        FloorsText(_floorsIndex);
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
}
