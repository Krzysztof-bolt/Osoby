using BibliotekaWspolna;
using Biblioteka;
using System.Security.Cryptography;

void Linia()
{
    for (int i = 0; i <= 100; i++)
    {
        Write("-");
    }
    WriteLine();
}

Osoba o1 = new Osoba();
WriteLine(o1.ToString());

o1.Nazwisko = "Adam Nowak";
o1.DataUrodzenia = new DateTime(1995, 12, 22);

WriteLine(format: "{0} urodzil sie w {1:dddd, d MMMM yyyy}",
    arg0: o1.Nazwisko,
    arg1: o1.DataUrodzenia);

Osoba o2 = new()
{
    Nazwisko = "Alicja Kowlaska",
    DataUrodzenia = new DateTime(1998, 3, 17)
};

WriteLine(format: "{0} urodzila sie {1: d MMM yy}",
    arg0: o2.Nazwisko,
    arg1: o2.DataUrodzenia);

o1.UlubionyAntycznyCud = AntyczneCudaSwiata.PosagZeusaWOlimpii;
WriteLine(format: "Ulubiony cud {0} to {1}, a jego liczbowa reprezenacja to {2}",
    arg0: o1.Nazwisko,
    arg1: o1.UlubionyAntycznyCud,
    arg2: (int)o1.UlubionyAntycznyCud);

o1.Dzieci.Add(new() { Nazwisko = "Alfred" });
o1.Dzieci.Add(new Osoba { Nazwisko = "Zuza" });

WriteLine($"{o1.Nazwisko} ma {o1.Dzieci.Count} dzieci:");

for(int dziecko = 0; dziecko < o1.Dzieci.Count; dziecko++)
{
    WriteLine($"> {o1.Dzieci[dziecko].Nazwisko}");
}

Linia();

KontoBankowe.Oprocentowanie = 0.012M;

KontoBankowe kb1 = new();

kb1.NazwaKonta = "Pani Jadzia";
kb1.Saldo = 2400;

WriteLine(format: "{0} zarobila {1:C} na odsetakch.",
    arg0: kb1.NazwaKonta,
    arg1: kb1.Saldo * KontoBankowe.Oprocentowanie);

KontoBankowe kb2 = new();

kb2.NazwaKonta = "Pan Hilary";
kb2.Saldo = 98;

WriteLine(format: "{0} zarobil {1:C} na dosetkach.",
    arg0: kb2.NazwaKonta,
    arg1: kb2.Saldo * KontoBankowe.Oprocentowanie);

Linia();

WriteLine($"{o1.Nazwisko} to {Osoba.Gatunek}.");

WriteLine($"{o1.Nazwisko} pochodzi z planety {o1.Planeta}."); 

Linia();

Osoba o3 = new Osoba();
WriteLine(format:
    "{0} z planety {1}, utworzono o godzinie {2:hh:mm:ss} w dniu {2:dddd}.",
    arg0: o3.Nazwisko,
    arg1: o3.Planeta,
    arg2: o3.Utworzono);

Linia();

Osoba o4 = new(wstepneNazwisko: "Artur", wstepnaPlanetaPochodzenia: "Mars");

WriteLine(format:
    "{0} z planety {1}, utworzono o godzinie {2:hh:mm:ss} w dniu {2:dddd}.",
    arg0: o4.Nazwisko,
    arg1: o4.Planeta,
    arg2: o4.Utworzono);

Linia();

o1.WypiszWKonsoli();
WriteLine(o1.PodajPochodzenie());

Linia();

(string, int) owoc = o1.WezOwoce();
WriteLine($"{owoc.Item1}, jest ich {owoc.Item2}");

var owocNazwany = o1.WezNazwaneOwoce();
WriteLine($"{owocNazwany.Nazwa}, jest ich {owocNazwany.Liczba}");

var krotka1 = ("Mateusz", 4);
WriteLine($"{krotka1.Item1} ma {krotka1.Item2} dzieci");

var krotka2 = (o1.Nazwisko, o1.Dzieci.Count);
WriteLine($"{krotka2.Nazwisko} ma {krotka2.Count} dzieci");

(string nazwaOwocu, int liczbaOwocow) = o1.WezOwoce();
WriteLine($"Po dekonstrukcji: {nazwaOwocu}, {liczbaOwocow}");