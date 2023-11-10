﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class UserPreference
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
}
