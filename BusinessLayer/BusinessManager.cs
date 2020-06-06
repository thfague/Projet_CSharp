using BusinessLayer.Commands;
using BusinessLayer.Queries;
using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    /// <summary>
    /// BusinessManager de la BusinessLayer
    /// Cette classe est un singleton est instancie un contexte EF dans son constructeur
    /// </summary>
    public class BusinessManager
    {
        private readonly Contexte contexte;
        private static BusinessManager _businessManager = null;

        /// <summary>
        /// Constructeur, initialisation du contexte EF
        /// </summary>
        private BusinessManager()
        {
            contexte = new Contexte();
        }

        /// <summary>
        /// Récupérer l'instance du pattern Singleton
        /// </summary>
        public static BusinessManager Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new BusinessManager();
                return _businessManager;
            }
        }

        #region Eleve

        /// <summary>
        /// Récupérer une liste d'élève en base
        /// </summary>
        /// <returns>Liste de Eleve</returns>
        public List<Eleve> GetAllEleve()
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer un élève en base par son ID
        /// </summary>
        /// <returns>Eleve</returns>
        public Eleve GetEleveById(int eleveID)
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetByID(eleveID).SingleOrDefault();
        }

        /// <summary>
        /// Ajouter un élève en base
        /// </summary>
        /// <param name="e">Eleve à ajouter</param>
        /// <returns>identifiant du nouvel élève</returns>
        public int AjouterEleve(Eleve e)
        {
            // TODO : ajouter des contrôles sur l'élève (exemple : vérification de champ, etc.)
            EleveCommand ec = new EleveCommand(contexte);
            return ec.Ajouter(e);
        }

        /// <summary>
        /// Modifier un élève en base
        /// </summary>
        /// <param name="e">Eleve à modifier</param>
        public void ModifierEleve(Eleve e)
        {
            // TODO : ajouter des contrôles sur l'élève (exemple : vérification de champ, etc.)
            EleveCommand ec = new EleveCommand(contexte);
            ec.Modifier(e);
        }

        /// <summary>
        /// Supprimer un élève en base
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève à supprimer</param>
        public void SupprimerEleve(int eleveID)
        {
            EleveCommand ec = new EleveCommand(contexte);
            ec.Supprimer(eleveID);
        }

        #endregion

        #region Classe

        /// <summary>
        /// Récupérer une liste de classe en base
        /// </summary>
        /// <returns>Liste de Classe</returns>
        public List<Classe> GetAllClasse()
        {
            ClasseQuery cq = new ClasseQuery(contexte);
            return cq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une classe en base par son ID
        /// </summary>
        /// <returns>Classe</returns>
        public Classe GetClasseById(int classeID)
        {
            ClasseQuery cq = new ClasseQuery(contexte);
            return cq.GetByID(classeID).SingleOrDefault();
        }

        /// <summary>
        /// Ajouter une classe en base
        /// </summary>
        /// <param name="c">Classe à ajouter</param>
        /// <returns>identifiant de la nouvelle classe</returns>
        public int AjouterClasse(Classe c)
        {
            // TODO : ajouter des contrôles sur la classe (exemple : vérification de champ, etc.)
            ClasseCommand cc = new ClasseCommand(contexte);
            return cc.Ajouter(c);
        }

        /// <summary>
        /// Modifier une classe en base
        /// </summary>
        /// <param name="c">Classe à modifier</param>
        public void ModifierClasse(Classe c)
        {
            // TODO : ajouter des contrôles sur la classe (exemple : vérification de champ, etc.)
            ClasseCommand cc = new ClasseCommand(contexte);
            cc.Modifier(c);
        }

        /// <summary>
        /// Supprimer une classe en base
        /// </summary>
        /// <param name="classeID">Identifiant de la classe à supprimer</param>
        public void SupprimerClasse(int classeID)
        {
            ClasseCommand cc = new ClasseCommand(contexte);
            cc.Supprimer(classeID);
        }

        #endregion

        #region Note

        /// <summary>
        /// Récupérer une liste de note en base
        /// </summary>
        /// <returns>Liste de Note</returns>
        public List<Note> GetAllNote()
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une note en base par son ID
        /// </summary>
        /// <returns>Note</returns>
        public Note GetNoteById(int noteID)
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetByID(noteID).SingleOrDefault();
        }

        /// <summary>
        /// Récupérer les notes en base par l'ID de l'élève
        /// </summary>
        /// <returns>List<Notes></Notes></returns>
        public List<Note> GetNotesByEleveId(int eleveID)
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetByEleveID(eleveID).ToList();
        }

        /// <summary>
        /// Ajouter une note en base
        /// </summary>
        /// <param name="n">Note à ajouter</param>
        /// <returns>identifiant de la nouvelle note</returns>
        public int AjouterNote(Note n)
        {
            // TODO : ajouter des contrôles sur la note (exemple : vérification de champ, etc.)
            NoteCommand nc = new NoteCommand(contexte);
            return nc.Ajouter(n);
        }

        /// <summary>
        /// Modifier une note en base
        /// </summary>
        /// <param name="n">Note à modifier</param>
        public void ModifierNote(Note n)
        {
            // TODO : ajouter des contrôles sur la note (exemple : vérification de champ, etc.)
            NoteCommand nc = new NoteCommand(contexte);
            nc.Modifier(n);
        }

        /// <summary>
        /// Supprimer une note en base
        /// </summary>
        /// <param name="noteID">Identifiant de la note à supprimer</param>
        public void SupprimerNote(int noteID)
        {
            NoteCommand nc = new NoteCommand(contexte);
            nc.Supprimer(noteID);
        }

        /// <summary>
        /// Récupérer la moyenne des notes en base par l'ID de l'élève
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève</param>
        /// <returns>string</returns>
        public string GetAvgByEleveId(int eleveID)
        {
            NoteQuery nq = new NoteQuery(contexte);
            List<Note> notes = nq.GetByEleveID(eleveID).ToList();
            if(notes.Count == 0)
            {
                return "Aucunes notes.";
            }
            double moy = notes.Average(note => note.Valeur);
            return moy.ToString();
        }

        #endregion

        #region Absence

        /// <summary>
        /// Récupérer une liste d'absence en base
        /// </summary>
        /// <returns>Liste de Absence</returns>
        public List<Absence> GetAllAbsence()
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une absence en base par son ID
        /// </summary>
        /// <returns>Absence</returns>
        public Absence GetAbsenceById(int absenceID)
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.GetByID(absenceID).SingleOrDefault();
        }

        /// <summary>
        /// Récupérer les absences en base par l'ID de l'élève
        /// </summary>
        /// <returns>List<Absence></Absence></returns>
        public List<Absence> GetAbsencesByEleveId(int eleveID)
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.GetByEleveID(eleveID).ToList();
        }

        /// <summary>
        /// Ajouter une absence en base
        /// </summary>
        /// <param name="a">Absence à ajouter</param>
        /// <returns>identifiant de la nouvelle absence</returns>
        public int AjouterAbsence(Absence a)
        {
            // TODO : ajouter des contrôles sur la absence (exemple : vérification de champ, etc.)
            AbsenceCommand ac = new AbsenceCommand(contexte);
            return ac.Ajouter(a);
        }

        /// <summary>
        /// Modifier une absence en base
        /// </summary>
        /// <param name="a">Absence à modifier</param>
        public void ModifierAbsence(Absence a)
        {
            // TODO : ajouter des contrôles sur la note (exemple : vérification de champ, etc.)
            AbsenceCommand ac = new AbsenceCommand(contexte);
            ac.Modifier(a);
        }

        /// <summary>
        /// Supprimer une absence en base
        /// </summary>
        /// <param name="absenceID">Identifiant de l'absence à supprimer</param>
        public void SupprimerAbsence(int absenceID)
        {
            AbsenceCommand ac = new AbsenceCommand(contexte);
            ac.Supprimer(absenceID);
        }

        /// <summary>
        /// Récupérer le nombre d'absences d'un élève par son ID
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève</param>
        /// <returns>string</returns>
        public string GetNbAbsencesByEleveId(int eleveID)
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            int nbAbsences = aq.GetByEleveID(eleveID).Count();
            if (nbAbsences == 0)
            {
                return "Aucunes absences.";
            }
            return nbAbsences.ToString();
        }

        #endregion
    }
}
