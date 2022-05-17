namespace CheckoutKata.Interfaces
{
    public interface IItem
    {
        string ItemSku { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
        List<IPromotion> Promotions { get; set; }
        decimal GetCost();
    }
}
