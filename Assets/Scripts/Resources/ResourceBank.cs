public class ResourceBank
{
    private long _money;
    public long Money { get => _money; set => _money = value; }

    public ResourceBank(int money)
    {
        Money = money;
    }
}
