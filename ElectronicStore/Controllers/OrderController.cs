using ElectronicStore.Interfaces;
using ElectronicStore.Models;
using ElectronicStore.Repository;
using ElectronicStore.Services;
using ElectronicStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectronicStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(
          IOrderRepository orderRepository,
          IProductRepository productRepository,
          UserManager<AppUser> userManager)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var products = await _productRepository.GetAll();
            var productsSelectList = new SelectList(products, "Id", "Name");

            var orderViewModel = new OrderViewModel
            {
                Products = productsSelectList
            };

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Make(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                var products = await _productRepository.GetAll();
                var productsSelectList = new SelectList(products, "Id", "Name");
                orderViewModel.Products = productsSelectList;

                return View(orderViewModel);
            }

            var currentUser = await _userManager.GetUserAsync(User);

            var order = new Order
            {
                ProductId = orderViewModel.ProductId,
                AppUserId = currentUser.Id
            };

            _orderRepository.Add(order);

            return RedirectToAction("Index", "Product");
        }
    }
}
