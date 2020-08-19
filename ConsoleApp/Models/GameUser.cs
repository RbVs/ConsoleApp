using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class GameUser
    {
        public GameUser()
        {
            Character = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}
