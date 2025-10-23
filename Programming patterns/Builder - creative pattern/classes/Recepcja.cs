using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern.classes
{
    internal class Recepcja
    {
        public PokojHotelowy PrzygotujPokoj(IPokojBuilder builder)
        {
            builder.UstawTyp();
            builder.DodajBalkon();
            builder.DodajKlimatyzacje();
            builder.DodajWyposazenie();

            return builder.PoberzPokoj();
        }
    }
}
