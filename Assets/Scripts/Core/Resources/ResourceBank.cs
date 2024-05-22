public class ResourceBank
{
    private float _money;
    private int _multiplier;
    public float Money { get => _money; set => _money = value; }
    public int Multiplier { get => _multiplier; set => _multiplier = value; }

    public ResourceBank(float money, int multiplier)
    {
        Money = money;
        Multiplier = multiplier;
    }
}
