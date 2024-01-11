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

    private Comment ConvertCommentViewModelToComment(CommentViewModel commentViewModel)
    {
        var comment = new Comment()
        {
            Id = commentViewModel.Id,
            Author = commentViewModel.Author,
            Content = commentViewModel.Content,
            UpdatedAt = commentViewModel.UpdatedAt,
            PostId = commentViewModel.PostViewModelId
        };
        return comment;
    }

    private CommentViewModel ConvertCommentToCommentViewModel(Comment comment)
    {
        var commentViewModel = new CommentViewModel()
        {
            Id = comment.Id,
            Author = comment.Author,
            Content = comment.Content,
            UpdatedAt = comment.UpdatedAt,
            PostViewModelId = comment.PostId
        };
        return commentViewModel;
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
        var comment = ConvertCommentViewModelToComment(commentViewModel);
        await _commentService.AddCommentAsync(comment);
        return RedirectToAction("Detail", "Post", new { id = comment.PostId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        var commentViewModel = ConvertCommentToCommentViewModel(comment);
        ViewBag.PostId = comment.PostId;
        return View(commentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CommentViewModel commentViewModel)
    {
        var comment = ConvertCommentViewModelToComment(commentViewModel);
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
