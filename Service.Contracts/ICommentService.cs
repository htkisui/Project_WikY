using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;
public interface ICommentService
{
    Task AddCommentAsync(Comment comment);
    Task<Comment?> DeleteCommentAsync(int id);
    Task<Comment?> GetCommentAsync(int id);
    Task<List<Comment>> GetCommentsAsync();
    Task UpdateCommentAsync(Comment comment);
}
