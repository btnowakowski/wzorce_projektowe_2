// IPizzaBuilder.cs
namespace PrintBuilderDemo
{
    /// <summary>
    /// Interfejs Buildera – definiuje kolejne kroki budowania pizzy.
    /// </summary>
    public interface IPizzaBuilder
    {
        void Reset();
        void SetDough(string dough);
        void AddMeat(string meat);
        void AddCheese(string cheese);
        void AddVeggie(string veggie);
        void AddSpice(string spice);
        Pizza GetPizza();
    }
}
