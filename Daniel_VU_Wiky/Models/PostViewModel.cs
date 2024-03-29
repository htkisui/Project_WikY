﻿using System.ComponentModel.DataAnnotations;

namespace Daniel_VU_Wiky.Models;

public class PostViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le Thème est requis")]
    public string? Topic { get; set; }

    [Required(ErrorMessage = "L'Auteur est requis")]
    [StringLength(30, ErrorMessage = "La taille maximale est de 30")]
    public string? Author { get; set; }

    public string? Content { get; set; }

    public DateTime UpdatedAt { get; set; }
    public List<CommentViewModel>? CommentViewModels { get; set;}
}
