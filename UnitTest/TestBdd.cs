using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System.Linq;

namespace UnitTest
{
    /// <summary>
    /// Classe qui permet de tester la BDD.
    /// </summary>
    [TestClass]
    public class TestBdd
    {
        public static Contexte contexte;

        public TestBdd() {}

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Méthode appellée avant le 1er test, permet d'instancier le contexte.
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            contexte = new Contexte();
        }

        /// <summary>
        /// Méthode qui test l'ajout d'une classe en BDD.
        /// </summary>
        [TestMethod]
        public void TestAddClasse()
        {
            contexte.Classes.Add(new Classe { NomEtablissement = "Etablissement 1", Niveau = "Seconde" });
            contexte.SaveChanges();
            Assert.IsTrue(contexte.Classes.Count() == 1);
        }

        /// <summary>
        /// Méthode qui test l'ajout d'un élève en BDD.
        /// </summary>
        [TestMethod]
        public void TestAddEleve()
        {
        }
    }
}
