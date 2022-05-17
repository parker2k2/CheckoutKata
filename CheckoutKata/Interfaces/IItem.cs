namespace CheckoutKata.Interfaces
{
    internal interface IItem
    {
        string ItemSku { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
        List<IPromotion> Promotions { get; set; }
    }

    internal interface IPromotion
    {

    }
}
