using System;
using System.Collections.Generic;
using System.IO;
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
                if(pubb.Copie > 0)
                {
                    pubb.stampaDettaglio();
                }
                
            }
        }


        //-------METODO VENDITE-----------
        public void vendita(Pubblicazione p, DateTime data)
        {

            if (p.GetType() == typeof(Rivista) && p.Copie > 0)
            {
                p.Copie--;
                p = new Rivista(p.Titolo, p.Categoria, p.Copie, p.DataPubblicazione); 
                p.DataVendita = data;
                elencoVendite.Add(p);
            }
            else if (p.GetType() == typeof(Giornale) && p.Copie > 0)
            {
                p.Copie--;
                p = new Giornale(p.Titolo, p.Categoria, p.Copie, p.DataPubblicazione);              
                p.DataVendita = data;
                elencoVendite.Add(p);
            }
            else if (p.GetType() == typeof(Rivista) && p.Copie == 0)
            {
                Console.WriteLine($"Numero copie di {p.Titolo} esaurito");
                elenco.Remove(p);
                Pubblicazione.Contatore--;
                Rivista.ContatoreRiviste--;
            }
            else if (p.GetType() == typeof(Giornale) && p.Copie == 0) 
            {
                Console.WriteLine($"Numero copie di {p.Titolo} esaurito");
                elenco.Remove(p);
                Pubblicazione.Contatore--;
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
                        p.stampaDataVendita();
                    }
                    else if(p.Categoria == ricerca)
                    {
                        
                        p.stampaDataVendita();
                    }
                    else if (p.DataVendita.ToString("d") == ricerca)
                    {
                        
                        p.stampaDataVendita();

                    }
                }
            }
        }


        //-------METODO RICERCA PUBBLICAZIONI IN STOCK-----------
        public void ricercaPubblicazioni(string ricerca)
        {
            if (elenco.Any())
            {
                foreach (Pubblicazione p in elenco)
                {
                    if (p.Titolo == ricerca && p.Copie > 0)
                    {
                        p.stampaDettaglio() ;
                       
                    }
                    else if (p.Categoria == ricerca && p.Copie > 0)
                    {
                        p.stampaDettaglio();  
                    }
                    else if (p.DataPubblicazione.ToString("d") == ricerca && p.Copie > 0)
                    {
                        p.stampaDettaglio();
                    }
                }
            }
        }

        //-------METODO SCRITTURA ELENCO PUBBLICAZIONI-----------
        public void salvaElenco()
        {
            if (elenco.Any()){
                string path = "C:\\Users\\utente\\Desktop\\elenco.txt";
                
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Pubblicazione p in elenco)
                        {
                            sw.WriteLine("{0};{1};{2};{3}",
                                p.Titolo,
                                p.Categoria,
                                p.Copie,
                                p.DataPubblicazione.ToString("d"));
                         
                        }
                        sw.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        //-------METODO SCRITTURA ELENCO VENDITE-----------
        public void salvaElencoVendite()
        {
            if (elencoVendite.Any())
            {
                string path = "C:\\Users\\utente\\Desktop\\elencoVendite.txt";

                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Pubblicazione p in elencoVendite)
                        {
                            sw.WriteLine("{0};{1};{2};{3}",
                                p.Titolo,
                                p.Categoria,
                                p.DataPubblicazione.ToString("d"),
                                p.DataVendita.ToString("d"));

                        }
                        sw.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        //-------METODO SCRITTURA ELENCO VENDITE GIORNALIERE-----------
        public void salvaVenditeGiornaliere(DateTime data)
        {
            if (elencoVendite.Any())
            {
                string path = "C:\\Users\\utente\\Desktop\\venditeGiornaliere.txt";
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Pubblicazione p in elencoVendite)
                        {
                            if (p.DataVendita.ToString("d") == data.ToString("d"))
                            {
                                sw.WriteLine("{0};{1};{2};{3}",
                                    p.Titolo,
                                    p.Categoria,
                                    p.DataPubblicazione.ToString("d"),
                                    p.DataVendita.ToString("d"));
                            }

                        }
                        sw.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        //-------METODO STATISTICHE GIORNALIERE-----------
        public void statisticheGiornaliere()
        {
            string path = "C:\\Users\\utente\\Desktop\\statisticheGiornaliere.txt";
            int contatoreG = 0;
            int contatoreR = 0;
            int contatoreSport = 0;
            int contatoreEconomia = 0;
            int contatoreGossip = 0;
            int contatoreQuotidiano = 0;
            int contatoreSettimanale = 0;

            try
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    foreach(Pubblicazione p in elencoVendite)
                    {
                        if(p.GetType() == typeof(Giornale))
                        {
                            contatoreG++;
                        }
                        else if(p.GetType() == typeof(Rivista))
                        {
                            contatoreR++;
                        }

                        switch (p.Categoria)
                        {
                            case "Sport":
                                contatoreSport++;
                                break;

                            case "Economia":
                                contatoreEconomia++;
                                break;

                            case "Gossip":
                                contatoreGossip++;
                                break;

                            case "Quotidiano":
                                contatoreQuotidiano++;
                                break;

                            case "Settimanale":
                                contatoreSettimanale++;
                                break;

                            default:
                                Console.WriteLine("Categoria non presente");
                                break;
                        }
                    }

                    if (contatoreG > contatoreR)
                    {
                        sw.WriteLine("Il tipo più venduto é: GIORNALE");
                    }
                    else if (contatoreR > contatoreG)
                    {
                        sw.WriteLine("Il tipo più venduto é: RIVISTA");
                    }

                    if (contatoreSport > contatoreEconomia && contatoreSport > contatoreGossip && contatoreSport > contatoreQuotidiano && contatoreSport > contatoreSettimanale)
                    {
                        sw.WriteLine("Il più venduto é: GIORNALE DI SPORT");
                    }
                    else if(contatoreEconomia > contatoreSport && contatoreEconomia > contatoreGossip && contatoreEconomia > contatoreQuotidiano && contatoreEconomia > contatoreSettimanale)
                    {
                        sw.WriteLine("Il più venduto é: GIORNALE DI ECONOMIA");
                    }
                    else if (contatoreGossip > contatoreSport && contatoreGossip > contatoreEconomia && contatoreGossip > contatoreQuotidiano && contatoreGossip > contatoreSettimanale)
                    {
                        sw.WriteLine("Il più venduto é: RIVISTA DI GOSSIP");
                    }
                    else if (contatoreQuotidiano > contatoreSport && contatoreQuotidiano > contatoreGossip && contatoreQuotidiano > contatoreEconomia && contatoreQuotidiano > contatoreSettimanale)
                    {
                        sw.WriteLine("Il più venduto é: GIORNALE QUOTIDIANO");
                    }
                    else if (contatoreSettimanale > contatoreSport && contatoreSettimanale > contatoreGossip && contatoreSettimanale > contatoreQuotidiano && contatoreSettimanale > contatoreEconomia)
                    {
                        sw.WriteLine("Il più venduto é: GIORNALE SETTIMANALE");
                    }


                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }














    }
}
