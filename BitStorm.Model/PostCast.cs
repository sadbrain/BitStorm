﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class PostCast
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Title Name")]
    public string Title { get; set; }
    [Required]
    [DisplayName("Description")]
    public string Description { get; set; }

    [Required]
    public string Url { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }


    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
}
