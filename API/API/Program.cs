using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using PokeAPI;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon(1);
            Console.Read();
        }

        async static void Pokemon(int pokeID)
        {
            EvolutionChain e = await DataFetcher.GetApiObject<EvolutionChain>(pokeID);
            PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(pokeID);
            Console.WriteLine(e.Chain.Species.Name);
            foreach (var item in e.Chain.EvolvesTo)
            {
                Console.WriteLine(item.Species.Name);
            }
        }
    }
}
