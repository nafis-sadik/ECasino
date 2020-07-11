using LogicLayer.Implementation;
using Models;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Repositories
{
    class TwentyNineLobby: LobbyManager
    {
        /* Lobby must be destroyed when host is empty 
         * A host must be added when a lobby is created
         * If one host leaves, another existing player must be set as host
         * By default lobby maker will be set as host
         * By default lobby maker will be in Team A
         */
        public List<Player> TeamA { get; private set; }
        public List<Player> TeamB { get; private set; }
        public List<Player> BidWinner { get; private set; }
        public int WinningScore { get; private set; }
        public TwentyNineLobby(string LobbyId, Player lobbyMaker, int winningScore = 3) : base(LobbyId, lobbyMaker)
        {
            /* Game Policies
             * Winning score will be set by lobby maker only
             * LobbyMaker will be default host
             */
            WinningScore = winningScore;
            TeamA.Add(lobbyMaker);
        }
        public static void RemovePlayerFromTeam(TwentyNineLobby lobby, Player player)
        {
            /* In case of an existing player switching teams, the player needs to be removed from previous team before registering
             * the player to desired team */
            if (lobby.TeamA.Contains(player))
                lobby.TeamA.Remove(player);
            if (lobby.TeamB.Contains(player))
                lobby.TeamB.Remove(player);
        }
        public static bool RegisterPlayerToTeam(TwentyNineLobby lobby, Player player, ConstantLibrary.DuoTeams teamSelection)
        {
            /* In ConstantLibrary.DuoTeams TeamA is const true & TeamB is const false. SelectedTeam value will be placed by service user which will
             * determine wherather the player goes to team A or B */
            List<Player> team = teamSelection.SelectedTeam ? lobby.TeamA : lobby.TeamB;

            /* In case of an existing player switching teams, the player needs to be removed from previous team before registering
             * the player to desired team */
            if (lobby.TeamA.Contains(player))
                lobby.TeamA.Remove(player);
            if (lobby.TeamB.Contains(player))
                lobby.TeamB.Remove(player);

            // A most card games have 2 teams with only 2 player max in each
            if (team.Count < 2)
            {
                team.Add(player);
                return true;
            }
            else { return false; }
        }
        public static void LockBid(TwentyNineLobby lobby, ConstantLibrary.DuoTeams teamSelection, int biddingScore)
        {
            lobby.BidWinner = teamSelection.SelectedTeam ? lobby.TeamA : lobby.TeamB;
            lobby.BiddingScore = biddingScore;
        }
    }
}
