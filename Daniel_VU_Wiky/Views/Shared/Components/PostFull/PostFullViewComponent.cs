using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.PostFull;

public class PostFullViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(PostViewModel postViewModel)
    {
        return View(postViewModel);
    }
}
