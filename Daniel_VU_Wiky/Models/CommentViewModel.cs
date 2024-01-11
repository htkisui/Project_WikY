using Entities;
using System.ComponentModel.DataAnnotations;

namespace Daniel_VU_Wiky.Models;

public class CommentViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Author { get; set; }

    [MaxLength(100)]
    public string? Content { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int PostViewModelId { get; set; }
    public PostViewModel? PostViewModel { get; set; }
}
