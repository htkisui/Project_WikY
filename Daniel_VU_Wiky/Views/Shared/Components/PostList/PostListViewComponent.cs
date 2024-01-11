using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.PostList;

public class PostListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(IEnumerable<PostViewModel> postViewModels)
    {
        return View(postViewModels);
    }
}
