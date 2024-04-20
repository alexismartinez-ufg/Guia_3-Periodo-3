using Ejercicio_1.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio_1.DAL;

public partial class Guia3Periodo3Context : DbContext
{
    public Guia3Periodo3Context()
    {
    }

    public Guia3Periodo3Context(DbContextOptions<Guia3Periodo3Context> options)
        : base(options)
    {
    }


    public DbSet<Contacto> Contactos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
