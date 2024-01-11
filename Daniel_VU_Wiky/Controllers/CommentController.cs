using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Daniel_VU_Wiky.Controllers;
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
}
