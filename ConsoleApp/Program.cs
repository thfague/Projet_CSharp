using Model;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Contexte contexte = new Contexte();
                contexte.Classes.ToList();
                contexte.Eleves.ToList();
                contexte.Notes.ToList();
                contexte.Absences.ToList();
            }
            catch (Exception)
            {
                
            }            
        }
    }
}
