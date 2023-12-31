﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAccess.Repository.IRepository;

public interface ICommentRepository : IRepository<Comment>
{
    void Update(Comment obj);
    IEnumerable<Comment> GetAllByPostId(int postId);
}
