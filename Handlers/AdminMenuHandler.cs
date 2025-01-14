using proiectul_1.Models;
// File: AdminMenuHandler.cs
using System;


namespace proiectul_1.Handlers
{
    
   
    
        public static class AdminMenuHandler
        {
            public static void AdminMenu(Library library, Administrator admin)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== Meniu Administrator ===");
                    Console.WriteLine("1. Adăugare carte");
                    Console.WriteLine("2. Ștergere carte");
                    Console.WriteLine("3. Ștergere client");
                    Console.WriteLine("4. Scutire client de datorii");
                    Console.WriteLine("5. Vizualizare istoric închirieri ale bibliotecii");
                    Console.WriteLine("6. Vizualizare istoric închirieri ale unui client");
                    Console.WriteLine("7. Vizualizare câștiguri totale");
                    Console.WriteLine("8. Vizualizare câștiguri pentru o perioadă");
                    Console.WriteLine("0. Ieșire");
                    Console.Write("Alegeți o opțiune: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AddBook(library, admin);
                            break;
                        case "2":
                            RemoveBook(library, admin);
                            break;
                        case "3":
                            RemoveClient(library, admin);
                            break;
                        case "4":
                            ClearClientDebts(library, admin);
                            break;
                        case "5":
                            admin.ViewLibraryLoanHistory(library);
                            break;
                        case "6":
                            ViewClientLoanHistory(library, admin);
                            break;
                        case "7":
                            admin.ViewTotalEarnings(library);
                            break;
                        case "8":
                            ViewEarningsForPeriod(library, admin);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Opțiune invalidă. Apăsați Enter pentru a continua...");
                            Console.ReadLine();
                            break;
                    }
                }
            }

            private static void AddBook(Library library, Administrator admin)
            {
                Console.Write("Introduceți titlul cărții: ");
                string title = Console.ReadLine();
                Console.Write("Introduceți autorul cărții: ");
                string author = Console.ReadLine();
                Console.Write("Introduceți genul cărții: ");
                string genre = Console.ReadLine();
                Console.Write("Introduceți anul publicării: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Introduceți ISBN-ul: ");
                string isbn = Console.ReadLine();
                Console.Write("Este cartea ficțiune? (y/n): ");
                bool isFiction = Console.ReadLine().ToLower() == "y";

                Book book = isFiction ? new FictionBook(title, author, genre, year, isbn) : new NonFictionBook(title, author, genre, year, isbn);
                admin.AddBook(library, book);
            }

            private static void RemoveBook(Library library, Administrator admin)
            {
                Console.Write("Introduceți ISBN-ul cărții de șters: ");
                string isbnToRemove = Console.ReadLine();
                admin.RemoveBook(library, isbnToRemove);
            }

            private static void RemoveClient(Library library, Administrator admin)
            {
                Console.Write("Introduceți username-ul clientului de șters: ");
                string usernameToRemove = Console.ReadLine();
                admin.RemoveClient(library, usernameToRemove);
            }

            private static void ClearClientDebts(Library library, Administrator admin)
            {
                Console.Write("Introduceți username-ul clientului pentru a-l scuti de datorii: ");
                string usernameToClear = Console.ReadLine();
                admin.ClearClientDebts(library, usernameToClear);
            }

            private static void ViewClientLoanHistory(Library library, Administrator admin)
            {
                Console.Write("Introduceți username-ul clientului pentru a vedea istoricul: ");
                string usernameToView = Console.ReadLine();
                admin.ViewClientLoanHistory(library, usernameToView);
            }

            private static void ViewEarningsForPeriod(Library library, Administrator admin)
            {
                Console.Write("Introduceți data de început (yyyy-MM-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Introduceți data de sfârșit (yyyy-MM-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());
                admin.ViewEarningsForPeriod(library, startDate, endDate);
            }
        }
    }


