using Microsoft.EntityFrameworkCore;
using Vitrin.Api.Models;

namespace Vitrin.Api.Data;

public class VitrinDbContext : DbContext
{
public VitrinDbContext(DbContextOptions<VitrinDbContext> options) : base(options)
{
}
public DbSet<Screen> Screens => Set<Screen>();
}