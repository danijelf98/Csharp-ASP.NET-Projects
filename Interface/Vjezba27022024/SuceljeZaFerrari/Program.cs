using SuceljeZaFerrari.Model;
using SuceljeZaFerrari.Model.Automobil;
using SuceljeZaFerrari.Model.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SuceljeZaFerrari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesi vozaca: ");
            var vozac = Console.ReadLine();
            var auto = new Ferrari(vozac, "488-Spider");

            //Console.WriteLine(typeof(Ferrari).Name);
            //Console.WriteLine(typeof(Ferrari).FullName);
            //Console.WriteLine(typeof(Ferrari).Namespace);

            bool jeKreiran = typeof(IAutomobil).IsInterface;

            if (!jeKreiran)
            {
                throw new Exception("Nije stvoreno sucelje IAutomobil");
            }

            if (auto is IAutomobil)
            {
                Console.WriteLine("Instanca auto ima implementiran interface IAutomobil");
            }

        }
    }
}
