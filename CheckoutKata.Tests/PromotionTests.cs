using System;
using System.Collections.Generic;
using CheckoutKata.Classes;
using CheckoutKata.Enums;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Unit.Tests
{
    public class PromotionTests
    {

        [Test]
        public void Promotion_GetPromotionCost_PercentageType()
        {
            //arrange
            var percentagePromotion = new Promotion()
            {
               Weighting = 1,
               ModifierValue = 25,
               ConjunctionEnabled = false,
               IsActive = true,
               Threshold = 2,
               Type = EPromotionType.Percentage
            };

            var quantity = 7;
            var unitPrice = 2m;

            //act
            var promotionCost = percentagePromotion.GetPromotionCost(quantity, unitPrice);

            //assert
            Assert.AreEqual(10.5, promotionCost);
        }

        [Test]
        public void Promotion_GetPromotionCost_ActualPrice()
        {
            //arrange
            var percentagePromotion = new Promotion()
            {
                Weighting = 1,
                ModifierValue = 40,
                ConjunctionEnabled = false,
                IsActive = true,
                Threshold = 2,
                Type = EPromotionType.ActualPrice
            };

            var quantity = 6;
            var unitPrice = 30m;

            //act
            var promotionCost = percentagePromotion.GetPromotionCost(quantity, unitPrice);

            //assert
            Assert.AreEqual(120, promotionCost);
        }
    }
}