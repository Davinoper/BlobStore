using BlobStore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlobStore.DataContent
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Produto> produtos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
