using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.CommentForm;

public class CommentFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CommentViewModel commentViewModel, string action, int postId)
    {
        ViewBag.Action = action;
        ViewBag.PostId = postId;
        return View(commentViewModel);
    }
}
