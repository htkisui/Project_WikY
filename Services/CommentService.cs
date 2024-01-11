using Entities;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task AddCommentAsync(Comment comment)
    {
        await _commentRepository.AddCommentAsync(comment);
    }

    public async Task<Comment?> DeleteCommentAsync(int id)
    {
        return await _commentRepository.DeleteCommentAsync(id);
    }

    public async Task<Comment?> GetCommentAsync(int id)
    {
        return await _commentRepository.GetCommentAsync(id);
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _commentRepository.GetCommentsAsync();
    }

    public async Task UpdateCommentAsync(Comment comment)
    {
        await _commentRepository.UpdateCommentAsync(comment);
    }
}
