using Vjezba09042024.Service;

namespace Vjezba09042024.UnitTest
{
    public class CalculationServiceUnitTest
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceUnitTest()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void Zbroj_ZbrajaDvaBroja_ProvjeravaOdgovaraLiRezultatZadanomBroju()
        {
            int brojA = 1;
            int brojB = 2;
            int rezultat = 3;

            var rezultatZbrajanja = _calculationService.Zbroj(brojA, brojB);
            Assert.Equal(rezultat, rezultatZbrajanja);
            Assert.NotEqual(2, rezultatZbrajanja);
        }

        [Fact]
        public void Razlika_OduzimaDvaBroja_ProvjeravaOdgovaraLiRezultatZadanomBroju()
        {
            int brojA = 3;
            int brojB = 2;
            int rezultat = 1;

            var rezultatOduzimanja = _calculationService.Razlika(brojA, brojB);
            Assert.Equal(rezultat, rezultatOduzimanja);
            Assert.NotEqual(2, rezultatOduzimanja);
        }

        [Fact]
        public void Umnozak_MnoziDvaBroja_ProvjeravaOdgovaraLiRezultatZadanomBroju()
        {
            int brojA = 3;
            int brojB = 2;
            int rezultat = 6;

            var rezultatMnozenja = _calculationService.Umnozak(brojA, brojB);
            Assert.Equal(rezultat, rezultatMnozenja);
            Assert.NotEqual(2, rezultatMnozenja);
        }

        [Fact]
        public void Kolicnik_DijeliDvaBroja_ProvjeravaOdgovaraLiRezultatZadanomBroju()
        {
            int brojA = 4;
            int brojB = 2;
            int rezultat = 2;

            var rezultatDijeljenja = _calculationService.Kolicnik(brojA, brojB);
            Assert.Equal(rezultat, rezultatDijeljenja);
            Assert.NotEqual(3, rezultatDijeljenja);
        }


    }
}