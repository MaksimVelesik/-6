using System;
using System.IO;

public delegate void LogHandler(string message);

class Logger
{
    public void LogMessage(string message, LogHandler logMethod)
    {
        logMethod(message);
    }

    public void ConsoleLog(string message)
    {
        Console.WriteLine($"Консольный лог: {message}");
    }

    public void FileLog(string message)
    {
        File.AppendAllText("log.txt", $"Файловый лог: {message}{Environment.NewLine}");
    }
}

class Program
{
    static void Main()
    {
        Logger logger = new Logger();

        LogHandler consoleLogHandler = new LogHandler(logger.ConsoleLog);
        logger.LogMessage("Сообщение для консоли.", consoleLogHandler);

        LogHandler fileLogHandler = new LogHandler(logger.FileLog);
        logger.LogMessage("Сообщение для файла.", fileLogHandler);

        Console.WriteLine("Логирование завершено.");
    }
}