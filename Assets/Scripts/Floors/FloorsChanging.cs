using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsChanging : MonoBehaviour
{
    [SerializeField] private GameObject[] _floors;

    private int _floorsIndex = 0;

    public void ChangeUp()
    {
        _floors[_floorsIndex].SetActive(false);
        _floorsIndex++;
        _floors[_floorsIndex].SetActive(true);
    }
    public void ChangeDown()
    {
        _floors[_floorsIndex].SetActive(false);
        _floorsIndex--;
        _floors[_floorsIndex].SetActive(true);
    }
}
