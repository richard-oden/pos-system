using System.Collections.Generic;

namespace PosSender
{
    public interface IMeal
    {
        List<Item> Contents {get;}
        bool IsComplete {get;}
        void AddToMeal(Item item);
    }
}