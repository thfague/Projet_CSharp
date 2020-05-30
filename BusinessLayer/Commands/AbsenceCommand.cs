using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    /// <summary>
    /// COMMAND pour ajouter / modifier et supprimer une absence
    /// </summary>
    class AbsenceCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public AbsenceCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter l'absence en base à partir du contexte
        /// </summary>
        /// <param name="a">Absence à ajouter</param>
        /// <returns>Identifiant de l'absence ajoutée</returns>
        public int Ajouter(Absence a)
        {
            _contexte.Absences.Add(a);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier une absence déjà présente en base à partir du contexte
        /// </summary>
        /// <param name="a">Absence à modifier</param>
        public void Modifier(Absence a)
        {
            Absence upAbs = _contexte.Absences.Where(abs => abs.AbsenceId == a.AbsenceId).FirstOrDefault();
            if (upAbs != null)
            {
                upAbs.Motif = a.Motif;
                upAbs.DateAbsence = a.DateAbsence;
                upAbs.AbsenceId = a.AbsenceId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer une absence en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="absenceID">Identifiant de l'absence à supprimer</param>
        public void Supprimer(int absenceID)
        {
            Absence delAbs = _contexte.Absences.Where(abs => abs.AbsenceId == absenceID).FirstOrDefault();
            if (delAbs != null)
            {
                _contexte.Absences.Remove(delAbs);
            }
            _contexte.SaveChanges();
        }
    }
}
