using Daniel_VU_Wiky.Converters;
using Daniel_VU_Wiky.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Daniel_VU_Wiky.Controllers;
public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var postViewModels = new List<PostViewModel>();
        var posts = await _postService.GetPostsOrderByUpdatedAtDescAsync();
        posts.ForEach(p =>
        {
            var postViewModel = p.ConvertToPostViewModel();
            postViewModels.Add(postViewModel);
        });

        return View(postViewModels);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostViewModel postViewModel)
    {
        if (!ModelState.IsValid) return View(postViewModel);
        var post = postViewModel.ConvertToPost();
        await _postService.AddPostAsync(post);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postService.GetPostAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        var postViewModel = post.ConvertToPostViewModel();
        return View(postViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel postViewModel)
    {
        if (!ModelState.IsValid) return View(postViewModel);
        var post = postViewModel.ConvertToPost();
        await _postService.UpdatePostAsync(post);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _postService.DeletePostAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var post = await _postService.GetPostAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        var postViewModel = post.ConvertToPostViewModel();
        return View(postViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(string search)
    {
        var postViewModels = new List<PostViewModel>();
        var posts = await _postService.GetPostsByTopicOrAuthorOrContentAsync(search);
        posts.ForEach(p =>
        {
            var postViewModel = p.ConvertToPostViewModel();
            postViewModels.Add(postViewModel);
        });

        return View("Index", postViewModels);
    }
}
