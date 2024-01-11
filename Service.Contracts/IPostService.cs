using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface IPostService
{
    Task AddPostAsync(Post post);
    Task<Post?> DeletePostAsync(int id); 
    Task<Post?> GetPostAsync(int id);
    Task<List<Post>> GetPostsAsync();
    Task UpdatePostAsync(Post post);
}
