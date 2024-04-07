using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Generator1 : MonoBehaviour
{
    private ResourceBank _resourceBank;

    [SerializeField] private Button _buyingGen1;
    [SerializeField] private Button _buyingGen1Interval;

    [SerializeField] private int _gen1Cost = 200;
    [SerializeField] private long _gen1Income = 1;
    [SerializeField] private float _gen1Interval = 1.0f;

    [SerializeField] private int _gen1IntervalCost = 200;
    [SerializeField] private float _gen1IntervalMinus = 0.05f;

    private bool _isBought = false;

    private void Start()
    {
        _buyingGen1.onClick.AddListener(BuyGen);
        _buyingGen1Interval.onClick.AddListener(IntervalUpgrader);
    }

    IEnumerator Income()
    {
        while (true)
        {
            _resourceBank.Money += _gen1Income;
            yield return new WaitForSeconds(_gen1Interval);
        }
    }

    private void BuyGen()
    {
        if (_resourceBank.Money >= _gen1Cost && _isBought == false)
        {
            _isBought = true;
            StartCoroutine(Income());
            _resourceBank.Money -= _gen1Cost;
        }
        else if (_resourceBank.Money >= _gen1Cost && _isBought != false)
        {
            _resourceBank.Money -= _gen1Cost;
            _gen1Income++;
        }
    }

    private void IntervalUpgrader()
    {
        if (_gen1Interval <= 0.1)
            return;

        if (_resourceBank.Money >= _gen1IntervalCost)
        {
            _resourceBank.Money -= _gen1IntervalCost;
            _gen1Interval -= _gen1IntervalMinus;
        }
    }

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
