using System.Linq;
using System.Web.Mvc;
using FruitBasketTestApp.Models;
using FruitBasketTestApp.ViewModels;

namespace FruitBasketTestApp.Controllers
{
    public class BasketManagerController : Controller
    {
        //instance of context, to do extract to reporitory and ad
        private FruitBasketDbEntities _dbContext = new FruitBasketDbEntities();

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        // GET: /Basket/
        public ActionResult Index()
        {
            var basket = BasketManager.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new BasketViewModel
            {
                BasketItems = basket.GetCartItems(),
                BasketTotal = basket.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        /// <summary>
        /// AddToCart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Add to cart
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            // Retrieve the item from the database
            var addedItem = _dbContext.Products
                .Single(item => item.ProductId == id);

            // Add it to the shopping cart
            var basket = BasketManager.GetCart(this.HttpContext);

            int count = basket.AddToBasket(addedItem);

            // Display the confirmation message
            var results = new BasketViewModel
            {
                Message = Server.HtmlEncode(addedItem.Name) +
                    " has been added to your shopping cart.",
                BasketTotal = basket.GetTotal(),
                BasketCount = basket.GetCount(),
                ItemCount = count,
                DeleteId = id
            };
            return Json(results);

            // return RedirectToAction("Index");
        }

        /// <summary>
        /// RemoveFromCart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // Remove from cart
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the basket
            var basket = BasketManager.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string itemName = _dbContext.Products
                .FirstOrDefault(item => item.ProductId == id).Name;

            // Remove from basket
            int itemCount = basket.RemoveFromCart(id);

            // Display the confirmation message
            var results = new BasketViewModel
            {
                Message = "One (1) " + Server.HtmlEncode(itemName) +
                    " has been removed from your shopping basket.",
                BasketTotal = basket.GetTotal(),
                BasketCount = basket.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }


        /// <summary>
        /// BasketSummary
        /// </summary>
        /// <returns></returns>
        // GET: BasketSummary
        [ChildActionOnly]
        public ActionResult BasketSummary()
        {
            var basket = BasketManager.GetCart(this.HttpContext);

            ViewData["BasketCount"] = basket.GetCount();
            return PartialView("BasketSummary");
        }
    }
}