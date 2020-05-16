using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    class AbsenceFluent : EntityTypeConfiguration<Absence>
    {
        public AbsenceFluent()
        {
            ToTable("APP_Absence");
            HasKey(a => a.AbsenceId);

            Property(a => a.AbsenceId)
                .HasColumnName("AbsenceId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.DateAbsence)
                .HasColumnName("Absence_DateAbsence")
                .IsRequired();

            Property(a => a.Motif)
                .HasColumnName("Absence_Motif")
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(a => a.Eleve)
                .WithMany(e => e.Absences)
                .HasForeignKey(e => e.EleveId);
        }
    }
}
