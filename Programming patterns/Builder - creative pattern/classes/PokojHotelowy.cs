using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern.classes
{
    internal class PokojHotelowy
    {
        public string Typ;
        public bool Balkon;
        public bool Klimatyzacja;
        public bool Telewizor;
        public bool Lodowka;


        public string Describe()
        {
            return $"Typ: {Typ} \nBalkon: {Balkon} \nKlimatyzacja: {Klimatyzacja} \nTelewizor: {Telewizor} \nLodowka: {Lodowka}";
        }
    }
}
