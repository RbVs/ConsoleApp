using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public partial class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Lifepoint { get; set; }
        public int Manapoint { get; set; }
        public int Strength { get; set; }
        public int Charisma { get; set; }
        public int Willpower { get; set; }
        public int IdCharacterClass { get; set; }
        public int IdGameUser { get; set; }

        public virtual CharacterClass IdCharacterClassNavigation { get; set; }
        public virtual GameUser IdGameUserNavigation { get; set; }
    }
}
