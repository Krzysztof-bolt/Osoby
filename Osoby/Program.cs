using BibliotekaWspolna;
using BibliotekaNowoczesna;
using Biblioteka;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

//tworzenie lini
void Linia()
{
    for (int i = 0; i <= 100; i++)
    {
        Write("-");
    }
    WriteLine();
}

//tworzenie obiektu klasy osoba
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
//tworzenie obiektu klasy KontoBankowe
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
//krotki

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

Linia();
//dekonstrukcja osoby

var (nazwisko1, dataUrodzenia1) = o1;
WriteLine($"Po dekonstrukcji: {nazwisko1}, {dataUrodzenia1}");

var (nazwisko2, dataUrodzenia2, ulubiony2) = o1;
WriteLine($"Po dekonstrukcji: {nazwisko2}, {dataUrodzenia2}, {ulubiony2}");

Linia();
//Sterowanie przekazywaniem parametrow

WriteLine(o1.PowiedzCzesc());
WriteLine(o1.PowiedzCzesc("Kuba"));

//Parametry opcjonalne
WriteLine(o1.ParametryOpcjonalne());
WriteLine(o1.ParametryOpcjonalne("Skacz!", 98.5));
WriteLine(o1.ParametryOpcjonalne(liczba: 52.7, polecenie: "Kryj sie!"));
WriteLine(o1.ParametryOpcjonalne("Siadaj!", aktywne: false));

//Parametry out/ref

int a = 10;
int b = 20;
int c = 30;

WriteLine($"Przed: a = {a}, b = {b}, c = {c}");
o1.PrzekazywanieParametrow(a, ref b, out c);
WriteLine($"Po: a = {a}, b = {b}, c = {c}");

//Uproszczenie uzyica parametru out

int d =10;
int e = 20;
WriteLine($"Przed: d = {d}, e = {e}, f jeszcze nie istnieje");

o1.PrzekazywanieParametrow(d, ref e, out int f);
WriteLine($"Po: d = {d}, e = {e}, f = {f}");

Linia();

//Kontorla dostepu, wlasciwoci/indeksery

Osoba staszek = new()
{
    Nazwisko = "Stanislaw",
    DataUrodzenia = new DateTime(1972, 1, 27)
};

WriteLine(staszek.Pochodzenie);
WriteLine(staszek.Pozdrowienie);
WriteLine(staszek.Wiek);

//wlasciwosci z mozliwoscia przypisania

staszek.UlubioneLody = "czekoladowe";
WriteLine($"Stanislaw najchetniej je lody {staszek.UlubioneLody}");

string kolor = "zolty";

try
{
    staszek.UlubionyKolorPodstawowy = kolor;
    WriteLine($"Stansilaw najbardiej lubi kolor {staszek.UlubionyKolorPodstawowy}");
}
catch (Exception ex)
{
    WriteLine("Proba przypisania wartosci '{0}' do wlasciwosci '{1}': {2}", kolor, nameof(staszek.UlubionyKolorPodstawowy), ex.Message);
}
Linia();
//obiekt klasy ksiazka
/*
Ksiazka ksiazka = new()
{
    Isbn = "123-4567890123",
    Tytul = "C# i .NET 7. Tworzenie nowoczesnych aplikacji"
};
*/

Ksiazka ksiazka = new(isbn: "123-4567890123", tytul: "C# i .NET 7. Tworzenie nowoczesnych aplikacji")
{
    Autor = "Mark J. Price",
    LiczbaStron = 821
};

WriteLine("{0}: {1}, autor: {2} wielkosc: {3:NO} stron.",
    ksiazka.Isbn, ksiazka.Tytul, ksiazka.Autor, ksiazka.LiczbaStron);

Linia();       

//Indeksery

staszek.Dzieci.Add(new Osoba { Nazwisko = "Karol", DataUrodzenia = new(2010, 3, 18) });
staszek.Dzieci.Add(new Osoba { Nazwisko = "Zosia", DataUrodzenia = new(2020, 12, 24) });

//Pobieranie danych z wlasciwosci dzeici
WriteLine($"Pierwsze dziecko Stanislawa to {staszek.Dzieci[0].Nazwisko}");
WriteLine($"Drugie dziecko Stanislawa to {staszek.Dzieci[1].Nazwisko}");

//Pobieranie danych z indeksu pozycji
WriteLine($"Piersze dziecko Stanislawa to {staszek[0].Nazwisko}");
WriteLine($"Drugie dziecko Stanisalwa to {staszek[1].Nazwisko}");

//Pobieranie danych z indeksera nazwisk
WriteLine($"Dziecko Staszka o imieniu Zosia ma juz {staszek["Zosia"].Wiek} lata.");

Osoba lamech = new() { Nazwisko = "Lamech" };
Osoba ada = new() { Nazwisko = "Ada" };
Osoba silla = new() { Nazwisko = "Silla" };
lamech.Poslub(ada);
Osoba.Poslub(silla, lamech);

if (silla + lamech)
{
    WriteLine($"{silla.Nazwisko} i {lamech.Nazwisko} sa teraz malzenstwem");
}

//wywolanie operatora

Osoba dziecko3 = lamech * ada;
dziecko3.Nazwisko = "Jubal";

Osoba dziecko4 = lamech * silla;
dziecko4.Nazwisko = "Naama";

WriteLine($"{lamech.Nazwisko} jest mezem {lamech.Malzonek?.Nazwisko ?? "nikogo"}");
WriteLine($"{ada.Nazwisko} jest zona {ada.Malzonek?.Nazwisko ?? "nikogo"}");
WriteLine($"{silla.Nazwisko} jest zona {silla.Malzonek?.Nazwisko ?? "nikogo"}");

//wywolanie metody obiektu
Osoba dziecko1 = lamech.ProkreacjaZ(ada);
dziecko1.Nazwisko = "Jubal";
WriteLine($"{dziecko1.Nazwisko} urodzil sie {dziecko1.DataUrodzenia}");

//wywolanie metodu statycznej
Osoba dzicko2 = Osoba.Prokreacja(silla, lamech);
dzicko2.Nazwisko = "Tubal-Kain";

WriteLine($"{lamech.Nazwisko} ma {lamech.Dzieci.Count} dzieci");
WriteLine($"{ada.Nazwisko} ma {ada.Dzieci.Count} dzieci");
WriteLine($"{silla.Nazwisko} ma {silla.Dzieci.Count} dzieci");

for(int i = 0; i < lamech.Dzieci.Count; i++)
{
    WriteLine(format: "{0} ma dziecko nr {1} o imieniu {2}",
        arg0: lamech.Nazwisko,
        arg1: i,
        arg2: lamech.Dzieci[i].Nazwisko);
}

