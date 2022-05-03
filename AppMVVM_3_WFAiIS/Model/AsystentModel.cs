using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVM_3_WFAiIS.Model
{
    public class AsystentModel
    {
        public decimal Suma { get { return suma; } init { suma = value; } }
        public decimal Limit { get; init; }

        private decimal suma { get; set; }

        public void DodajKwote(decimal kwota)
        {
            bool warunek = CzyKwotaJestPoprawna(kwota);
            if (!warunek)
                throw new ArgumentOutOfRangeException("Kwota zbyt duża lub ujemna");
            
            suma += kwota;
        }

        public AsystentModel(decimal limit, decimal suma = 0)
        {
            Suma = suma;
            Limit = limit;
        }

        public bool CzyKwotaJestPoprawna(decimal kwota)
        {
            bool czyKwotaJestDodatnia = kwota > 0;
            bool czyPrzekroczyLimit = kwota + Suma > Limit;
            return czyKwotaJestDodatnia && !czyPrzekroczyLimit;
        }

    }
}
