using Microsoft.AspNetCore.Mvc;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace ASP.NET_ECommerce.MVC.Controllers;

public class CategoryController : Controller {

    private readonly ITagRepository _TagRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository, ITagRepository tagRepository) {
        _categoryRepository = categoryRepository;
        _TagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult AddCategory() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category) {
        await _categoryRepository.AddAsync(category);
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategory() {
        var categories = await _categoryRepository.GetAllAsync();
        return View(categories);
    }

    public async Task<IActionResult> AllTags() {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddTag(int id) {
        var category = await _categoryRepository.GetByIdAsync(id);
        ViewBag.Tags = await _TagRepository.GetAllAsync();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(int id, int[] tags) {
        var category = await _categoryRepository.GetByidWithTags(id);

        foreach (var tagId in tags) {
            var tag = await _TagRepository.GetByIdAsync(tagId);
            category.Tags.Add(tag);
        }

        await _categoryRepository.SaveChanges();
        return RedirectToAction("AddTag");
    }
}
