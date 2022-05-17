using CheckoutKata.Enums;

namespace CheckoutKata.Interfaces;

public interface IPromotion
{
    EPromotionType Type { get; set; }
    int Threshold { get; set; }
    int ModifierValue { get; set; }
}