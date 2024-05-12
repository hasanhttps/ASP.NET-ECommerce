using Microsoft.AspNetCore.Mvc;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.MVC.Controllers {
    public class ProductController : Controller {

        private readonly ITagRepository _TagRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, ITagRepository tagRepository) {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _TagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product) {
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            product.Category = category;
            _productRepository.AddAsync(product);
            category.Products.Add(product);
            _categoryRepository.Update(category);
            return View(product);
        }

        public async Task<IActionResult> GetAllProducts() {
            return View(await _productRepository.GetAllAsync());
        }

        public async Task<IActionResult> AllTags() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddTag(int id) {
            var product = await _productRepository.GetByIdAsync(id);
            ViewBag.Tags = await _TagRepository.GetAllAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(int id, int[] tags) {
            var product = await _productRepository.GetByidWithTags(id);

            foreach (var tagId in tags) {
                var tag = await _TagRepository.GetByIdAsync(tagId);
                product.Tags.Add(tag);
            }

            await _productRepository.SaveChanges();
            return RedirectToAction("AddTag");
        }
    }
}
