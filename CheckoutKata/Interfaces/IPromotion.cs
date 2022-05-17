using CheckoutKata.Enums;

namespace CheckoutKata.Interfaces;

public interface IPromotion
{
    EPromotionType Type { get; set; }
    int Threshold { get; set; }
    int ModifierValue { get; set; }
    int Weighting { get; set; }
    bool IsActive { get; set; }
    bool ConjunctionEnabled { get; set; }

    decimal GetPromotionCost(int quantity, decimal unitPrice);
}