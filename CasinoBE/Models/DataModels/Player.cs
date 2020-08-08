using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DataModels
{
    public class Player : User
    {
        public bool IsOnline { get; set; }
        public bool IsReady { get; set; }
        public List<Card> Cards { get; set; }
    }
}
