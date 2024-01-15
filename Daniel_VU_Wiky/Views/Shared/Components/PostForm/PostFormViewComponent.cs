using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.PostForm;

public class PostFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(PostViewModel postViewModel, string action, string controller)
    {
        ViewBag.Action = action;
        ViewBag.Controller = controller;
        return View(postViewModel);
    }
}
