﻿using Microsoft.EntityFrameworkCore;

namespace BitStorm.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        //connecting with entity framework
        //configure DB context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
