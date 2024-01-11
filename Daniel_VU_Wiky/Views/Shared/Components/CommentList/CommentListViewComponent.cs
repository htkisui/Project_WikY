using Daniel_VU_Wiky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daniel_VU_Wiky.Views.Shared.Components.CommentList;

public class CommentListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(IEnumerable<CommentViewModel> commentViewModels)
    {
        return View(commentViewModels);
    }
}
