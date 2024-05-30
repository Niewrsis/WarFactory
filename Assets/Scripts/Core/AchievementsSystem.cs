using System.Collections.Generic;
using UnityEngine;

public class AchievementsSystem : MonoBehaviour
{
    ResourceBank _resourceBank;
    [SerializeField] private List<AchievementsCore> _achievements;
    private int _multiplier;

    private void Start()
    {
        SetAchivmentsUI();

        for (int i = 0; i < _achievements.Count; ++i)
        {
            _achievements[i].StatusComplete.SetActive(false);
            _achievements[i].StatusNotCompleted.SetActive(true);
        }
    }
    private void Update()
    {
        Achivements();

        _multiplier = PlayerPrefs.GetInt("Multiplier", _multiplier);
    }
    private void Achivements()
    {
        if (_achievements[0].Goal <= _resourceBank.Money)
        {
            _achievements[0].StatusNotCompleted.SetActive(false);
            _achievements[0].StatusComplete.SetActive(true);
        }

        if (_achievements[1].Goal <= _resourceBank.Money)
        {
            _achievements[1].StatusNotCompleted.SetActive(false);
            _achievements[1].StatusComplete.SetActive(true);
        }

        if (_achievements[2].Goal <= _multiplier)
        {
            _achievements[2].StatusNotCompleted.SetActive(false);
            _achievements[2].StatusComplete.SetActive(true);
        }

        if (_achievements[3].Goal <= _multiplier)
        {
            _achievements[3].StatusNotCompleted.SetActive(false);
            _achievements[3].StatusComplete.SetActive(true);
        }
    }
    private void SetAchivmentsUI()
    {
        for (int i = 0; i < _achievements.Count; i++)
        {
            _achievements[i].TitleText.text = _achievements[i].Title;
            _achievements[i].DescriptionText.text = _achievements[i].Description;
        }
    }
    public void Initialize(ResourceBank resourceBank) => _resourceBank = resourceBank;
}
