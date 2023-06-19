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
        public Piwo(string QuestionID, string Quest) { this.PiwoID = QuestionID; this.Opis = Quest; }
        public Piwo() { Ulubione = false; }
    }
}
