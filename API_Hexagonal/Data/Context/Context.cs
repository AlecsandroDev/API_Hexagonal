using API_Hexagonal.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Hexagonal.Data.Context
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .ToTable("aluno")
                .HasKey(alu => alu.Id);

            modelBuilder.Entity<Curso>()
                .ToTable("curso")
                .HasKey(cur => cur.Id);

            modelBuilder.Entity<Aluno>()
                .HasOne(alu => alu.Curso)
                .WithMany(cur => cur.Alunos)
                .HasForeignKey(alu => alu.CursoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
