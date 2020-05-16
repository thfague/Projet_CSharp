using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    class NoteFluent : EntityTypeConfiguration<Note>
    {
        public NoteFluent()
        {
            ToTable("APP_Note");
            HasKey(n => n.NoteId);

            Property(n => n.NoteId)
                .HasColumnName("NoteId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(n => n.Matiere)
                .HasColumnName("Note_Matiere")
                .IsRequired()
                .HasMaxLength(255);

            Property(n => n.DateNote)
                .HasColumnName("Note_DateNote")
                .IsRequired();

            Property(n => n.Appreciation)
                .HasColumnName("Note_Appreciation")
                .IsRequired()
                .HasMaxLength(255);

            Property(n => n.Valeur)
                .HasColumnName("Note_Valeur")
                .IsRequired();

            HasRequired(n => n.Eleve)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.EleveId);
        }
    }
}
