using AB02b_A8_PROGII;

// See https://aka.ms/new-console-template for more information
DBHandler dbh = new DBHandler();

dbh.createOe("Keine Organisationsheinheit", "keine OE");
dbh.createOe("Entwicklung", "DEV");
dbh.createOe("To Delete", "del");
dbh.createOe("to be changed", "chg");

dbh.createMitarbeiter("Brösmeli", "Guschti", "Hohle Gasse 1, 4500 Solothurn", 1);
dbh.createMitarbeiter("Egger", "Patrick", "Weissensteinstrasse 47, 4500 Solothurn", 2);

dbh.deleteOe("del");
dbh.deleteMitarbeiter(1);
dbh.updateOe("chg");

Console.WriteLine("Bitte anderen Vornamen für Mitarbeiter 1 eingeben:");

string input = Console.ReadLine();

dbh.updateMitarbeiter(1, input);

Console.WriteLine("Fertig!");
