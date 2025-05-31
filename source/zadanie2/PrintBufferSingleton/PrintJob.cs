// Plik: PrintJob.cs
using System;

namespace PrintBufferSingleton
{
    /// <summary>
    /// Klasa reprezentująca jedno zadanie drukowania.
    /// </summary>
    public class PrintJob
    {
        public int JobId { get; }
        public string DocumentName { get; }
        public int Pages { get; }

        public PrintJob(int jobId, string documentName, int pages)
        {
            JobId = jobId;
            DocumentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
            Pages = pages;
        }

        public override string ToString()
        {
            return $"PrintJob[id={JobId}, document='{DocumentName}', pages={Pages}]";
        }
    }
}
