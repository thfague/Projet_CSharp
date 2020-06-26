using BusinessLayer;
using Model.Entities;
using System;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class NoteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoteAction(int noteID, int eleveID)
        {
            if(noteID == 0)
            {
                NoteViewModel noteVM = new NoteViewModel { EleveId = eleveID, DateNote = DateTime.Now.Date };
                return View("AjoutNote", noteVM);
            }
            else
            {
                Note n = BusinessManager.Instance.GetNoteById(noteID);
                NoteViewModel noteVM = new NoteViewModel { Valeur = n.Valeur, Matiere = n.Matiere, Appreciation = n.Appreciation, DateNote = n.DateNote, EleveId = n.EleveId, NoteId = n.NoteId };
                return View("ModifierNote", noteVM);
            }
        }

        public ActionResult AjoutNote(NoteViewModel noteVM)
        {
            ViewBag.Message = "Ajout d'une note.";
            if (!ModelState.IsValid)
            {
                return View("AjoutNote", noteVM);
            }

            Note note;
            note = new Note { Valeur = noteVM.Valeur, Matiere = noteVM.Matiere, Appreciation = noteVM.Appreciation, DateNote = noteVM.DateNote, EleveId = noteVM.EleveId };
            BusinessManager.Instance.AjouterNote(note);

            Eleve e = BusinessManager.Instance.GetEleveById(noteVM.EleveId);
            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance };

            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = noteVM.EleveId });
        }

        public ActionResult ModifierNote(NoteViewModel noteVM)
        {
            ViewBag.Message = "Modification d'une note.";
            if (!ModelState.IsValid)
            {
                return View("ModifierNote", noteVM);
            }

            Note note;
            note = new Note { Valeur = noteVM.Valeur, Matiere = noteVM.Matiere, Appreciation = noteVM.Appreciation, DateNote = noteVM.DateNote, EleveId = noteVM.EleveId, NoteId = noteVM.NoteId };
            BusinessManager.Instance.ModifierNote(note);

            Eleve e = BusinessManager.Instance.GetEleveById(noteVM.EleveId);
            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance };

            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = noteVM.EleveId });
        }

        public ActionResult SupprNote(int eleveID, int noteID)
        {
            ViewBag.Message = "Supression d'une note.";
            BusinessManager.Instance.SupprimerNote(noteID);
            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = eleveID });
        }
    }
}