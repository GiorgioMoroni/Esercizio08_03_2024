using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione01_08_03_2024.Classes
{
    internal abstract class Pubblicazione
    {
        public string? Titolo { get; set; }
        public string? Categoria { get; set; }
        public DateTime DataPubblicazione { get; set; }
        public DateTime DataVendita { get; set; }
        public static int? Contatore { get; set; } = 0;
        public int Copie { get; set; }



        public abstract void stampaDettaglio();
        

        public static void stampaContatore()
        {
            Console.WriteLine($"Il numero di pubblicazioni è: {Contatore}");
        }

        public abstract void stampaDataVendita();

    }
}
