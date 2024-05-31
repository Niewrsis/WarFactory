using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LockSystem
{
    public string Name;
    public GameObject Locked, Unlocked;
    public Button Button;
    public TextMeshProUGUI CostText;
    public int Cost;
}
