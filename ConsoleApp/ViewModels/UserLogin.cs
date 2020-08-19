using System;
using System.Threading.Tasks;
using ConsoleApp.Controller;
using ConsoleApp.Models;
using static ConsoleApp.Shared.CustomConsole;

namespace ConsoleApp.ViewModels
{
    internal static class UserLogin
    {
        private static string _username;
        private static string _password;

        /// <summary>
        ///     Check if user exists in database, if doesn´t, force user to register
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> Login()
        {
            //get user Details
            GetUserDetails();
            //check User is in DB 
            var isRegistered = await CheckUserIsRegistered();
            //if not, ask user to register
            if (!isRegistered)
                return await AskUserToRegister();
            return await LoginUserAsync(_username, _password);
        }

        private static async Task<bool> LoginUserAsync(string username, string password)
        {
            var user = await LoginService.GetUserByUserNameAndPassword(username, password);

            Program.CurrentUser = user;

            if (user != null)
            {
                Clear();
                WelcomeUser();

                return true;
            }

            return false;
        }

        private static async Task<bool> AskUserToRegister()
        {
            Write("Would you like to register? - yes / no");
            var result = Read();
            if (result.Equals("yes"))
            {
                Clear();
                GetUserDetails();

                var newUser = new GameUser
                {
                    Name = _username,
                    Password = _password
                };

                Program.CurrentUser = await RegisterService.Register(newUser);

                Clear();
                WelcomeUser();

                return true;
            }

            return false;
        }

        private static void WelcomeUser()
        {
            Write($"Hi {Program.CurrentUser.Name}!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Write(" Welcome to this awesome console game! I really hope you enjoy it!");
        }

        private static async Task<bool> CheckUserIsRegistered()
        {
            var user = await LoginService.GetUserByUsername(_username);
            return user != null;
        }

        private static void GetUserDetails()
        {
            Write("Please enter your credentials");
            Write("Username : ");
            _username = Read();
            Write("Password : ");
            _password = Read();
        }
    }
}