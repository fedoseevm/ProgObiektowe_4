using Builder___creative_pattern.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___creative_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recepcja recepcja = new Recepcja();
            StandardowyPokojBuilder standardBuilder = new StandardowyPokojBuilder();
            LuksusowyPokojBuilder luksusBuilder = new LuksusowyPokojBuilder();

            PokojHotelowy pokojStandard = recepcja.PrzygotujPokoj(standardBuilder);
            PokojHotelowy pokojLuksus = recepcja.PrzygotujPokoj(luksusBuilder);

            Console.WriteLine(pokojStandard.Describe());
            Console.WriteLine();
            Console.WriteLine(pokojLuksus.Describe());
        }
    }
}
