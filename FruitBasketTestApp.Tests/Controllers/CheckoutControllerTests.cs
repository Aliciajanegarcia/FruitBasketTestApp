using FruitBasketTestApp.Controllers;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitBasketTestApp.Controllers.Tests
{
    [TestClass()]
    public class CheckoutControllerTests
    {

        [TestMethod()]
        public void AddressAndPaymentTest_PopulatesView_ReturnsView()
        {
            // Arrange
            CheckoutController controller = new CheckoutController();

            // Act
            ViewResult result = controller.AddressAndPayment() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddressAndPaymentTest()
        {
            
        }

        [TestMethod()]
        public void CompleteTest()
        {
          
        }
    }
}