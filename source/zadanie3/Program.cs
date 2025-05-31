// Program.cs
using System;

namespace PrintBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy buildera
            IPizzaBuilder builder = new ConcretePizzaBuilder();

            // Przekazujemy builder do Directora
            Director director = new Director(builder);

            // 1) Pizza Margherita (za pośrednictwem Directora)
            director.ConstructMargherita();
            Pizza margherita = builder.GetPizza();
            Console.WriteLine("=== Pizza Margherita ===");
            Console.WriteLine(margherita.Describe());
            Console.WriteLine("-------------------------\n");

            // 2) Pizza Meat Lovers (za pośrednictwem Directora)
            director.ConstructMeatLovers();
            Pizza meatLovers = builder.GetPizza();
            Console.WriteLine("=== Pizza Meat Lovers ===");
            Console.WriteLine(meatLovers.Describe());
            Console.WriteLine("-------------------------\n");

            // 3) Pizza wegetariańska (klient sam wybiera składniki, bez Directora)
            builder.Reset();
            builder.SetDough("Grube ciasto");
            builder.AddCheese("Mozzarella");
            builder.AddVeggie("Szpinak");
            builder.AddVeggie("Papryka");
            builder.AddVeggie("Cukinia");
            builder.AddSpice("Bazylia");
            builder.AddSpice("Oregano");
            Pizza customVeggie = builder.GetPizza();
            Console.WriteLine("=== Pizza Wegetariańska (niestandardowa) ===");
            Console.WriteLine(customVeggie.Describe());
            Console.WriteLine("-------------------------\n");

            // 4) Pizza wegetariańska z wykorzystaniem Directora (przykład)
            director.ConstructVeggieDelight();
            Pizza veggieDelight = builder.GetPizza();
            Console.WriteLine("=== Pizza Veggie Delight ===");
            Console.WriteLine(veggieDelight.Describe());
            Console.WriteLine("-------------------------\n");

            Console.WriteLine("Koniec testów Buildera.");
        }
    }
}
