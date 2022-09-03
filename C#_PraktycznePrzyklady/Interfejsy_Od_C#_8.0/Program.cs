using Interfejsy_8._0;

Console.WriteLine("C# 8.0");

ILoggerOLD logger = new OldConsoleLogger();
logger.Warn("ostrzeżenie od logger");
ILoggerOLD logger1 = new NewConsoleLogger();
logger1.Warn("ostrzeżenie od logger1");

OldConsoleLogger logger2 = new OldConsoleLogger();
((ILoggerOLD)logger2).Warn("ostrzeżenie od logger2");
NewConsoleLogger logger3 = new NewConsoleLogger();
logger3.Warn("ostrzeżenie od logger3");

//////////
Console.WriteLine();
ILogger loggerCL = new ConsoleLogger();
loggerCL.Warn("ostrzeżenie");
ILogger loggerCL1 = new ConsoleLogger1();
loggerCL1.Warn("ostrzeżenie");

///////////
Console.WriteLine();
ILogger2 loggerCL2 = new 