using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moje_Piwo.Model
{
    public class Piwo
    {
        public string PiwoID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Rodzaj { get; set; }
        public string Ekstrakt { get; set; }
        public string Cena { get; set; }
        public string Procent { get; set; }
        public string Browar { get; set; }
        public string Kraj { get; set; }
        public string Koncern { get; set; }
        public double Ocena { get; set; }
        public bool Ulubione { get; set; }
        public int intid { get; set; }
        public Piwo(string QuestionID, string Quest) { this.PiwoID = QuestionID; this.Opis = Quest; }
        public Piwo() { Ulubione = false; }
        public Piwo(string PiwoID, string Nazwa, string Opis, string Rodzaj, string Ekstrakt, string Cena, string Procent,
            string Browar, string Kraj, string Koncern, double Ocena, bool Ulubione, int intid)
        {
            this.PiwoID = PiwoID; this.Nazwa = Nazwa; this.Opis = Opis; this.Rodzaj = Rodzaj; this.Ekstrakt = Ekstrakt;
            this.Cena = Cena; this.Procent = Procent; this.Browar = Browar; this.Kraj = Kraj;
            this.Koncern = Koncern; this.Ocena = Ocena; this.Ulubione = Ulubione; this.intid = intid;
        }
    }
}
