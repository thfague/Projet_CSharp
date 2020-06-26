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
    public class AbsenceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AbsenceAction(int absenceID, int eleveID)
        {
            if (absenceID == 0)
            {
                AbsenceViewModel absenceVM = new AbsenceViewModel { EleveId = eleveID, DateAbsence = DateTime.Now.Date };
                return View("AjoutAbsence", absenceVM);
            }
            else
            {
                Absence a = BusinessManager.Instance.GetAbsenceById(absenceID);
                AbsenceViewModel absenceVM = new AbsenceViewModel { Motif = a.Motif, DateAbsence = a.DateAbsence, EleveId = a.EleveId, AbsenceId = a.AbsenceId };
                return View("ModifierAbsence", absenceVM);
            }
        }

        public ActionResult AjoutAbsence(AbsenceViewModel absenceVM)
        {
            ViewBag.Message = "Ajout d'une absence.";
            if (!ModelState.IsValid)
            {
                return View("AjoutAbsence", absenceVM);
            }

            Absence absence;
            absence = new Absence { EleveId = absenceVM.EleveId, Motif = absenceVM.Motif, DateAbsence = absenceVM.DateAbsence };
            BusinessManager.Instance.AjouterAbsence(absence);

            Eleve e = BusinessManager.Instance.GetEleveById(absenceVM.EleveId);
            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance };

            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = absenceVM.EleveId });
        }

        public ActionResult ModifierAbsence(AbsenceViewModel absenceVM)
        {
            ViewBag.Message = "Modification d'une absence.";
            if (!ModelState.IsValid)
            {
                return View("ModifierAbsence", absenceVM);
            }

            Absence absence;
            absence = new Absence { Motif = absenceVM.Motif, DateAbsence = absenceVM.DateAbsence, EleveId = absenceVM.EleveId, AbsenceId = absenceVM.AbsenceId };
            BusinessManager.Instance.ModifierAbsence(absence);

            Eleve e = BusinessManager.Instance.GetEleveById(absenceVM.EleveId);
            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance };

            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = absenceVM.EleveId });
        }

        public ActionResult SupprAbsence(int eleveID, int absenceID)
        {
            ViewBag.Message = "Suppression d'une absence.";
            BusinessManager.Instance.SupprimerAbsence(absenceID);
            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = eleveID });
        }
    }
}