using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern.classes
{
    internal interface IPokojBuilder
    {
        void UstawTyp();
        void DodajBalkon();
        void DodajKlimatyzacje();
        void DodajWyposazenie();

        PokojHotelowy PoberzPokoj();
    }
}
