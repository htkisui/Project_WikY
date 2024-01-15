using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.CommentForm;

public class CommentFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CommentViewModel? commentViewModel, string action, string controller)
    {
        ViewBag.Action = action;
        ViewBag.Controller = controller;
        return View(commentViewModel);
    }
}
