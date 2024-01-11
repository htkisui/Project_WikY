using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Post
{
    public int Id { get; set; }

    [Required]
    public string? Topic { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Author { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}
