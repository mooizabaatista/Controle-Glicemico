using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class GliceControlContext : DbContext
{
    public GliceControlContext(DbContextOptions<GliceControlContext> opt) : base(opt) { }
    public GliceControlContext() { }

    public DbSet<ControleGlicemico> ControleGlicemico { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GliceControlContext).Assembly);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder opt)
    // {
    //     opt.UseSqlite("Data Source=GliceControl");
    // }
}