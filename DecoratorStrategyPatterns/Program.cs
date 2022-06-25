using DecoratorStrategyPatterns;

#region Health

Console.WriteLine("Game");
var armoredBarbar = new HumanArmor(new BarbarSkin(new Health(5, new NormalDyingPolicy())), 10);
armoredBarbar.TakeDamage(30);

#endregion

#region log
var fileLogger = new FileLogWriter(new DefaultLogPolicy());
fileLogger.WriteLog("here");
var consoleLogger = new ConsoleLogWriter(new DefaultLogPolicy());
consoleLogger.WriteLog("here");
var fridayFileLogger = new FileLogWriter(new OnlyFridayLogPolicy());
fridayFileLogger.WriteLog("friday");
var fridayConsoleLogger = new ConsoleLogWriter(new OnlyFridayLogPolicy());
fridayConsoleLogger.WriteLog("friday");
var mixedLogger = new FileLogWriter(new OnlyFridayLogPolicy());
mixedLogger.WriteLog("Mixed");
var allLogger = new FileLogWriter(new OnlyFridayLogPolicy(), new ConsoleLogWriter(new DefaultLogPolicy()));
allLogger.WriteLog("all");
#endregion

#region PaymentSystem
var paymentHandler = new PaymentHandler();
var systemId = OrderForm.ShowForm();
systemId.CallRequest();

paymentHandler.ShowPaymentResult(systemId);
#endregion
