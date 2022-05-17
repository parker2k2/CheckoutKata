using CheckoutKata.Enums;
using CheckoutKata.Interfaces;

namespace CheckoutKata.Classes;

public class Promotion : IPromotion
{
    public EPromotionType Type { get; set; }
    public int Threshold { get; set; }
    public int ModifierValue { get; set; }
    public int Weighting { get; set; }
    public bool IsActive { get; set; }
    public bool ConjunctionEnabled { get; set; }
    public decimal GetPromotionCost(int quantity, decimal unitPrice)
    {
        try
        {
            switch (Type)
            {
                case EPromotionType.ActualPrice:
                    return quantity / Threshold * ModifierValue;
                case EPromotionType.Percentage:
                    var fullPrice = quantity * unitPrice;
                    return fullPrice - fullPrice * ((decimal)ModifierValue / 100);
                default : throw new ArgumentException("Incorrect promotion type");
            }
        }
        catch (Exception e)
        {
            //TODO - add logging
            Console.WriteLine(e);
            throw new Exception("Failed to get promotion item cost");
        }
    }
}