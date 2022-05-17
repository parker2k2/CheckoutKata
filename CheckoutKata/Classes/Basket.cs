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

        public decimal GetTotalCost()
        {
            try
            {
                var totalCost = default(decimal);

                foreach (var item in Items)
                {
                    var itemCost = item.GetCost();

                    if (itemCost <= 0)
                    {
                        throw new Exception("Invalid cost of item");
                    }

                    totalCost += item.GetCost();
                }

                return totalCost;
            }
            catch (Exception e)
            {
                //TODO - add logging
                Console.WriteLine(e);
                throw new Exception("Failed to calculate total cost, please try again");
            }
        }
    }
}