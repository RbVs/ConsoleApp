using System;
using System.Threading.Tasks;
using ConsoleApp.Models;
using ConsoleApp.ViewModels;

namespace ConsoleApp
{
    internal class Program
    {
        private static bool _isRunning = true;
        private static bool _isLoggedIn;
        public static GameUser CurrentUser { get; set; }

        private static async Task Main()
        {
            while (!_isLoggedIn) _isLoggedIn = await UserLogin.Login();
            while (_isRunning) _isRunning = Navigationmenu();
        }

        private static bool Navigationmenu()
        {
            switch (Console.ReadLine())
            {
            }


            //switch (Console.ReadLine())
            //{
            //    case nameof(UserInput.info):
            //        foreach (var item in Enum.GetNames(typeof(UserInput)))
            //        {
            //            Console.WriteLine(item);
            //        }
            //        return true;
            //    case nameof(UserInput.help):
            //        foreach (var item in Menu.MenuList)
            //            Console.WriteLine(item.MenuName);
            //        return true;
            //    case nameof(UserInput.add):
            //        Console.WriteLine("New Item will be added");
            //        return true;
            //    case nameof(UserInput.show):
            //        foreach (var item in Inventory.InventoryList)
            //        {
            //            var output = $"{item.Name} - {item.Description}";
            //            Console.WriteLine(output);
            //        }
            //        return true;
            //    case nameof(UserInput.clear):
            //        Console.Clear();
            //        return true;
            //    case nameof(UserInput.exit):
            //        Console.WriteLine("Closing Application");
            //        return false;
            //    default:
            //        Console.WriteLine("command not found, try 'info' for possible commands");
            //        return true;
            //}

            return true;
        }
    }


    internal enum UserInput
    {
        info,
        help,
        add,
        show,
        clear,
        exit
    }
}