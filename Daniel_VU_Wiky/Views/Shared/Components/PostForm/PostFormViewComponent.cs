using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.PostForm;

public class PostFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(PostViewModel postViewModel, string action)
    {
        ViewBag.Action = action;
        return View(postViewModel);
    }
}
