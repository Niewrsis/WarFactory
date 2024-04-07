using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Generator1 : MonoBehaviour
{
    private ResourceBank _resourceBank;

    [SerializeField] private Button _buyingGen1;

    private int _gen1Cost = 200;
    private long _gen1Income = 1;
    private float _gen1Interval = 1.0f;

    private bool _isBought = false;

    private void Start()
    {
        _buyingGen1.onClick.AddListener(BuyGen);
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

    public void Initialize(ResourceBank resourceBank)
    {
        _resourceBank = resourceBank;
    }
}
