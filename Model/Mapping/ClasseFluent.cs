using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    class ClasseFluent : EntityTypeConfiguration<Classe>
    {
        public ClasseFluent()
        {
            ToTable("APP_Classe");
            HasKey(c => c.ClasseId);

            Property(c => c.ClasseId)
                .HasColumnName("ClasseId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.NomEtablissement)
                .HasColumnName("Classe_NomEtablissement")
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Niveau)
                .HasColumnName("Classe_Niveau")
                .IsRequired()
                .HasMaxLength(255);

            HasMany(c => c.Eleves)
                .WithRequired(e => e.Classe)
                .HasForeignKey(e => e.ClasseId);
        }
    }
}
