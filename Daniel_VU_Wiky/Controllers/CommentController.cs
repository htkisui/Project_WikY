using Daniel_VU_Wiky.Converters;
using Daniel_VU_Wiky.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Service.Contracts;
using Services;

namespace Daniel_VU_Wiky.Controllers;
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public IActionResult Add(int postId)
    {
        ViewBag.PostId = postId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(CommentViewModel commentViewModel)
    {
        var comment = commentViewModel.ConvertToComment();
        await _commentService.AddCommentAsync(comment);
        return RedirectToAction("Detail", "Post", new { id = comment.PostId });
    }

    [HttpPost]
    public async Task<IActionResult> AddWithJS(string postId, string author, string content)
    {
        var comment = new Comment()
        {
            Author = author,
            Content = content,
            PostId = int.Parse(postId)
        };
        await _commentService.AddCommentAsync(comment);
        return ViewComponent("CommentFull", comment.ConvertToCommentViewModel());
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        var commentViewModel = comment.ConvertToCommentViewModel();
        ViewBag.PostId = comment.PostId;
        return View(commentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CommentViewModel commentViewModel)
    {
        var comment = commentViewModel.ConvertToComment();
        await _commentService.UpdateCommentAsync(comment);
        return RedirectToAction("Detail", "Post", new { id = comment.PostId });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await _commentService.DeleteCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return RedirectToAction("Detail", "Post", new { id = comment.PostId });
    }
}
