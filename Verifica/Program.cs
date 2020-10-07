using System;

namespace Verifica
{
    class Program
    {
        public struct Prodotto
        {
            public string nome;
            public string descrizione;
            public decimal prezzo;
            public int id;
        }
        static void Main(string[] args)
        {
            Console.Title = "Gestore catalogo";

            int daInserire = default, scelta = default, i = default, input = default, id = default;
            bool quit = default, trovato = default;
            Prodotto nuovoProdotto = default;
            Prodotto[] listaProdotti = new Prodotto[1000];
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("###################################################");
                Console.WriteLine("#                      Menù                       #");
                Console.WriteLine("###################################################");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("#  1) Aggiungi prodotti                           #");
                Console.WriteLine("#  2) Modifica prodotti esistenti                 #");
                Console.WriteLine("#  3) Mostra prodotti                             #");
                Console.WriteLine("#  4) Elimina prodotti                            #");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("#  0) Esci                                        #");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("###################################################");
                Console.Write("Scegli un opzione: ");
                scelta = int.Parse(Console.ReadKey().KeyChar.ToString());
                i = default;
                input = default;
                trovato = default;
                
                Console.Clear();

                if (scelta == 0)
                {
                    quit = true;
                }
                else if (scelta == 1)
                {
                    Console.Write("Quanti prodotti vuoi inserire?: ");
                    daInserire = int.Parse(Console.ReadLine());

                    while (i < daInserire)
                    {
                        Console.WriteLine("###################################################");
                        Console.Write("Nome   : ");
                        nuovoProdotto.nome = Console.ReadLine();
                        Console.Write("Descr. : ");
                        nuovoProdotto.descrizione = Console.ReadLine();
                        Console.Write("Prezzo : ");

                        nuovoProdotto.prezzo = decimal.Parse(Console.ReadLine());
                        nuovoProdotto.id = id * 10;
                        listaProdotti[id] = nuovoProdotto;
                        id++;
                        i++;
                    }
                }
                else if (scelta == 2)
                {
                    Console.Write("Inserisci l'id del prodotto da modificare: ");
                    input = int.Parse(Console.ReadLine());
                    while (i < listaProdotti.Length && !trovato)
                    {
                        if (listaProdotti[i].id == input)
                        {
                            trovato = true;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    if (trovato)
                    {
                        Console.WriteLine("###################################################");
                        Console.WriteLine($"Nome   : {listaProdotti[i].nome}");
                        Console.WriteLine($"Descr. : {listaProdotti[i].descrizione}");
                        Console.WriteLine($"Prezzo : EUR {listaProdotti[i].prezzo}");
                        Console.WriteLine($"ID     : {listaProdotti[i].id}");
                        Console.WriteLine("###################################################");
                        Console.WriteLine("Vuoi modificare questo elemento? [S/N]");

                        if (Console.ReadKey(true).Key == ConsoleKey.S)
                        {
                            Console.WriteLine("###################################################");
                            Console.Write("Nome   : ");
                            listaProdotti[i].nome = Console.ReadLine();
                            Console.Write("Descr. : ");
                            listaProdotti[i].descrizione = Console.ReadLine();
                            Console.Write("Prezzo : ");
                            listaProdotti[i].prezzo = decimal.Parse(Console.ReadLine());
                            Console.Write("ID     : ");
                            listaProdotti[i].id = int.Parse(Console.ReadLine());
                            Console.WriteLine("###################################################");
                            Console.WriteLine($"Prodotto con id {listaProdotti[i].id} modificato con successo");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessun prodotto trovato con id " + input);
                    }
                    Console.Write("Premi un tasto per tornare al menù...");
                    Console.ReadKey();
                }
                else if (scelta == 3)
                {
                    Console.WriteLine("Lista dei prodotti nel catalogo:");
                    while (i < listaProdotti.Length)
                    {
                        if(listaProdotti[i].nome != null)
                        {
                            Console.WriteLine("###################################################");
                            Console.WriteLine($"Nome   : {listaProdotti[i].nome}");
                            Console.WriteLine($"Descr. : {listaProdotti[i].descrizione}");
                            Console.WriteLine($"Prezzo : EUR {listaProdotti[i].prezzo}");
                            Console.WriteLine($"ID     : {listaProdotti[i].id}");
                        }      
                        i++;

                    }
                    Console.WriteLine("###################################################");
                    Console.Write("Premi un tasto per tornare al menù...");
                    Console.ReadKey();
                } else if (scelta == 4)
                {
                    Console.Write("Inserisci l'id del prodotto da eliminare: ");
                    input = int.Parse(Console.ReadLine());
                    while (i < listaProdotti.Length && !trovato)
                    {
                        if(listaProdotti[i].id == input)
                        {
                            trovato = true;
                        } else
                        {
                            i++;
                        }
                    }

                    if (trovato)
                    {
                        Console.WriteLine("###################################################");
                        Console.WriteLine($"Nome   : {listaProdotti[i].nome}");
                        Console.WriteLine($"Descr. : {listaProdotti[i].descrizione}");
                        Console.WriteLine($"Prezzo : EUR {listaProdotti[i].prezzo}");
                        Console.WriteLine($"ID     : {listaProdotti[i].id}");
                        Console.WriteLine("###################################################");
                        Console.WriteLine("Vuoi eliminare questo elemento? [S/N]");

                        if(Console.ReadKey(true).Key == ConsoleKey.S)
                        {
                            listaProdotti[i].nome = default;
                            listaProdotti[i].descrizione = default;
                            listaProdotti[i].prezzo = default;
                            listaProdotti[i].id = default;
                            Console.WriteLine($"Prodotto con id {input} eliminato con successo");
                        }
                    } else
                    {
                        Console.WriteLine("Nessun prodotto trovato con id " + input);
                    }
                    Console.Write("Premi un tasto per tornare al menù...");
                    Console.ReadKey();
                }
            }
        }
    }
}
