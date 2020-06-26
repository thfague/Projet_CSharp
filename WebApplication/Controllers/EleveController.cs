using BusinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EleveController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailEleve(int eleveID)
        {
            ViewBag.Message = "Détail élève";
            Eleve e = BusinessManager.Instance.GetEleveById(eleveID);

            List<Note> notes = BusinessManager.Instance.GetNotesByEleveId(eleveID);
            List<NoteViewModel> noteViewModels = new List<NoteViewModel>();
            foreach (Note n in notes)
            {
                noteViewModels.Add(new NoteViewModel { Valeur = n.Valeur, Appreciation = n.Appreciation, DateNote = n.DateNote, Matiere = n.Matiere, NoteId = n.NoteId });
            }

            List<Absence> absences = BusinessManager.Instance.GetAbsencesByEleveId(eleveID);
            List<AbsenceViewModel> absenceViewModels = new List<AbsenceViewModel>();
            foreach (Absence a in absences)
            {
                absenceViewModels.Add(new AbsenceViewModel { Motif = a.Motif, DateAbsence = a.DateAbsence, AbsenceId = a.AbsenceId });
            }

            Classe classe = BusinessManager.Instance.GetClasseById(e.ClasseId);
            ClasseViewModel classeViewModel = new ClasseViewModel { NomEtablissement = classe.NomEtablissement, Niveau = classe.Niveau };

            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance, Notes = noteViewModels, Absences = absenceViewModels, Classe = classeViewModel, EleveId = e.EleveId };
            return View(eleveViewModel);
        }

        public ActionResult ListEleves(string filtre)
        {
            ViewBag.Message = "Liste d'élèves.";
            List<Eleve> eleves;

            if (!String.IsNullOrEmpty(filtre))
            {
                eleves = BusinessManager.Instance.GetAllEleve().Where(e => e.Nom.Contains(filtre) || e.Prenom.Contains(filtre)).ToList();
            }
            else
            {
                eleves = BusinessManager.Instance.GetAllEleve();
                
            }
            List<EleveViewModel> eleveViewModels = new List<EleveViewModel>();
            foreach (Eleve e in eleves)
            {
                eleveViewModels.Add(new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance, EleveId = e.EleveId });
            }
            return View(eleveViewModels);
        }
    }
}