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
    }
}