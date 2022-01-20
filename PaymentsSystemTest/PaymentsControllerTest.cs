using Microsoft.AspNetCore.Mvc;
using PaymentSystemDaniel;
using PaymentSystemDaniel.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsSystemTest
{
    public class PaymentsControllerTest
    {
        private readonly PaymentsController _controller;
        private readonly IPaymentsService _paymentsSvc;

        public PaymentsControllerTest()
        {
            _controller = new PaymentsController(_paymentsSvc);
        }

        [Fact]
        public void GetPayments()
        {
            // Act
            var okResult = _controller.GetPayments();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }

        [Fact]
        public void GetBalance()
        {
            // Act
            var okResult = _controller.GetBalance();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }

        [Fact]
        public void GetTableHeaders()
        {
            // Act
            var okResult = _controller.GetTableHeaders();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }

        [Fact]
        public void CreatePayments()
        {
            // Act
            var okResult = _controller.CreatePayments();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }

        [Fact]
        public void CreateBalance()
        {
            // Act
            var okResult = _controller.CreateBalance();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }

        [Fact]
        public void CreateTableHeaders()
        {
            // Act
            var okResult = _controller.CreateTableHeaders();
            // Assert
            Xunit.Assert.IsType<Task<IActionResult>>(okResult);
        }
    }
}
