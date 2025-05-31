// Plik: PrintBuffer.cs
using System;
using System.Collections.Generic;

namespace PrintBufferSingleton
{
    /// <summary>
    /// Bufor wydruku zaimplementowany jako Singleton.
    /// Przechowuje kolejkę zadań drukowania (FIFO).
    /// </summary>
    public sealed class PrintBuffer
    {
        // Prywatne, statyczne pole przechowujące jedyną instancję.
        private static readonly Lazy<PrintBuffer> _instance =
            new Lazy<PrintBuffer>(() => new PrintBuffer());

        // Wewnętrzna kolejka zadań
        private readonly Queue<PrintJob> _jobs;

        /// <summary>
        /// Prywatny konstruktor: nikt poza klasą nie może go wywołać.
        /// </summary>
        private PrintBuffer()
        {
            _jobs = new Queue<PrintJob>();
        }

        /// <summary>
        /// Publiczna właściwość zwracająca jedyną instancję klasy (Singleton).
        /// </summary>
        public static PrintBuffer Instance => _instance.Value;

        /// <summary>
        /// Dodaje nowe zadanie drukowania do kolejki.
        /// </summary>
        public void AddJob(PrintJob job)
        {
            if (job == null) throw new ArgumentNullException(nameof(job));
            _jobs.Enqueue(job);
            Console.WriteLine($"Dodano zadanie: {job}");
        }

        /// <summary>
        /// Zwraca pierwsze zadanie w kolejce bez usuwania go.
        /// Zwraca null, jeśli kolejka jest pusta.
        /// </summary>
        public PrintJob GetNextJob()
        {
            return _jobs.Count > 0 ? _jobs.Peek() : null;
        }

        /// <summary>
        /// Pobiera i usuwa pierwsze zadanie z kolejki, symulując drukowanie.
        /// Zwraca pobrane zadanie lub null, jeśli kolejka jest pusta.
        /// </summary>
        public PrintJob ProcessNextJob()
        {
            if (_jobs.Count == 0)
            {
                Console.WriteLine("Brak zadań w kolejce.");
                return null;
            }

            PrintJob job = _jobs.Dequeue();
            Console.WriteLine($"Drukuję: {job}");
            return job;
        }

        /// <summary>
        /// Zwraca listę wszystkich zadań obecnych aktualnie w kolejce (kopia kolejki).
        /// </summary>
        public List<PrintJob> ListJobs()
        {
            return new List<PrintJob>(_jobs);
        }
    }
}
