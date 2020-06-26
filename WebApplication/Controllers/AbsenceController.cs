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

        public ActionResult AbsenceAction(int eleveID)
        {
            AbsenceViewModel absenceVM = new AbsenceViewModel { EleveId = eleveID };
            return View("AjoutAbsence", absenceVM);
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

        public ActionResult SupprAbsence(int eleveID, int absenceID)
        {
            ViewBag.Message = "Suppression d'une absence.";
            BusinessManager.Instance.SupprimerAbsence(absenceID);
            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveID = eleveID });
        }
    }
}