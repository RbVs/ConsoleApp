using System.Threading.Tasks;
using ConsoleApp.Models;

namespace ConsoleApp.Controller
{
    internal class RegisterService : GameUser
    {
        /// <summary>
        /// register new User
        /// </summary>
        /// <param name="newUser">new user entity</param>
        /// <returns></returns>
        public static async Task<GameUser> Register(GameUser newUser)
        {
            await using var dbContext = new RpgGameContext();
            await dbContext.GameUser.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }
    }
}