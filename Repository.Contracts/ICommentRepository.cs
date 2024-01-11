using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts;
public interface ICommentRepository
{
    Task AddCommentAsync(Comment comment);
    Task<Comment?> GetCommentAsync(int id);
    Task<List<Comment>> GetCommentsAsync();
    Task UpdateCommentAsync(Comment comment);
    Task<Comment?> DeleteCommentAsync(int id);
}
