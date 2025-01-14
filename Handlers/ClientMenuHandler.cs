using System;
using proiectul_1.Models;

namespace proiectul_1.Handlers
{
    // File: ClientMenuHandler.cs
    public static class ClientMenuHandler
    {
        public static void ClientMenu(Library library, Client client)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Client ===");
                Console.WriteLine("1. Vizualizare cărți disponibile pentru închiriat");
                Console.WriteLine("2. Închiriere carte selectată");
                Console.WriteLine("3. Restituire carte");
                Console.WriteLine("4. Schimbare nume");
                Console.WriteLine("0. Ieșire");
                Console.Write("Alegeți o opțiune: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAvailableBooks(library);
                        break;
                    case "2":
                        BorrowBook(library, client); // Modificat din RentBook în BorrowBook
                        break;
                    case "3":
                        ReturnBook(library, client);
                        break;
                    case "4":
                        ChangeName(client);
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

        private static void ViewAvailableBooks(Library library)
        {
            Console.WriteLine("=== Cărți Disponibile ===");
            foreach (var book in library.Books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine(book);
                }
            }
            Console.WriteLine("Apăsați Enter pentru a continua...");
            Console.ReadLine();
        }

        private static void BorrowBook(Library library, Client client) // Modificat numele metodei
        {
            Console.Write("Introduceți ISBN-ul cărții dorite: ");
            string isbn = Console.ReadLine();
            var book = library.Books.Find(b => b.ISBN == isbn);

            if (book != null && book.IsAvailable)
            {
                client.BorrowBook(library, isbn); // Folosește metoda BorrowBook din clasa Client
                Console.WriteLine("Cartea a fost închiriată cu succes. Apăsați Enter pentru a continua...");
            }
            else
            {
                Console.WriteLine("Cartea nu este disponibilă sau nu există. Apăsați Enter pentru a continua...");
            }
            Console.ReadLine();
        }

        private static void ReturnBook(Library library, Client client)
        {
            Console.Write("Introduceți ISBN-ul cărții de returnat: ");
            string isbn = Console.ReadLine();
            var book = library.Books.Find(b => b.ISBN == isbn);

            if (book != null && !book.IsAvailable)
            {
                client.ReturnBook(library, isbn);
                Console.WriteLine("Cartea a fost returnată cu succes. Apăsați Enter pentru a continua...");
            }
            else
            {
                Console.WriteLine("Cartea nu se află în posesia dumneavoastră. Apăsați Enter pentru a continua...");
            }
            Console.ReadLine();
        }

        private static void ChangeName(Client client)
        {
            Console.Write("Introduceți noul nume: ");
            string newName = Console.ReadLine();
            client.Name = newName;
            Console.WriteLine("Numele a fost actualizat cu succes. Apăsați Enter pentru a continua...");
            Console.ReadLine();
        }
    }
}
