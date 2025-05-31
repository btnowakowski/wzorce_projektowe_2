// Plik: Program.cs
using System;
using PrintBufferSingleton;

namespace PrintBufferTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pobranie instancji singletona
            PrintBuffer buffer1 = PrintBuffer.Instance;
            PrintBuffer buffer2 = PrintBuffer.Instance;

            // Sprawdzenie, że buffer1 i buffer2 to ta sama instancja
            Console.WriteLine($"buffer1 is buffer2? {ReferenceEquals(buffer1, buffer2)}");

            // Dodajemy kilka zadań do bufora
            buffer1.AddJob(new PrintJob(1, "Dokument_A.pdf", 10));
            buffer1.AddJob(new PrintJob(2, "Raport_B.docx", 5));
            buffer1.AddJob(new PrintJob(3, "Prezentacja_C.pptx", 15));

            // Wyświetlamy listę zadań
            Console.WriteLine("\nAktualna kolejka zadań:");
            foreach (var job in buffer1.ListJobs())
            {
                Console.WriteLine($" - {job}");
            }

            // Przetwarzamy zadania w pętli
            Console.WriteLine("\nProces drukowania:");
            while (true)
            {
                var nextJob = buffer2.GetNextJob();
                if (nextJob == null)
                    break;
                buffer2.ProcessNextJob();
            }

            // Sprawdzamy, że kolejka jest pusta
            var remaining = buffer1.ListJobs();
            Console.WriteLine($"\nKolejka po przetworzeniu wszystkich zadań: {(remaining.Count == 0 ? "pusta" : remaining.Count.ToString())}");
        }
    }
}
