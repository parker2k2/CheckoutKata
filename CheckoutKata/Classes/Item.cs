using CheckoutKata.Interfaces;

namespace CheckoutKata.Classes;

public class Item : IItem
{
    public Item()
    {
        Promotions = new List<IPromotion>();
    }

    public string? ItemSku { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public List<IPromotion> Promotions { get; set; }

    private IEnumerable<IPromotion> WeightedPromotions => Promotions.OrderBy(x => x.Weighting);

    public decimal GetCost()
    {
        try
        {
            var promotionCost = default(decimal);
            var standardCostItemsQuantity = Quantity;

            foreach (var promotion in WeightedPromotions)
            {
                if (!promotion.IsActive || Quantity < promotion.Threshold) continue;

                standardCostItemsQuantity = Quantity % promotion.Threshold;
                    
                //Apply promotion
                promotionCost = promotion.GetPromotionCost(Quantity - standardCostItemsQuantity, UnitPrice);
            }
            
            return standardCostItemsQuantity * UnitPrice + promotionCost;
        }
        catch (Exception e)
        {
            //TODO - add logging
            Console.WriteLine(e);
            throw new Exception("Failed to get item cost");
        }
    }
}