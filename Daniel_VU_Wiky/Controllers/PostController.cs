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
            Topic = post.Topic,
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

    private Post ConvertPostViewModelToPost(PostViewModel postViewModel)
    {
        var post = new Post()
        {
            Id = postViewModel.Id,
            Author = postViewModel.Author,
            Topic = postViewModel.Topic,
            Content = postViewModel.Content,
        };

        return post;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var postViewModels = new List<PostViewModel>();
        var posts = await _postService.GetPostsAsync();
        posts.ForEach(p =>
        {
            var postViewModel = ConvertPostToPostViewModel(p);
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
        var post = ConvertPostViewModelToPost(postViewModel);
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
        var postViewModel = ConvertPostToPostViewModel(post);
        return View(postViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel postViewModel)
    {
        var post = ConvertPostViewModelToPost(postViewModel);
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
        var postViewModel = ConvertPostToPostViewModel(post);
        return View(postViewModel);
    }
}
