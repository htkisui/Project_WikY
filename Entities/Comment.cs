using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Comment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Author { get; set; }

    [MaxLength(100)]
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int PostId { get; set; }
    public virtual Post? Post { get; set; }
}
