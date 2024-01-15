using Daniel_VU_Wiky.Models;
using Entities;

namespace Daniel_VU_Wiky.Converters;

public static class PostConverter
{
    public static PostViewModel ConvertToPostViewModel(this Post post)
    {
        var postViewModel = new PostViewModel()
        {
            Id = post.Id,
            Author = post.Author,
            Topic = post.Topic,
            Content = post.Content,
            UpdatedAt = post.UpdatedAt,
        };
        var commentViewModels = new List<CommentViewModel>();
        if (post.Comments != null)
        {
            foreach (var comment in post.Comments)
            {
                var commentViewModel = new CommentViewModel()
                {
                    Id = comment.Id,
                    Author = comment.Author,
                    Content = comment.Content,
                    UpdatedAt = comment.UpdatedAt,
                    PostViewModel = postViewModel
                };
                commentViewModels.Add(commentViewModel);
            }
        }
        postViewModel.CommentViewModels = commentViewModels;
        return postViewModel;
    }

    public static Post ConvertToPost(this PostViewModel postViewModel)
    {
        var post = new Post()
        {
            Id = postViewModel.Id,
            Author = postViewModel.Author,
            Topic = postViewModel.Topic,
            Content = postViewModel.Content,
        };

        return post;
    }
}
