using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;


// Primary constructor
// Options for example connection string
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    // Users - name of table in the DB
    public DbSet<AppUser> Users { get; set; }
}

