using UnityEngine;
namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Floor1 _floor1;
        [SerializeField] private Floor2 _floor2;
        [SerializeField] private Floor3 _floor3;
        [SerializeField] private Floor4 _floor4;
        [SerializeField] private Floor5 _floor5;
        [SerializeField] private MoneyView _moneyView;

        private void Awake()
        {
            ResourceBank resourceBank = new ResourceBank(0, 1);
            _floor1.Initialize(resourceBank);
            _floor2.Initialize(resourceBank);
            _floor3.Initialize(resourceBank);
            _floor4.Initialize(resourceBank);
            _floor5.Initialize(resourceBank);
            _moneyView.Initialize(resourceBank);
        }
    }
}
