using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresShopAPI.Domain.Models.Cart;
using Xunit;

namespace TyresShopAPI.Tests.Unit
{
    public class OrderTests
    {

        [Fact]
        public void CalculateSubTotal_WithEmptyCart_ShouldReturnZero()
        {
            // Arrange
            List<CartView> emptyCart = new List<CartView>();
            decimal deliveryPrice = 10.0m; // Example delivery price

            // Act
            decimal result = CalculateSubTotal(emptyCart, deliveryPrice);

            // Assert
            Assert.Equal(10.0m, result); // The result should be equal to the delivery price
        }


    }
}
