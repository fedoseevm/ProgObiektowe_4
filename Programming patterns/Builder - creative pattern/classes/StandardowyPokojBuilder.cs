using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern.classes
{
    internal class StandardowyPokojBuilder : IPokojBuilder
    {
        private PokojHotelowy pokoj = new PokojHotelowy();

        public void UstawTyp()
        {
            pokoj.Typ = "Standardowy";
        }
        public void DodajBalkon()
        {
            pokoj.Balkon = false;
        }

        public void DodajKlimatyzacje()
        {
            pokoj.Klimatyzacja = false;
        }

        public void DodajWyposazenie()
        {
            pokoj.Telewizor = true;
            pokoj.Lodowka = true;
        }

        public PokojHotelowy PoberzPokoj()
        {
            return pokoj;
        }
    }
}
