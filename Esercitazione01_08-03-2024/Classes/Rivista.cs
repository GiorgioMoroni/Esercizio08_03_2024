using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione01_08_03_2024.Classes
{
    internal class Rivista : Pubblicazione
    {
        public static int ContatoreRiviste { get; set; } = 0;
        

        public Rivista() { }

        public Rivista(string? titolo, string? categoria, DateTime dataPubblicazione)
        {
            Titolo = titolo;
            Categoria = categoria;
            DataPubblicazione = dataPubblicazione;
            
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"[RIVISTA] {Titolo} {Categoria} {DataPubblicazione.ToString("dd/MM/yyyy")}");
        }

        public static void stampaContatoreRiviste()
        {
            Console.WriteLine($"Il numero di Riviste è: {ContatoreRiviste}");
        }

        public override void stampaDataVendita()
        {
            Console.WriteLine(DataVendita.ToString("dd/MM/yyyy"));
        }

    }
}
