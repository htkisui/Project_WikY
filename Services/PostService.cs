﻿using Entities;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task AddPostAsync(Post post)
    {
        await _postRepository.AddPostAsync(post);
    }

    public async Task<Post?> DeletePostAsync(int id)
    {
        return await _postRepository.DeletePostAsync(id);
    }

    public async Task<Post?> GetPostAsync(int id)
    {
        return await _postRepository.GetPostAsync(id);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _postRepository.GetPostsAsync();
    }

    public async Task<List<Post>> GetPostsByTopicOrAuthorOrContentAsync(string search)
    {
        return await _postRepository.GetPostsByTopicOrAuthorOrContentAsync(search);
    }

    public async Task<List<Post>> GetPostsOrderByUpdatedAtDescAsync()
    {
        return await _postRepository.GetPostsOrderByUpdatedAtDescAsync();
    }

    public async Task UpdatePostAsync(Post post)
    {
        await _postRepository.UpdatePostAsync(post);
    }
}
