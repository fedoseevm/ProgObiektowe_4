using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern.classes
{
    internal class LuksusowyPokojBuilder : IPokojBuilder
    {
        PokojHotelowy pokoj = new PokojHotelowy();

        public void UstawTyp()
        {
            pokoj.Typ = "Luksusowy";
        }
        public void DodajBalkon()
        {
            pokoj.Balkon = true;
        }

        public void DodajKlimatyzacje()
        {
            pokoj.Klimatyzacja = true;
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
