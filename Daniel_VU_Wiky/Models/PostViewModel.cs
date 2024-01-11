using System.ComponentModel.DataAnnotations;

namespace Daniel_VU_Wiky.Models;

public class PostViewModel
{
    public int Id { get; set; }

    [Required]
    public string? Topic { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Author { get; set; }

    public string? Content { get; set; }

    public DateTime UpdatedAt { get; set; }
    public List<CommentViewModel>? CommentViewModels { get; set;}
}
