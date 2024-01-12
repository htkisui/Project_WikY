using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.CommentForm;

public class CommentFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CommentViewModel? commentViewModel, string action, string controller, int postId)
    {
        ViewBag.Action = action;
        ViewBag.Controller = controller;
        ViewBag.PostId = postId;
        return View(commentViewModel);
    }
}
