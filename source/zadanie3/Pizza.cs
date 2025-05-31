// Pizza.cs
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintBuilderDemo
{
    /// <summary>
    /// Klasa reprezentująca produkt – pizzę z określonymi składnikami.
    /// </summary>
    public class Pizza
    {
        // Rodzaj ciasta
        public string Dough { get; private set; }

        // Listy składników
        public List<string> Meats { get; }
        public List<string> Cheeses { get; }
        public List<string> Veggies { get; }
        public List<string> Spices { get; }

        public Pizza()
        {
            Dough = string.Empty;
            Meats = new List<string>();
            Cheeses = new List<string>();
            Veggies = new List<string>();
            Spices = new List<string>();
        }

        /// <summary>
        /// Ustawia rodzaj ciasta.
        /// </summary>
        public void SetDough(string dough)
        {
            Dough = dough;
        }

        /// <summary>
        /// Dodaje wędlinę.
        /// </summary>
        public void AddMeat(string meat)
        {
            if (!string.IsNullOrWhiteSpace(meat))
                Meats.Add(meat);
        }

        /// <summary>
        /// Dodaje ser.
        /// </summary>
        public void AddCheese(string cheese)
        {
            if (!string.IsNullOrWhiteSpace(cheese))
                Cheeses.Add(cheese);
        }

        /// <summary>
        /// Dodaje warzywo.
        /// </summary>
        public void AddVeggie(string veggie)
        {
            if (!string.IsNullOrWhiteSpace(veggie))
                Veggies.Add(veggie);
        }

        /// <summary>
        /// Dodaje przyprawę.
        /// </summary>
        public void AddSpice(string spice)
        {
            if (!string.IsNullOrWhiteSpace(spice))
                Spices.Add(spice);
        }

        /// <summary>
        /// Zwraca wielowierszowy opis pizzy z wszystkimi składnikami.
        /// </summary>
        public string Describe()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Pizza z następującymi składnikami:");
            sb.AppendLine($"  Ciasto: {Dough}");
            if (Meats.Count > 0)
                sb.AppendLine($"  Wędliny: {string.Join(", ", Meats)}");
            if (Cheeses.Count > 0)
                sb.AppendLine($"  Sery: {string.Join(", ", Cheeses)}");
            if (Veggies.Count > 0)
                sb.AppendLine($"  Warzywa: {string.Join(", ", Veggies)}");
            if (Spices.Count > 0)
                sb.AppendLine($"  Przyprawy: {string.Join(", ", Spices)}");
            return sb.ToString();
        }
    }
}
