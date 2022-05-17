using CheckoutKata.Interfaces;

public interface IBasket
{
    List<IItem> Items { get;}

    void Add(IItem item);
    decimal GetTotalCost();
}
