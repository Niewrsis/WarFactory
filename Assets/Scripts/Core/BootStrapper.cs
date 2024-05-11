using UnityEngine;
namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Floor1 _floor1;
        [SerializeField] private MoneyView _moneyView;

        private void Awake()
        {
            ResourceBank resourceBank = new ResourceBank(0, 1);
            _floor1.Initialize(resourceBank);
            _moneyView.Initialize(resourceBank);
        }
    }
}
