using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.DbContext
{
    public interface IApplicationContext
    {
        public DbSet<Desk> Desks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
