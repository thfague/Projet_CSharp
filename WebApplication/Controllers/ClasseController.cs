using BusinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ClasseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailClasse(int classeID)
        {
            ViewBag.Message = "Détail classe";
            Classe c = BusinessManager.Instance.GetClasseById(classeID);

            List<Eleve> eleves = BusinessManager.Instance.GetElevesByClasseId(classeID);
            List<EleveViewModel> eleveViewModels = new List<EleveViewModel>();
            foreach (Eleve e in eleves)
            {
                eleveViewModels.Add(new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance, EleveId = e.EleveId });
            }


            ClasseViewModel classeViewModel = new ClasseViewModel { NomEtablissement = c.NomEtablissement, Niveau = c.Niveau, Eleves = eleveViewModels, ClasseId = c.ClasseId };
            return View(classeViewModel);
        }

        public ActionResult ListClasses(string filtre)
        {
            ViewBag.Message = "Liste des classes.";
            List<Classe> classes;

            if (!String.IsNullOrEmpty(filtre))
            {
                classes = BusinessManager.Instance.GetAllClasse().Where(c => c.NomEtablissement.Contains(filtre) || c.Niveau.Contains(filtre)).ToList();
            }
            else
            {
                classes = BusinessManager.Instance.GetAllClasse();

            }
            List<ClasseViewModel> classeViewModels = new List<ClasseViewModel>();
            foreach (Classe c in classes)
            {
                classeViewModels.Add(new ClasseViewModel { NomEtablissement = c.NomEtablissement, Niveau = c.Niveau, ClasseId = c.ClasseId });
            }
            return View(classeViewModels);
        }
    }
}