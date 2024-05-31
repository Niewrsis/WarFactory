using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _tutorialScrens;
    [SerializeField] private GameObject _arrowToRight;
    [SerializeField] private GameObject _arrowToLeft;
    private int _index = 0;

    private void Awake()
    {
        for (int i = 0; i < _tutorialScrens.Length; i++)
            _tutorialScrens[i].SetActive(false);
        _tutorialScrens[0].SetActive(true);

        _arrowToLeft.SetActive(false);
        _arrowToRight.SetActive(true);
    }
    private void Start()
    {
        _arrowToRight.GetComponent<Button>().onClick.AddListener(ArrowRight);
        _arrowToLeft.GetComponent<Button>().onClick.AddListener(ArrowLeft);
    }
    private void ArrowRight()
    {
        if (_index == _tutorialScrens.Length - 1)
        {
            _arrowToRight.SetActive(false);
            return;
        }
        _index++;
        CheckIndex(_index);
        if (_index == _tutorialScrens.Length - 1) _arrowToRight.SetActive(false);
        else _arrowToRight.SetActive(true);

        if (_index == 0) _arrowToLeft.SetActive(false);
        else _arrowToLeft.SetActive(true);
    }
    private void ArrowLeft()
    {
        _index--;
        CheckIndex(_index);
        if (_index == _tutorialScrens.Length - 1) _arrowToRight.SetActive(false);
        else _arrowToRight.SetActive(true);

        if (_index == 0) _arrowToLeft.SetActive(false);
        else _arrowToLeft.SetActive(true);
    }
    private void CheckIndex(int index)
    {
        for (int i = 0; i < _tutorialScrens.Length; i++)
        {
            if (index == i) _tutorialScrens[i].SetActive(true);
            else _tutorialScrens[i].SetActive(false);
        }
    }
}
