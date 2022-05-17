using System.Collections.Generic;
using CheckoutKata.Classes;
using CheckoutKata.Enums;
using CheckoutKata.Interfaces;
using NUnit.Framework;

namespace CheckoutKata.Integration.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MultipleItemAddedToBasket()
        {
            //Arrange
            var basket = new Basket();
            
            var item = new Item()
            {
                Quantity = 1,
                UnitPrice = 10,
                ItemSku = "testOne"
            };

            var item2 = new Item()
            {
                Quantity = 2,
                UnitPrice = 20,
                ItemSku = "testTwo"
            };

            //Act
            basket.Add(item);
            basket.Add(item2);


            //Assert
            Assert.AreEqual(2, basket.Items.Count);
            Assert.AreEqual(item.ItemSku, basket.Items[0].ItemSku);
            Assert.AreEqual(item2.ItemSku, basket.Items[1].ItemSku);
        }


        [Test]
        public void TotalCostOfItemsAddedToBasketNoPromotion()
        {
            //Arrange
            var basket = new Basket();

            var item = new Item()
            {
                Quantity = 1,
                UnitPrice = 10,
                ItemSku = "testOne"
            };

            var item2 = new Item()
            {
                Quantity = 2,
                UnitPrice = 20,
                ItemSku = "testTwo"
            };

            //Act
            basket.Add(item);
            basket.Add(item2);

            var totalCost = basket.GetTotalCost();
            
            //Assert
            Assert.AreEqual(2, basket.Items.Count);
            Assert.AreEqual(50, totalCost);
        }

        [Test]
        public void MultipleSkuBPromotionMultipleOfThreeApplied()
        {
            //Arrange
            var basket = new Basket();

            var item = new Item()
            {
                Quantity = 7,
                UnitPrice = 15,
                ItemSku = "B",
                Promotions = new List<IPromotion>(new []
                {
                    new Promotion
                    {
                        ModifierValue = 40,
                        Weighting = 1,
                        Threshold = 3,
                        IsActive = true,
                        ConjunctionEnabled = false,
                        Type = EPromotionType.ActualPrice 
                    }
                })
            };
            
            //Act
            basket.Add(item);
            
            var totalCost = basket.GetTotalCost();

            //Assert
            Assert.AreEqual(1, basket.Items.Count);
            Assert.AreEqual(95, totalCost);
        }

        [Test]
        public void MultipleSkuDPromotionMultipleOfTwoApplied()
        {
            //Arrange
            var basket = new Basket();

            var item = new Item()
            {
                Quantity = 11,
                UnitPrice = 55,
                ItemSku = "testOne",
                Promotions = new List<IPromotion>(new[]
                {
                    new Promotion
                    {
                        ModifierValue = 25,
                        Weighting = 1,
                        Threshold = 2,
                        IsActive = true,
                        ConjunctionEnabled = false,
                        Type = EPromotionType.Percentage
                    }
                })
            };

            //Act
            basket.Add(item);

            var totalCost = basket.GetTotalCost();

            //Assert
            Assert.AreEqual(1, basket.Items.Count);
            Assert.AreEqual(467.5, totalCost);
        }
    }
}