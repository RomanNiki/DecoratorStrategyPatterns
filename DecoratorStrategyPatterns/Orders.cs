namespace DecoratorStrategyPatterns;

public class Order
{
    public readonly int Id;
    public readonly int Amount;

    public Order(int id, int amount) => (Id, Amount) = (id, amount);
}

public interface IPaymentSystem
{
    public string GetPayingLink(Order order);
}

public class IdPaymentSystem : IPaymentSystem
{
    private readonly IHash _hash;

    public IdPaymentSystem(IHash hash)
    {
        _hash = hash;
    }

    public string GetPayingLink(Order order)
    {
        return _hash.Hash(order.Id.ToString());
    }
}

public class IdAmountPaymentSystem : IPaymentSystem
{
    private readonly IHash _hash;

    public IdAmountPaymentSystem(IHash hash)
    {
        _hash = hash;
    }

    
    public string GetPayingLink(Order order)
    {
        return _hash.Hash(order.Id.ToString() + order.Amount);
    }
}

public class ShaPaymentSystem : IPaymentSystem
{
    private readonly IHash _hash;

    public ShaPaymentSystem(IHash hash)
    {
        _hash = hash;
    }
    

  public string GetPayingLink(Order order)
    {
        return _hash.Hash(order.Id.ToString() + order.Amount + this.GetHashCode());
    }
}

public interface IHash
{
    string Hash(string data);
}