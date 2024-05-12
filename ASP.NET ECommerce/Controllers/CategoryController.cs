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
        var categories = await _categoryRepository.GetAllAsync();
        var categoryTags = new List<CategoryTag>();
        foreach(var category in categories) {
            var categoryTag = new CategoryTag();
            categoryTag.Tags = new List<Tag>();
            categoryTag.Category = category;
            foreach(var tag in category.Tags) {
                categoryTag.Tags.Add(tag);
            }
            if (categoryTag.Tags.Count != 0) categoryTags.Add(categoryTag);
        }
        return View(categoryTags);
    }

    [HttpGet]
    public async Task<IActionResult> AddTag() {
        return View(new CategoryTag());
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(CategoryTag categoryTag) {
         var category = await _categoryRepository.GetByIdAsync(categoryTag.CategoryId);
        category.Tags.Add(await _TagRepository.GetByIdAsync(categoryTag.TagId));
        var tag = await _TagRepository.GetByIdAsync(categoryTag.TagId);
        tag.Categories.Add(await _categoryRepository.GetByIdAsync(categoryTag.CategoryId));
        _categoryRepository.Update(category);
        _TagRepository.Update(tag);
        return View(categoryTag);
    }
}
