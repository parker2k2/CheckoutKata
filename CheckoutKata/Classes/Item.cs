using CheckoutKata.Interfaces;

namespace CheckoutKata.Classes;

public class Item : IItem
{
    public string ItemSku { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public List<IPromotion> Promotions { get; set; }
    public decimal GetCost()
    {
        throw new NotImplementedException();
    }
}