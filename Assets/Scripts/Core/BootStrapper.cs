using UnityEngine;
namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Clicker _clickerField;
        [SerializeField] private MoneyView _moneyView;

        private void Awake()
        {
            ResourceBank resourceBank = new ResourceBank(0);
            _clickerField.Initialize(resourceBank);
            _moneyView.Initialize(resourceBank);
        }
    }
}
