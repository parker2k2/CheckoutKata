using CheckoutKata.Interfaces;

namespace CheckoutKata.Classes
{
    public class Basket : IBasket
    {
        public List<IItem> Items { get; }

        public Basket()
        {
            Items = new List<IItem>();
        }
        
        public void Add(IItem item)
        {
            try
            {
                Items.Add(item);
            }
            catch (Exception e)
            {
                //TODO - add logging
                Console.WriteLine(e);
                throw new Exception("Failed to add item, please try again");
            }
        }
    }
}