using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    class EleveFluent : EntityTypeConfiguration<Eleve>
    {
        public EleveFluent()
        {
            ToTable("APP_Eleve");
            HasKey(e => e.EleveId);

            Property(e => e.EleveId)
                .HasColumnName("EleveId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Nom)
                .HasColumnName("Eleve_Nom")
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.Prenom)
                .HasColumnName("Eleve_Prenom")
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.DateNaissance)
                .HasColumnName("Eleve_Ddn")
                .IsRequired();

            HasRequired(e => e.Classe)
                .WithMany(c => c.Eleves)
                .HasForeignKey(c => c.ClasseId);

            HasMany(e => e.Absences)
                .WithRequired(a => a.Eleve)
                .HasForeignKey(a => a.EleveId);

            HasMany(e => e.Notes)
                .WithRequired(n => n.Eleve)
                .HasForeignKey(n => n.EleveId);
        }
    }
}
