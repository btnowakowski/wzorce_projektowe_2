// ConcretePizzaBuilder.cs
using System;

namespace PrintBuilderDemo
{
    /// <summary>
    /// Konkretna klasa Buildera – buduje obiekt Pizza krok po kroku.
    /// </summary>
    public class ConcretePizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;

        public ConcretePizzaBuilder()
        {
            Reset();
        }

        /// <summary>
        /// Resetuje wewnętrzny stan – tworzy nową instancję Pizza.
        /// </summary>
        public void Reset()
        {
            _pizza = new Pizza();
        }

        public void SetDough(string dough)
        {
            _pizza.SetDough(dough);
        }

        public void AddMeat(string meat)
        {
            _pizza.AddMeat(meat);
        }

        public void AddCheese(string cheese)
        {
            _pizza.AddCheese(cheese);
        }

        public void AddVeggie(string veggie)
        {
            _pizza.AddVeggie(veggie);
        }

        public void AddSpice(string spice)
        {
            _pizza.AddSpice(spice);
        }

        /// <summary>
        /// Zwraca gotowy obiekt Pizza i jednocześnie przygotowuje buildera do kolejnego użycia.
        /// </summary>
        public Pizza GetPizza()
        {
            Pizza finishedPizza = _pizza;
            // Tworzymy nową instancję, żeby można było budować kolejną pizzę od zera
            Reset();
            return finishedPizza;
        }
    }
}
