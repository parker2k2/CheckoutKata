using System;
using System.Runtime.InteropServices.ComTypes;
using CheckoutKata.Classes;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Unit.Tests
{
    public class BasketTests
    {
        private readonly Basket _basket = new();
        
        [Test]
        public void Basket_AddItem_ItemAddedToBasket()
        {
            //arrange
            var returnMockItemSku = "mockItemA";

            var mockItem = new Mock<IItem>();
            mockItem.Setup(x => x.ItemSku).Returns(returnMockItemSku);

            //act
            _basket.Add(mockItem.Object);
            
            //assert
            Assert.AreEqual(1, _basket.Items.Count);
            Assert.AreEqual(returnMockItemSku, _basket.Items[0].ItemSku);
        }

        [Test]
        public void Basket_GetTotalCost_TwoItems()
        {
            //arrange
            var mockItem1 = new Mock<IItem>();
            mockItem1.Setup(x => x.GetCost()).Returns(1.3m);

            var mockItem2 = new Mock<IItem>();
            mockItem2.Setup(x => x.GetCost()).Returns(2.5m);

            _basket.Add(mockItem1.Object);
            _basket.Add(mockItem2.Object);

            //act
            var totalCost = _basket.GetTotalCost();
            
            //assert
            Assert.AreEqual(2, _basket.Items.Count);
            Assert.AreEqual(totalCost, 3.8m);
        }

        [Test]
        public void Basket_GetTotalCost_InvalidCostItem()
        {
            //arrange
            var mockItem1 = new Mock<IItem>();
            mockItem1.Setup(x => x.GetCost()).Returns(-1);
            
            _basket.Add(mockItem1.Object);
            
            //assert / act
            Assert.AreEqual(1, _basket.Items.Count);
            Assert.Throws<Exception> (() => _basket.GetTotalCost());
        }

    }
}