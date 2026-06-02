using System;
using System.Collections.Generic;

namespace RDR2_Visual_Novel.Modele
{
    // Această clasă reprezintă o decizie (un buton de pe ecran)
    public class Decizie
    {
        public string Text { get; set; }           // Textul de pe buton (ex: "Merg la vânătoare")
        public string TargetBlock { get; set; }    // ID-ul blocului unde te trimite (în loc de pasPoveste = 14)
        public int EfectApreciere { get; set; } = 0; // Câte puncte primești/pierzi când iei decizia
        public int ConditieMinima { get; set; } = -999;
        public int ConditieMaxima { get; set; } = 999;
    }

    // Această clasă reprezintă o etapă a poveștii (un fost "case" din switch)
    public class BlocPoveste
    {
        public string Id { get; set; }             // Identificatorul unic (ex: "alegere_vantoare" sau pur și simplu "10")
        public string NumePersonaj { get; set; }   // Cine vorbește
        public string Text { get; set; }           // Textul poveștii care apare în cutia de dialog
        public string ImagineFundal { get; set; }  // Numele imaginii de fundal (ex: "harta.jpg")
        public string ImaginePersonaj { get; set; } // Ex: "IMG_2747" sau "ARTHURo"
        public bool RotestePersonaj { get; set; } = false; // Dacă e true, va întoarce imaginea în oglindă
        public string MelodieFundal { get; set; }

        // O listă care conține deciziile disponibile în acest bloc (poate fi goală dacă e doar text)
        public List<Decizie> Decizii { get; set; } = new List<Decizie>();
    }
    public class PovesteData
    {
        public List<BlocPoveste> blocks { get; set; }
    }
}

