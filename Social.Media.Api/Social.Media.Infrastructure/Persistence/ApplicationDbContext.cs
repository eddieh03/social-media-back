using Microsoft.EntityFrameworkCore;
using Social.Media.Application.Common.Interfaces;
using Social.Media.Model.Entities;

namespace Social.Media.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}