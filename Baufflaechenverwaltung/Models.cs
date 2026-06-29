using System;
using System.Collections.Generic;

namespace Baufflaechenverwaltung
{
    public enum Nutzung
    {
        Gewerbe, Landwirtschaft, Forst, Wohnnutzung, Brachfläche
    }

    public enum Bebaubarkeit
    {
        Ja, Nein, Auflagen
    }

    public enum FlaechenStatus
    {
        Frei, Reserviert, Bebaut
    }

    public enum VorhabenStatus
    {
        AntragEingereicht, Genehmigt, Abgelehnt, InBearbeitung, Abgeschlossen
    }

    public enum GeplanteNutzung
    {
        Wohngebäude, Gewerbe, Infrastruktur
    }

    public class Antragsteller
    {
        public string Name { get; set; } = string.Empty;
        public string Kontaktdaten { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;
    }

    public class Bauflaeche
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public FlaechenStatus Status { get; set; } = FlaechenStatus.Frei;
    }

    public class Grundstueck
    {
        public string Flurstuecknummer { get; set; } = string.Empty;
        public double Groesse { get; set; }
        public string Lage { get; set; } = string.Empty;
        public Nutzung AktuelleNutzung { get; set; }
        public Bebaubarkeit Bebaubarkeit { get; set; }
        public string BPlanNummer { get; set; } = string.Empty;
        public decimal Bodenrichtwert { get; set; }
        public string Eigentuemer { get; set; } = string.Empty;
        public List<Bauflaeche> Bauflaechen { get; set; } = new List<Bauflaeche>();

        public bool IstBebaubar()
        {
            return Bebaubarkeit == Bebaubarkeit.Ja || Bebaubarkeit == Bebaubarkeit.Auflagen;
        }
    }

    public class Bauvorhaben
    {
        public Antragsteller Antragsteller { get; set; } = new Antragsteller();
        public GeplanteNutzung GeplanteNutzung { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Fertigstellung { get; set; }
        public VorhabenStatus Status { get; set; }
        public List<Bauflaeche> ZugeordneteFlaechen { get; set; } = new List<Bauflaeche>();
    }
}