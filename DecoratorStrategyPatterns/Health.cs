namespace DecoratorStrategyPatterns;

public interface IDamageable
{
    void TakeDamage(int damage);
}

public interface IDyingPolicy
{
    bool Died(int value);
}

public class NormalDyingPolicy : IDyingPolicy
{
    public bool Died(int value)
    {
        return value <= 0;
    }
}

public class Health : IDamageable
{
    private int _value;
    private IDyingPolicy _dyingPolicy;

    public Health(int value, IDyingPolicy dyingPolicy)
    {
        _value = value;
        _dyingPolicy = dyingPolicy;
    }

    public Action Die;

    public void TakeDamage(int damage)
    {
        Console.WriteLine($"damage {damage}");
        _value -= damage;
        if (_value <= 0)
            _value = 0;

        if (_dyingPolicy.Died(_value) == false)
            return;
        
        Die?.Invoke();
        Console.WriteLine("Die");
    }
}

public class HumanArmor : IDamageable
{
    private readonly IDamageable _damageable;
    private readonly int _agility;

    public HumanArmor(IDamageable damageable, int agility)
    {
        _damageable = damageable;
        _agility = agility;
    }

    public void TakeDamage(int damage)
    {
        _damageable.TakeDamage(damage - _agility);
    }
}

public class BarbarSkin : IDamageable
{
    private readonly IDamageable _damageable;

    public BarbarSkin(IDamageable damageable)
    {
        _damageable = damageable;
    }

    public void TakeDamage(int damage)
    {
        _damageable.TakeDamage(damage * 2);
    }
}