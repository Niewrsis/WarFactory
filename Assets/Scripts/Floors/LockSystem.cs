using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LockSystem
{
    public string ElementName;
    public GameObject Locked, Unlocked;
    public Button Button;
    public TextMeshProUGUI CostText;
    public int Cost;
}
