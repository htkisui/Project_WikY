using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddCommentAsync(Comment comment)
    {
        comment.CreatedAt = DateTime.Now;
        comment.UpdatedAt = DateTime.Now;
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<Comment?> DeleteCommentAsync(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
        }
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> GetCommentAsync(int id)
    {
        return await _context.Comments.Include(c => c.Post).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _context.Comments.Include(c => c.Post).ToListAsync();
    }

    public async Task UpdateCommentAsync(Comment comment)
    {
        var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(c => c.Id == comment.Id);
        if (commentToUpdate != null)
        {
            commentToUpdate.Author = comment.Author;
            commentToUpdate.Content = comment.Content;
            commentToUpdate.UpdatedAt = DateTime.Now;
        }
        await _context.SaveChangesAsync();
    }
}
