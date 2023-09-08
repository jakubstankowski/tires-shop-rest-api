using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Application.Services;
using TyresShopAPI.Domain.Models.Cart;
using Xunit;

namespace TyresShopAPI.Tests.Unit
{
    public class OrderTests
    {
        private OrderService _orderService;

        public OrderTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public void Calculate_SubTotal_With_Empty_Cart_Should_Return_Only_Delivery_Price()
        {
            // Arrange
            List<CartView> emptyCart = new();
            decimal deliveryPrice = 10.0m;

            // Act
            decimal result = _orderService.CalculateSubTotal(emptyCart, deliveryPrice);

            // Assert
            Assert.Equal(10.0m, result); // The result should be equal to the delivery price
        }

        [Fact]
        public void Calculate_SubTotal_With_Zero_Delivery_Price_Should_Return_Sum_OfCartItem_Values()
        {
            // Arrange
            List<CartView> cartItems = new()
        {
            new CartView { TotalValue = 20.0m },
            new CartView { TotalValue = 30.0m },
            new CartView { TotalValue = 40.0m }
        };
            decimal deliveryPrice = 0.0m;

            // Act
            decimal result = _orderService.CalculateSubTotal(cartItems, deliveryPrice);

            // Assert
            Assert.Equal(90.0m, result); // The result should be the sum of cart items (no delivery price)
        }

        [Fact]
        public void Calculate_SubTotal_With_Items_In_Cart_Should_Return_Correct_SubTotal()
        {
            // Arrange
            List<CartView> cartItems = new()
        {
            new CartView { TotalValue = 20.0m },
            new CartView { TotalValue = 30.0m },
            new CartView { TotalValue = 40.0m }
        };
            decimal deliveryPrice = 10.0m; // Example delivery price

            // Act
            decimal result = _orderService.CalculateSubTotal(cartItems, deliveryPrice);

            // Assert
            Assert.Equal(100.0m, result); // The result should be the sum of cart items plus delivery price
        }
    }
}
