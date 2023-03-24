using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AB02b_A8_PROGII
{
    internal class DBHandler
    {
        public void createOe(string name, string kuerzel)
        {

            using (Context context = new Context())
            {
                Organisationseinheit oe = new Organisationseinheit()
                {
                    Name = name,
                    Kuerzel = kuerzel
                };
                context.Organisationseinheiten.Add(oe);
                context.SaveChanges();
            }
        }
        public void createMitarbeiter(string name, string vorname, string adresse, int oeid)
        {

            using (Context context = new Context())
            {
                Mitarbeiter mitarbeiter = new Mitarbeiter()
                { 
                  Name = name, 
                  Vorname = vorname,
                  Adresse = adresse,
                  OeID = oeid
                };
                context.Mitarbeiter.Add(mitarbeiter);
                context.SaveChanges();
            }
        }

        public void deleteOe(string kuerzel)
        {

            using (Context context = new Context()) 
            {
                var oeIdToRemove = context.Organisationseinheiten
                    .Where(orgs => orgs.Kuerzel == kuerzel)
                    .Select(orgs => orgs.OeID)
                    .FirstOrDefault();

                Organisationseinheit oeToRemove = context.Organisationseinheiten.Find(oeIdToRemove);
                context.Organisationseinheiten.Remove(oeToRemove);
                context.SaveChanges();
            }
        }

        public void deleteMitarbeiter(int id)
        {
            using (Context context = new Context())
            {
                Mitarbeiter mitarbeiter = context.Mitarbeiter.Find(id);
                context.Mitarbeiter.Remove(mitarbeiter);
                context.SaveChanges();
            }
        }

        public void updateOe(string kuerzel)
        {

            using (var context = new Context())
            {
                var oeIdToUpdate = context.Organisationseinheiten
                    .Where(orgs => orgs.Kuerzel == kuerzel)
                    .Select(orgs => orgs.OeID)
                    .ToList();

                foreach (int id in oeIdToUpdate)
                {
                    Organisationseinheit oe = context.Organisationseinheiten.Find(id);
                    oe.Name = "this was changed";
                }
                context.SaveChanges();

            }
        }

        public void updateMitarbeiter(int id, string input) 
        {
            using (var context = new Context())
            {
                Mitarbeiter ma = context.Mitarbeiter.Find(id);
                ma.Vorname = input;
                context.SaveChanges();
            }
        }
    }
}
