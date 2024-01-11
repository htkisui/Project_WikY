using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.Comment;

public class CommentViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CommentViewModel commentViewModel)
    {
        return View(commentViewModel);
    }
}
