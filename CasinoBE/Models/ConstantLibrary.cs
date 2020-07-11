using Models.DataModels;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class ConstantLibrary
    {
        public struct DuoTeams
        {
            public const bool TeamA = true;
            public const bool TeamB = false;
            public bool SelectedTeam;
        }
        public static class ResponseConstant
        {
            public static string Success = "Operation Successfull";
            public static string Failed = "Operation Failed";
            public static string NotFound = "Id not found";
        }
        public enum CardTypes { Diamond = 0, Heart = 1, Clubs = 2, Spade = 3 }
        public enum CardNumbner
        {
            Two = 0,
            Three = 1,
            Four = 2,
            Five = 3, 
            Six = 4,
            Seven = 5,
            Eight = 6,
            Nine = 7,
            Ten = 8,
            Jack = 9,
            Queen = 10,
            King = 11,
            Ace = 12
        }
        public enum GameTypes
        {
            Poker = 0,
            Hajari = 1,
            Blackjack = 2,
            TwentyNine = 29
        }
    } 
}