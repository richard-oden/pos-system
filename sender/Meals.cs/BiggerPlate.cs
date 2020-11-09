using System;
using System.Collections.Generic;
using System.Linq;

namespace PosSender
{
    public class BiggerPlate : IMeal, IOrderItem
    {
        public string Name {get; private set;} = "bigger plate";
        public decimal Price => Contents.Sum(i => i.Price);
        public List<Item> Contents {get; private set;}
        public bool IsComplete => Contents.Count == 4;

        public BiggerPlate(List<Item> contents = null)
        {
            Contents = contents == null ? new List<Item>() : contents;
            if (validateContents(contents))
            {
                Contents = contents;
            }
            else
            {
                throw new InvalidMealException($"A {Name} can only contain a 16oz side and three 8oz entrees.");
            }
        }
        
        public void AddToMeal(Item item)
        {
            var tempMeal = new List<Item>(Contents);
            tempMeal.Add(item);
            if (validateContents(tempMeal))
            {
                Contents.Add(item);
            }
            else
            {
                Console.WriteLine($"{item.Name} could not be added to {Name}.");
            }
        }

        private bool validateContents(List<Item> contents)
        {
            return contents.Count <= 2 &&
                contents.Where(i => i.Size == Size.Side16oz).ToArray().Length <= 1 &&
                contents.Where(i => i.Size == Size.Entree8oz).ToArray().Length <= 3 &&
                contents.All(i => i.Size == Size.Side16oz && i.Size == Size.Entree8oz);
        }
    }
}