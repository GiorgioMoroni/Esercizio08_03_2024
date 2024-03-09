using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione01_08_03_2024.Classes
{
    internal class Edicola
    {
        public string? Nome {  get; set; }
        public string? Indirizzo { get; set; }
        private List<Pubblicazione> elenco { get; set; } = new List<Pubblicazione> { };
        private List<Pubblicazione> elencoVendite { get; set; } = new List<Pubblicazione> { };
        


        public Edicola (string? nome, string? indirizzo)
        {
            Nome = nome;
            Indirizzo = indirizzo;
        }


        //-------METODO AGGIUNGI-----------
        public void aggiungi(Pubblicazione p)
        {
            elenco.Add(p);
            Pubblicazione.Contatore++;
            if (p.GetType() == typeof(Rivista))
            {
                Rivista.ContatoreRiviste++;
            }
            else if (p.GetType() == typeof(Giornale))
            {
                Giornale.ContatoreGiornale++;
            }
  
        }

        //-------METODO RIMUOVI-----------
        public void rimuovi(Pubblicazione p)
        {
            elenco.Remove(p);
            Pubblicazione.Contatore--;
            if (p.GetType() == typeof(Rivista))
            {
                Rivista.ContatoreRiviste--;
            }
            else if (p.GetType() == typeof(Giornale))
            {
                Giornale.ContatoreGiornale--;
            }

        }

        //-------METODO STAMPA TUTTE LE PUBBLICAZIONI-----------
        public void elencoPubblicazioni()
        {
            foreach (Pubblicazione pubb in elenco)
            {
                pubb.stampaDettaglio();
            }
        }


        //-------METODO VENDITE-----------
        public void vendita(Pubblicazione p)
        {
            elenco.Remove(p);
            elencoVendite.Add(p);
            Pubblicazione.Contatore--;
            p.DataVendita = new DateTime();
            
            if (p.GetType() == typeof(Rivista))
            {
                Rivista.ContatoreRiviste--;
            }
            else if (p.GetType() == typeof(Giornale))
            {
                Giornale.ContatoreGiornale--;
            }

        }

        //-------METODO STAMPA ELENCO VENDITE-----------
        public void stampaVendite()
        {
            if (elencoVendite.Any())
            {
                foreach (Pubblicazione pubb in elencoVendite)
                {
                    pubb.stampaDettaglio();
                    pubb.stampaDataVendita();
                }
            }
            else
            {
                Console.WriteLine("Nessuna vendita");
            }

        }


        //-------METODO RICERCA VENDITE-----------
        public void ricercaVendite(string ricerca)
        {
            if (elencoVendite.Any())
            {
                foreach(Pubblicazione p in elencoVendite)
                {
                    if(p.Titolo == ricerca)
                    {
                        p.stampaDettaglio() ;
                    }
                    else if(p.Categoria == ricerca)
                    {
                        p.stampaDettaglio();
                    }
                    //else if( p.DataVendita.ToString() == ricerca)
                    //{
                    //    p.stampaDettaglio();
                    //}
                }
            }
        }




    }
}
