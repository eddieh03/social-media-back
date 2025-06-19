using Microsoft.EntityFrameworkCore;
using Social.Media.Model.Entities;
using System.Collections.Generic;

namespace Social.Media.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
