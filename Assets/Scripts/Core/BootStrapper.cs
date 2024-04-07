using UnityEngine;
namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Clicker _clickerField;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private Generator1 _generator1;
        private void Awake()
        {
            ResourceBank resourceBank = new ResourceBank(200);
            _clickerField.Initialize(resourceBank);
            _moneyView.Initialize(resourceBank);
            _generator1.Initialize(resourceBank);
        }
    }
}
