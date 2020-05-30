using Model.Entities;
using Model.Mapping;
using System.Data.Entity;

namespace Model
{
    public class Contexte : DbContext
    {
        public Contexte() : base("name=connectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClasseFluent());
            modelBuilder.Configurations.Add(new EleveFluent());
            modelBuilder.Configurations.Add(new NoteFluent());
            modelBuilder.Configurations.Add(new AbsenceFluent());
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Absence> Absences { get; set; }
    }
}
