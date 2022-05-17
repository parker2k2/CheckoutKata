using CheckoutKata.Interfaces;

internal interface IBasket
{
    List<IItem> Items { get;}

    void Add(IItem item);
}
