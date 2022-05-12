

using Microsoft.EntityFrameworkCore;
using CommentManagement.Infrastructure.Mapping;
//using CommentManagement.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentManagement.Domain.CommentAgg;

namespace CommentManagement.Infrastruture
{
    public class CommentDBContext : DbContext
    {
       
        public DbSet<Domain.CommentAgg.Comment> Comments { get; set; }
        public CommentDBContext(DbContextOptions<CommentDBContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
