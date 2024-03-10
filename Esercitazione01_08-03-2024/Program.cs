using Esercitazione01_08_03_2024.Classes;

namespace Esercitazione01_08_03_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pubblicazione gio1 = new Giornale("Il Messaggero", "Economia", 10, new DateTime(2024, 03, 08));
            Pubblicazione riv1 = new Rivista("Chi", "Gossip", 8, new DateTime(2024, 02, 09));
            Pubblicazione gio2 = new Giornale("Corriere dello sport", "Sport", 15, new DateTime(2024, 02, 01));
            Pubblicazione gio3 = new Giornale("Leggo", "Quotidiano", 5, new DateTime(2024, 01, 01));
            Pubblicazione riv2 = new Rivista("Tv S&C", "Settimanale", 7, new DateTime(2024, 01, 12));
            Pubblicazione gio4 = new Giornale("Il Messaggero", "Economia", 10, new DateTime(2024, 02, 15));
            Pubblicazione gio5 = new Giornale("Corriere dello sport", "Sport", 15, new DateTime(2024, 02, 03));
            Pubblicazione riv3 = new Rivista("Tv S&C", "Settimanale", 7, new DateTime(2024, 01, 02));

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
            edicola.vendita(gio2, new DateTime(2024, 03, 09));
            edicola.stampaVendite();
            Console.WriteLine();

            Console.WriteLine("---------------TEST RICERCA VENDITE---------------");
            edicola.vendita(gio2, new DateTime(2024, 03, 09));
            edicola.vendita(gio5, new DateTime(2024, 03, 09));
            edicola.vendita(riv3, new DateTime(2024, 03, 09));
            edicola.stampaVendite();
            Console.WriteLine();
            edicola.ricercaVendite("Settimanale");
            Console.WriteLine();

            Console.WriteLine("---------------TEST RICERCA VENDITE PER GIORNO---------------");
            edicola.vendita(gio2, new DateTime(2024, 03, 10));
            edicola.ricercaVendite("10/03/2024");
            Console.WriteLine();

            Console.WriteLine("---------------TEST RICERCA PUBBLICAZIONI IN STOCK---------------");
            edicola.ricercaPubblicazioni("Sport");
            edicola.ricercaPubblicazioni("15/02/2024");
            Console.WriteLine();

            Console.WriteLine("---------------TEST SCRITTURA SU FILE DELL'ELENCO---------------");
            edicola.salvaElenco();
            Console.WriteLine();

            Console.WriteLine("---------------TEST SCRITTURA SU FILE DELLE VENDITE---------------");
            edicola.salvaElencoVendite();
            Console.WriteLine();

            Console.WriteLine("---------------TEST SCRITTURA SU FILE DELLE VENDITE GIORNALIERE---------------");
            edicola.salvaVenditeGiornaliere(new DateTime (2024, 03, 10));
            Console.WriteLine();

            Console.WriteLine("---------------TEST SCRITTURA SU FILE DELLE STATISTICHE---------------");
            edicola.statisticheGiornaliere();








        }
    }
}
