using TMPro;
using UnityEngine;

[System.Serializable]
public class AchievementsCore
{
    public string Title;
    public string Description;
    public int Goal;
    public GameObject StatusComplete;
    public GameObject StatusNotCompleted;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
}
