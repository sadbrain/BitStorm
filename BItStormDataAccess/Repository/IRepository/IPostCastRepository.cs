﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAccess.Repository.IRepository;

public interface IPostCastRepository : IRepository<PostCast>
{
    void Update(PostCast obj);
}
