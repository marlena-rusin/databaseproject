using ElectronicStore.Interfaces;
using ElectronicStore.Models;
using ElectronicStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(ApplicationDbContext context, IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productRepository.Add(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsyncNoTracking(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Brand, Category, Price, Description")] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(updatedProduct);
            }

            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = updatedProduct.Name;
                existingProduct.Brand = updatedProduct.Brand;
                existingProduct.Category = updatedProduct.Category;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Description = updatedProduct.Description;

                _productRepository.Update(existingProduct);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsyncNoTracking(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsyncNoTracking(id);
            if (product == null) return View("Error");

            _productRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}