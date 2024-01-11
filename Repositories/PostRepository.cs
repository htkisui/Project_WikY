using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddPostAsync(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task<Post?> DeletePostAsync(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post != null)
        {
            _context.Posts.Remove(post);
        }
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> GetPostAsync(int id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task UpdatePostAsync(Post post)
    {
        var postToUpdate = await _context.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
        if (postToUpdate != null)
        {
            postToUpdate.Topic = post.Topic;
            postToUpdate.Author = post.Author;
            postToUpdate.Content = post.Content;
        }
        await _context.SaveChangesAsync();
    }
}
