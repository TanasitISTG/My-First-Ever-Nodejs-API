using System;
using System.Text.RegularExpressions;
using static ConsoleApplication1.Authorization;
using static ConsoleApplication1.Main;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Options");
            Console.WriteLine("=====================");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Select your option: ");
            
            var isNumber = int.TryParse(Console.ReadLine(), out var option);
            if (!isNumber)
            {
                Console.WriteLine("Invalid option");
            }
            else
            {
                try
                {
                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter your username: ");
                            var username = Console.ReadLine();
                            Console.Write("Enter your password: ");
                            var password = Console.ReadLine();
                            Login(username, password);
                            MainMenu(username);
                            break;
                        case 2:
                            Console.Write("Enter your username: ");
                            username = Console.ReadLine();
                            Console.Write("Enter your email: ");
                            var email = Console.ReadLine();
                            Console.Write("Enter your password: ");
                            password = Console.ReadLine();
                            CheckAllPattern(username, email, password);
                            Register(username, email, password);
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private static void CheckAllPattern(string username, string email, string password)
        {
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                Console.WriteLine("Username must be alphanumeric");
            }
    
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.WriteLine("Invalid email");
            }
    
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                Console.WriteLine("Password must be between 8 and 15 characters, contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character");
            }
            
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
