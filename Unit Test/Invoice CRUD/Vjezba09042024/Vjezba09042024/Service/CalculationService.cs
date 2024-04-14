using System.Reflection.Metadata.Ecma335;

namespace Vjezba09042024.Service
{
    public class CalculationService
    {
        public int Zbroj(int brojA, int brojB)
        {
            return brojA + brojB;
        }
        public int Razlika(int brojA, int brojB)
        {
            return brojA - brojB;
        }
        public int Umnozak(int brojA, int brojB)
        {
            return brojA * brojB;
        }
        public int Kolicnik(int brojA, int brojB)
        {
            return brojA / brojB;
        }
    }
}
