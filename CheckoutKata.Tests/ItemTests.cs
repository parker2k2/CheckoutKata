using System;
using System.Collections.Generic;
using CheckoutKata.Classes;
using CheckoutKata.Enums;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Unit.Tests
{
    public class ItemTests
    {

        [Test]
        public void Item_GetCost_StandardItemNoPromotion_()
        {
            //arrange
            var testItem = new Item()
            {
                Quantity = 2,
                ItemSku = "test1",
                UnitPrice = 10
            };
            
            //act
            var cost = testItem.GetCost();

            //assert
            Assert.AreEqual(20, cost);
        }

        [Test]
        public void Item_GetCost_StandardItemNoPromotion_Multiple_()
        {
            //arrange
            var testItem = new Item()
            {
                Quantity = 2,
                ItemSku = "test1",
                UnitPrice = 10
            };

            //act
            var cost = testItem.GetCost();

            //assert
            Assert.AreEqual(20, cost);
        }

        [Test]
        public void Item_GetCost_WithPromotionActualPrice()
        {
            //arrange
            var testItem = new Item()
            {
                Quantity = 5,
                ItemSku = "test1",
                UnitPrice = 10
            };

            var mockPromotion = new Mock<IPromotion>();
            mockPromotion.Setup(x => x.Type).Returns(EPromotionType.ActualPrice);
            mockPromotion.Setup(x => x.Threshold).Returns(3);
            mockPromotion.Setup(x => x.IsActive).Returns(true);
            mockPromotion.Setup(x => x.Weighting).Returns(1);
            mockPromotion.Setup(x => x.ConjunctionEnabled).Returns(false);
            mockPromotion.Setup(x => x.GetPromotionCost(It.IsAny<int>(),It.IsAny<decimal>())).Returns(50);

            testItem.Promotions = new List<IPromotion>(new[]
            {
                mockPromotion.Object
            });
            
            //act
            var cost = testItem.GetCost();

            //assert
            Assert.AreEqual(70, cost);
        }

    }
}