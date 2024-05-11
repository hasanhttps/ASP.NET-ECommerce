using Microsoft.AspNetCore.Mvc;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.MVC.Controllers {
    public class ProductController : Controller {

        private readonly ITagRepository _TagRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, ITagRepository tagRepository) {
            _productRepository = productRepository;
            _TagRepository = tagRepository;
        }

        public IActionResult AddProduct() {
            return View();
        }

        public IActionResult GetAllProducts() {
            return View();
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
