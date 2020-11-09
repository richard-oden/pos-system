namespace PosSender
{
    public class Item
    {
        public string Name {get; private set;}
        public decimal Price {get; set;}
        public Size Size {get; private set;}
    }

    public enum Size
    {
        Appetizer,
        Side16oz,
        Side26oz,
        Entree8oz,
        Entree16oz,
        Entree26oz,
        PartySide,
        PartyEntree
    }
}