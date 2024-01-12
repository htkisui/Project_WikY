using Daniel_VU_Wiky.Models;
using Entities;

namespace Daniel_VU_Wiky.Converters;

public static class CommentConverter
{
    public static Comment ConvertToComment(this CommentViewModel commentViewModel)
    {
        var comment = new Comment()
        {
            Id = commentViewModel.Id,
            Author = commentViewModel.Author,
            Content = commentViewModel.Content,
            UpdatedAt = commentViewModel.UpdatedAt,
            PostId = commentViewModel.PostViewModelId
        };
        return comment;
    }

    public static CommentViewModel ConvertToCommentViewModel(this Comment comment)
    {
        var commentViewModel = new CommentViewModel()
        {
            Id = comment.Id,
            Author = comment.Author,
            Content = comment.Content,
            UpdatedAt = comment.UpdatedAt,
            PostViewModelId = comment.PostId
        };
        return commentViewModel;
    }
}
