public class ResourceBank
{
    private long _money;
    private int _multiplier;
    public long Money { get => _money; set => _money = value; }
    public int Multiplier { get => _multiplier; set => _multiplier = value; }

    public ResourceBank(int money, int multiplier)
    {
        Money = money;
        Multiplier = multiplier;
    }
}
