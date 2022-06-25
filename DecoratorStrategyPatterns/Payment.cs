namespace DecoratorStrategyPatterns;

internal enum BanksEnum
{
    Qiwi = 1,
    WebMoney = 2,
    Card
}

public static class OrderForm
{
    public static Bank ShowForm()
    {
        //симуляция веб интерфейса
        Console.WriteLine("Какое системой вы хотите совершить оплату?");
        Console.WriteLine("Мы принимаем: 1 QIWI,2 WebMoney,3 Card");

        if (int.TryParse(Console.ReadLine(), out var number))
        {
            var bank = (BanksEnum)number;

            return bank switch
            {
                BanksEnum.Qiwi => new Qiwi(),
                BanksEnum.WebMoney => new WebMoney(),
                BanksEnum.Card => new Card(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        throw new ArgumentOutOfRangeException();
    }
}

public class PaymentHandler
{
    public void ShowPaymentResult(Bank systemId)
    {
        Console.WriteLine($"Вы оплатили с помощью {systemId.Name}");

        systemId.DisplayResponse();

        Console.WriteLine("Оплата прошла успешно!");
    }
}

public abstract class Bank
{
    public string Name => GetType().Name;

    public abstract void CallRequest();

    public void DisplayResponse()
    {
        Console.WriteLine($"Проверка платежа через {Name}...");
    }
}

public class Qiwi : Bank
{
    public override void CallRequest()
    {
        Console.WriteLine("Перевод на страницу QIWI...");
    }
    
}

public class WebMoney : Bank
{
    public override void CallRequest()
    {
        Console.WriteLine("Вызов API WebMoney...");
    }

}

public class Card : Bank
{
    public override void CallRequest()
    {
        Console.WriteLine("Вызов API банка эмитера карты Card...");
    }
}