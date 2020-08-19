using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Controller
{
    internal class LoginService : GameUser
    {
        /// <summary>
        /// Find user by username and check if password is equal to password in db
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<GameUser> GetUserByUserNameAndPassword(string username, string password)
        {
            await using var dbContext = new RpgGameContext();
            var user = await dbContext.GameUser.FirstOrDefaultAsync(c => c.Name.Equals(username));
            if (user.Password.Equals(password))
                return user;
            else
                return null;
        }


        /// <summary>
        /// Find user by username
        /// </summary>
        /// <param name="username">username from user input</param>
        /// <returns></returns>
        public static async Task<GameUser> GetUserByUsername(string username)
        {
            await using var dbContext = new RpgGameContext();
            var user = await dbContext.GameUser.FirstOrDefaultAsync(c => c.Name.Equals(username));

            return user;
        }


        /// <summary>
        /// Get all user in database
        /// </summary>
        /// <returns></returns>
        public static async Task<List<GameUser>> GameUserList()
        {
            await using var dbContext = new RpgGameContext();
            var result = await dbContext.GameUser.ToListAsync();
            return result;
        }
       
    }
}