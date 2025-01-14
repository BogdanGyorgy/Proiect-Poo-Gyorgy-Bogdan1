using proiectul_1.Models;
// File: AuthenticationHandler.cs
using System;
using System.Linq;

namespace proiectul_1.Handlers
{


    namespace LibraryManagementSystem
    {
        public static class AuthenticationHandler
        {
            public static void HandleAuthentication(Library library)
            {
                Console.Clear();
                Console.WriteLine("1. Autentificare");
                Console.WriteLine("2. Înregistrare");
                Console.Write("Alegeți o opțiune: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        User user = AuthenticateUser(library);
                        if (user != null)
                        {
                            if (user is Administrator admin)
                            {
                                AdminMenuHandler.AdminMenu(library, admin);
                            }
                            else if (user is Client client)
                            {
                                ClientMenuHandler.ClientMenu(library, client);
                            }
                        }
                        break;
                    case "2":
                        RegisterUser(library);
                        break;
                    default:
                        Console.WriteLine("Opțiune invalidă. Apăsați Enter pentru a continua...");
                        Console.ReadLine();
                        break;
                }
            }

            private static User AuthenticateUser(Library library)
            {
                Console.Write("Introduceți username: ");
                string username = Console.ReadLine();
                Console.Write("Introduceți parola: ");
                string password = Console.ReadLine();

                User user = library.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    Console.WriteLine($"Autentificare reușită, bine ați venit {user.Name}!");
                    Console.ReadLine();
                    return user;
                }
                else
                {
                    Console.WriteLine("Autentificare eșuată. Apăsați Enter pentru a continua...");
                    Console.ReadLine();
                    return null;
                }
            }

            private static void RegisterUser(Library library)
            {
                Console.Write("Introduceți numele: ");
                string name = Console.ReadLine();
                Console.Write("Introduceți username: ");
                string username = Console.ReadLine();
                Console.Write("Introduceți parola: ");
                string password = Console.ReadLine();
                Console.Write("Este administrator? (y/n): ");
                bool isAdmin = Console.ReadLine().ToLower() == "y";

                if (library.Users.Any(u => u.Username == username))
                {
                    Console.WriteLine("Username deja existent. Apăsați Enter pentru a continua...");
                    Console.ReadLine();
                    return;
                }

                User newUser = isAdmin ? new Administrator(name, username, password) : new Client(name, username, password);
                library.Users.Add(newUser);
                Console.WriteLine("Utilizator înregistrat cu succes! Apăsați Enter pentru a continua...");
                Console.ReadLine();
            }
        }
    }
}

