using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione01_08_03_2024.Classes
{
    internal class Giornale : Pubblicazione
    {

        public static int? ContatoreGiornale { get; set; } = 0;

        public Giornale() { }


        public Giornale(string? titolo, string? categoria, DateTime dataPubblicazione)
        {
            Titolo = titolo;
            Categoria = categoria;
            DataPubblicazione = dataPubblicazione;
            
        }


        public override void stampaDettaglio()
        {
            Console.WriteLine($"[GIORNALE] {Titolo} {Categoria} {DataPubblicazione.ToString("dd/MM/yyyy")}");
        }

        public static void stampaContatoreGiornali()
        {
            Console.WriteLine($"Il numero di Giornali è: {ContatoreGiornale}");
        }

        public override void stampaDataVendita()
        {
            Console.WriteLine(DataVendita.ToString("dd/MM/yyyy"));
        }
    }
}
