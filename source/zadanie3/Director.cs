// Director.cs
namespace PrintBuilderDemo
{
    /// <summary>
    /// Klasa Director – zarządza kolejnością wywołań metod Buildera.
    /// </summary>
    public class Director
    {
        private IPizzaBuilder _builder;

        public Director(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Buduje pizzę Margherita: cienkie ciasto, mozzarella, parmezan, bazylia.
        /// </summary>
        public void ConstructMargherita()
        {
            _builder.Reset();
            _builder.SetDough("Cienkie ciasto");
            _builder.AddCheese("Mozzarella");
            _builder.AddCheese("Parmezan");
            _builder.AddSpice("Bazylia");
        }

        /// <summary>
        /// Buduje pizzę Meat Lovers: grube ciasto, mozarella, pepperoni, szynka, boczek, oregano.
        /// </summary>
        public void ConstructMeatLovers()
        {
            _builder.Reset();
            _builder.SetDough("Grube ciasto");
            _builder.AddCheese("Mozzarella");
            _builder.AddMeat("Pepperoni");
            _builder.AddMeat("Szynka");
            _builder.AddMeat("Boczek");
            _builder.AddSpice("Oregano");
        }

        /// <summary>
        /// Buduje pizzę Veggie Delight: cienkie ciasto, mozzarella, papryka, cebula, pieczarki, oregano, czosnek w proszku.
        /// </summary>
        public void ConstructVeggieDelight()
        {
            _builder.Reset();
            _builder.SetDough("Cienkie ciasto");
            _builder.AddCheese("Mozzarella");
            _builder.AddVeggie("Papryka");
            _builder.AddVeggie("Cebula");
            _builder.AddVeggie("Pieczarki");
            _builder.AddSpice("Oregano");
            _builder.AddSpice("Czosnek w proszku");
        }
    }
}
