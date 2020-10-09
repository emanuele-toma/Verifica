using System;

namespace Verifica
{
    class Program
    {
        public struct Prodotto
        {
            public string nome;
            public string descrizione;
            public string categoria;
            public decimal prezzo;
            public int id;
        }
        static void Main(string[] args)
        {
            Console.Title = "Gestore catalogo";

            int daInserire = default, scelta = default, i = default, x = default, input = default, id = default;
            decimal media = default;
            string inputStr = default;
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
                Console.WriteLine("#  3) Mostra tutti i prodotti                     #");
                Console.WriteLine("#  4) Media prezzo prodotti                       #");
                Console.WriteLine("#  5) Elimina prodotti                            #");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("###################################################");
                Console.WriteLine("#                   Categorie                     #");
                Console.WriteLine("###################################################");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("#  6) Mostra prodotti in categoria                #");
                Console.WriteLine("#  7) Media prodotti in categoria                 #");
                Console.WriteLine("#  8) Elimina prodotti in categoria               #");
                Console.WriteLine("#                                                 #");
                Console.WriteLine("###################################################");
                Console.WriteLine("#  0) Esci                                        #");
                Console.WriteLine("###################################################");
                Console.Write("Scegli un opzione: ");
                scelta = int.Parse(Console.ReadKey().KeyChar.ToString());
                i = default;
                x = default;
                media = default;
                input = default;
                trovato = default;
                inputStr = default;

                Console.Clear();

                switch (scelta)
                {
                    case 0:
                        {
                            quit = true;
                            break;
                        }
                    case 1:
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
                                Console.Write("Categ. : ");
                                nuovoProdotto.categoria = Console.ReadLine();
                                Console.Write("Prezzo : ");

                                nuovoProdotto.prezzo = decimal.Parse(Console.ReadLine());
                                nuovoProdotto.id = id * 10;
                                listaProdotti[id] = nuovoProdotto;
                                id++;
                                i++;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Inserisci l'id del prodotto da modificare: ");
                            input = int.Parse(Console.ReadLine());
                            while (i < id && !trovato)
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
                                Console.WriteLine($"Categ. : {listaProdotti[i].categoria}");
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
                                    Console.Write("Categ. : ");
                                    listaProdotti[i].categoria = Console.ReadLine();
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
                            
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Lista dei prodotti nel catalogo:");
                            while (i < id)
                            {
                                if (listaProdotti[i].nome != null)
                                {
                                    Console.WriteLine("###################################################");
                                    Console.WriteLine($"Nome   : {listaProdotti[i].nome}");
                                    Console.WriteLine($"Descr. : {listaProdotti[i].descrizione}");
                                    Console.WriteLine($"Categ. : {listaProdotti[i].categoria}");
                                    Console.WriteLine($"Prezzo : EUR {listaProdotti[i].prezzo}");
                                    Console.WriteLine($"ID     : {listaProdotti[i].id}");
                                }
                                i++;

                            }
                            Console.WriteLine("###################################################");
                            break;
                        }

                    case 4:
                        {
                            while (i < id)
                            {
                                if (listaProdotti[i].prezzo != 0)
                                {
                                    x++;
                                    media += listaProdotti[i].prezzo;
                                }
                                i++;
                            }
                            media /= x;
                            Console.WriteLine($"La media del costo di {x} prodotti è di {media} euro");
                            break;
                        }

                    case 5:
                        {
                            Console.Write("Inserisci l'id del prodotto da eliminare: ");
                            input = int.Parse(Console.ReadLine());
                            while (i < id && !trovato)
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
                                Console.WriteLine($"Categ. : {listaProdotti[i].categoria}");
                                Console.WriteLine($"Prezzo : {listaProdotti[i].prezzo} euro");
                                Console.WriteLine($"ID     : {listaProdotti[i].id}");
                                Console.WriteLine("###################################################");
                                Console.WriteLine("Vuoi eliminare questo elemento? [S/N]");

                                if (Console.ReadKey(true).Key == ConsoleKey.S)
                                {
                                    listaProdotti[i] = default;
                                    Console.WriteLine($"Prodotto con id {input} eliminato con successo");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun prodotto trovato con id " + input);
                            }
                            break;
                        }

                    case 6:
                        {
                            Console.Write("Inserisci la categoria del prodotto da mostrare: ");
                            inputStr = Console.ReadLine();
                            while (i < id)
                            {
                                if (listaProdotti[i].categoria == inputStr)
                                {
                                    Console.WriteLine("###################################################");
                                    Console.WriteLine($"Nome   : {listaProdotti[i].nome}");
                                    Console.WriteLine($"Descr. : {listaProdotti[i].descrizione}");
                                    Console.WriteLine($"Categ. : {listaProdotti[i].categoria}");
                                    Console.WriteLine($"Prezzo : EUR {listaProdotti[i].prezzo}");
                                    Console.WriteLine($"ID     : {listaProdotti[i].id}");
                                }
                                i++;

                            }
                            Console.WriteLine("###################################################");
                            break;
                        }
                    case 7:
                        {

                            Console.Write("Inserisci la categoria del prodotto da mostrare: ");
                            inputStr = Console.ReadLine();
                            while (i < id)
                            {
                                if (listaProdotti[i].prezzo != 0 && listaProdotti[i].categoria == inputStr)
                                {
                                    x++;
                                    media += listaProdotti[i].prezzo;
                                }
                                i++;
                            }

                            if (x != 0)
                            {
                                media /= x;
                                Console.WriteLine($"La media del costo di {x} prodotti nella categoria '{inputStr}' è di {media} euro");
                            }
                            else
                            {
                                Console.WriteLine($"Nessun prodotto trovato nella categoria '{inputStr}'");
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.Write("Inserisci la categoria dei prodotti da eliminare: ");
                            inputStr = Console.ReadLine();
                            Console.WriteLine("Vuoi eliminari questi elementi? [S/N]");
                            if (Console.ReadKey(true).Key == ConsoleKey.S)
                            {
                                while (i < id)
                                {
                                    if (listaProdotti[i].categoria == inputStr)
                                    {
                                        listaProdotti[i] = default;
                                    }
                                    i++;
                                }
                                Console.WriteLine($"Tutti i prodotti nella categoria '{inputStr}' sono stati eliminati");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opzione non valida...");
                            break;
                        }
                }
                Console.Write("\nPremi un tasto per tornare al menù...");
                Console.ReadKey();
            }
        }
    }
}
