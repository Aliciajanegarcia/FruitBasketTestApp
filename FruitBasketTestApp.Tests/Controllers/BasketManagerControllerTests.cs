using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitBasketTestApp.Controllers.Tests
{
    [TestClass()]
    public class BasketManagerControllerTests
    {
        [TestMethod()]
        public void Index_PopulatesView_ReturnsView()
        {
            // Arrange
            BasketManagerController controller = new BasketManagerController ();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod()]
        public void AddToCartTest()
        {

        }
    }
}