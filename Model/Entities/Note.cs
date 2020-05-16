using System;

namespace Model.Entities
{
    public class Note
    {
        /// <summary>
        /// Identifiant de la note
        /// </summary>
        public int NoteId { get; set; }
        /// <summary>
        /// Nom de la matière qui est concerné par la note
        /// </summary>
        public string Matiere { get; set; }
        /// <summary>
        /// Date de la note
        /// </summary>
        public DateTime DateNote { get; set; }
        /// <summary>
        /// Appreciation de la note
        /// </summary>
        public string Appreciation { get; set; }
        /// <summary>
        /// Valeur de la note
        /// </summary>
        public int Valeur { get; set; }
        /// <summary>
        /// Identifiant de l'élève concerné par la note
        /// </summary>
        public int EleveId { get; set; }
        /// <summary>
        /// Élève concerné par la note
        /// </summary>
        public Eleve Eleve { get; set; }
    }
}
