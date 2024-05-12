using Microsoft.AspNetCore.Mvc;
using ASP.NET_ECommerce.Domain.Entities.Concretes;
using ASP.NET_ECommerce.DataAccess.Reposiotries.Abstracts;

namespace Lesson_9_OnlineStore_MVC.Controllers;

public class TagController : Controller
{
    private readonly ITagRepository _tagRepository;
     
    public TagController(ITagRepository tagRepository) {
        _tagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult AddTag() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(Tag tag) {
        await _tagRepository.AddAsync(tag);
        return View();
    }

    public async Task<IActionResult> AllTags() {
        return View(await _tagRepository.GetAllAsync());
    }
}
