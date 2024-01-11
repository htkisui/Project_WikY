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

    private PostViewModel ConvertPostToPostViewModel(Post post)
    {
        var postViewModel = new PostViewModel()
        {
            Id = post.Id,
            Author = post.Author,
            Content = post.Content,
            UpdatedAt = post.UpdatedAt,
        };
        var commentViewModels = new List<CommentViewModel>();
        if (post.Comments != null)
        {
            foreach (var comment in post.Comments)
            {
                var commentViewModel = new CommentViewModel()
                {
                    Id = comment.Id,
                    Author = comment.Author,
                    Content = comment.Content,
                    UpdatedAt = comment.UpdatedAt,
                    PostViewModel = postViewModel
                };
                commentViewModels.Add(commentViewModel);
            }
        }
        postViewModel.CommentViewModels = commentViewModels;
        return postViewModel;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var postViewModels = new List<PostViewModel>();
        var posts = await _postService.getPostsAsync();
        posts.ForEach(p =>
        {
            var postViewModel = ConvertPostToPostViewModel(p);
            postViewModels.Add(postViewModel);
        });

        return View(postViewModels);
    }
}
