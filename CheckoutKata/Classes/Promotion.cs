using CheckoutKata.Enums;
using CheckoutKata.Interfaces;

namespace CheckoutKata.Classes;

public class Promotion : IPromotion
{
    public EPromotionType Type { get; set; }
    public int Threshold { get; set; }
    public int ModifierValue { get; set; }
}