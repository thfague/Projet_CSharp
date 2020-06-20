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
            EleveViewModel eleveViewModel = new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance };
            return View(eleveViewModel);
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
    }
}