using System;
using System.Collections.Generic;
using System.Linq;

namespace PosSender
{
    public class MediumPartyBundle : IMeal, IOrderItem
    {
        public string Name {get; private set;} = "medium party bundle";
        public decimal Price => Contents.Sum(i => i.Price);
        public List<Item> Contents {get; private set;}
        public bool IsComplete => Contents.Count == 6;

        public MediumPartyBundle(List<Item> contents = null)
        {
            Contents = contents == null ? new List<Item>() : contents;
            if (validateContents(contents))
            {
                Contents = contents;
            }
            else
            {
                throw new InvalidMealException($"A {Name} can only contain three party sides and three party entrees.");
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
                contents.Where(i => i.Size == Size.PartySide).ToArray().Length <= 3 &&
                contents.Where(i => i.Size == Size.PartyEntree).ToArray().Length <= 3 &&
                contents.All(i => i.Size == Size.PartySide && i.Size == Size.PartyEntree);
        }
    }
}