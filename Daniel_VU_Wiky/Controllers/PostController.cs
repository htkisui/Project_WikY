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
}
