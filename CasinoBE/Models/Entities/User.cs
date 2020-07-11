using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Models.Entities
{
    public abstract class User
    {
        // Messenger ID
        [Key]
        public ulong PlayerID { get; set; }
        public string ProfilePicLoc { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPlaying { get; set; }
        public int Coins { get; set; }
    }
}
