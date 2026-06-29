using System;
using System.Collections.Generic;
using Baufflaechenverwaltung;

Console.WriteLine("Digitale Flächenverwaltungsplattform");

// Beispielhafte Umsetzung der Modelle
var grundstueck = new Grundstueck
{
    Flurstuecknummer = "0015 00012 001/002",
    Groesse = 1200.5,
    Lage = "Leipzig-Nord",
    AktuelleNutzung = Nutzung.Brachfläche,
    Bebaubarkeit = Bebaubarkeit.Ja,
    BPlanNummer = "BP-2022-089 – Wohngebiet Leipzig-Nord",
    Bodenrichtwert = 500m,
    Eigentuemer = "Max Mustermann"
};

var flaeche1 = new Bauflaeche { Status = FlaechenStatus.Frei };
var flaeche2 = new Bauflaeche { Status = FlaechenStatus.Frei };
grundstueck.Bauflaechen.Add(flaeche1);
grundstueck.Bauflaechen.Add(flaeche2);

var vorhaben = new Bauvorhaben
{
    Antragsteller = new Antragsteller { Name = "Erika Musterfrau", Firma = "Bau AG", Kontaktdaten = "erika@bauag.de" },
    GeplanteNutzung = GeplanteNutzung.Wohngebäude,
    Beginn = DateTime.Now.AddMonths(1),
    Fertigstellung = DateTime.Now.AddYears(1),
    Status = VorhabenStatus.AntragEingereicht
};

vorhaben.ZugeordneteFlaechen.Add(flaeche1);
flaeche1.Status = FlaechenStatus.Reserviert;

Console.WriteLine($"Grundstück {grundstueck.Flurstuecknummer} mit {grundstueck.Bauflaechen.Count} Flächen verwaltet.");
Console.WriteLine($"Bauvorhaben von {vorhaben.Antragsteller.Name} ist {vorhaben.Status} und nutzt {vorhaben.ZugeordneteFlaechen.Count} Fläche(n).");