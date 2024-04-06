namespace Primjer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listaVoca = new List<string>() { "Limun", "Jabuka", "Naranca", "Limeta", "Lubenica", "Borovnica"};

            IEnumerable<string> voceSaSlovomL = from voce in listaVoca where voce[0] == 'L' select voce;
            //IEnumerable<string> voceSaSlovomL = listaVoca.Where(y => y[0] == 'L').ToList();

            foreach (string voce in voceSaSlovomL)
            {
                Console.WriteLine(voce);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
