using System.Collections.Generic;
using System.Linq;

namespace PosSender
{
    public class Order
    {
        private static int _runningId = 0;
        public int Id {get; private set;}
        public List<IOrderItem> Contents {get; protected set;}
        public decimal TotalPrice => Contents.Sum(i => i.Price);
        public string Notes {get; protected set;}
        
        public Order(List<IOrderItem> contents = null, string notes = null)
        {
            _runningId++;
            Id = _runningId;
            Contents = contents == null ? new List<IOrderItem>() : contents;
            Notes = notes;
        }
        
        public void AddIOrderItem(IOrderItem itemToAdd)
        {
            Contents.Add(itemToAdd);
        }

        private void optimizeContents()
        {
            var individualItems = from i in Contents where i is Item select (Item)i;
            var sides16oz = individualItems.Where(i => i.Size == Size.Side16oz).ToArray();
            if (sides16oz.Length > 0)
            {

                var entrees8oz = individualItems.Where(i => i.Size == Size.Entree8oz).ToArray();
                if (entrees8oz.Length >= 3)
                {

                }
            }
        }
    }
}