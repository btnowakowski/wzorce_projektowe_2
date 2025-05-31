using System;
using System.Collections.Generic;

public class Logger
{
    private static Logger instance;
    private List<string> logs;

    // Prywatny konstruktor - zapobiega tworzeniu instancji z zewnątrz
    private Logger()
    {
        logs = new List<string>();
    }

    // Właściwość dostępu do instancji (Singleton)
    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }

    // Dodanie komunikatu do logów
    public void Log(string message)
    {
        logs.Add(message);
    }

    // Pobranie wszystkich komunikatów
    public List<string> GetLogs()
    {
        return logs;
    }
}

// Testowanie działania klasy Logger
public class Program
{
    public static void Main()
    {
        Logger logger1 = Logger.Instance;
        logger1.Log("Pierwszy komunikat");

        Logger logger2 = Logger.Instance;
        logger2.Log("Drugi komunikat");

        Console.WriteLine("Logger 1 logi:");
        foreach (var log in logger1.GetLogs())
        {
            Console.WriteLine(log);
        }

        Console.WriteLine("Logger 2 logi:");
        foreach (var log in logger2.GetLogs())
        {
            Console.WriteLine(log);
        }

        Console.WriteLine("Czy logger1 i logger2 to ta sama instancja? " + (logger1 == logger2));
    }
}
