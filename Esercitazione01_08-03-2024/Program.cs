using Esercitazione01_08_03_2024.Classes;

namespace Esercitazione01_08_03_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pubblicazione gio1 = new Giornale("Il Messaggero", "Economia", new DateTime(2024, 03, 08));
            Pubblicazione riv1 = new Rivista("Chi", "Gossip", new DateTime(2024, 02, 09));
            Pubblicazione gio2 = new Giornale("Corriere dello sport", "Sport", new DateTime(2024, 02, 01));
            Pubblicazione gio3 = new Giornale("Leggo", "Quotdiano", new DateTime(2024, 01, 01));
            Pubblicazione riv2 = new Rivista("Tv S&C", "Settimanale", new DateTime(2024, 01, 12));
            Pubblicazione gio4 = new Giornale("Il Messaggero", "Economia", new DateTime(2024, 02, 15));
            Pubblicazione gio5 = new Giornale("Corriere dello sport", "Sport", new DateTime(2024, 02, 03));
            Pubblicazione riv3 = new Rivista("Leggo", "Quotdiano", new DateTime(2024, 01, 02));





            Edicola edicola = new Edicola("Edicola", "Piazza la bomba 1");

            Console.WriteLine("---------------TEST AGGIUNTA E STAMPA PUBBLICAZIONI---------------");
            edicola.aggiungi(gio1);
            edicola.aggiungi(riv1);
            edicola.aggiungi(gio2);
            edicola.aggiungi(gio3);
            edicola.aggiungi(riv2);
            edicola.aggiungi(gio4);
            edicola.aggiungi(gio5);
            edicola.aggiungi(riv3);

            edicola.elencoPubblicazioni();
            Console.WriteLine();

            Console.WriteLine("---------------TEST STAMPA CONTATORI---------------");
            Pubblicazione.stampaContatore();
            Giornale.stampaContatoreGiornali();
            Rivista.stampaContatoreRiviste();
            Console.WriteLine();

            Console.WriteLine("---------------TEST RIMUOVI PUBBLICAZIONE + AGGIORNAMENTO CONTATORI---------------");
            edicola.rimuovi(gio1);
            Pubblicazione.stampaContatore();
            Giornale.stampaContatoreGiornali();
            Rivista.stampaContatoreRiviste();
            edicola.elencoPubblicazioni();
            Console.WriteLine();

            Console.WriteLine("---------------TEST VENDITA PUBBLICAZIONE + AGGIORNAMENTO VENDITE---------------");
            edicola.vendita(gio2);
            edicola.stampaVendite();
            Console.WriteLine();

            Console.WriteLine("---------------TEST RICERCA VENDITE---------------");
            edicola.vendita(gio2);
            edicola.vendita(gio5);
            edicola.vendita(riv2);
            edicola.stampaVendite();
            edicola.ricercaVendite("Corriere dello sport");
            edicola.ricercaVendite("Settimanale");













        }
    }
}
