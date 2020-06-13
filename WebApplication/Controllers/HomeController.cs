using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Model.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListEleves()
        {
            ViewBag.Message = "Liste d'élèves.";
            List<Eleve> eleves = BusinessManager.Instance.GetAllEleve();
            List<EleveViewModel> eleveViewModels = new List<EleveViewModel>();
            foreach (Eleve e in eleves)
            {
                eleveViewModels.Add(new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance });
            }
            return View(eleveViewModels);
        }

        public ActionResult AddEleve()
        {
            ViewBag.Message = "Ajouter un élève.";

            return View();
        }

        public ActionResult AddAbsence()
        {
            ViewBag.Message = "Ajouter une absence.";

            return View();
        }
    }
}