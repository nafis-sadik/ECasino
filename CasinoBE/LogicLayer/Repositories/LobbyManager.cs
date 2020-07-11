using Models.Entities; 
using System.Collections.Generic;
using Models;
using System;
using Models.DataModels;

namespace LogicLayer.Repositories
{
    public abstract class LobbyManager
    {
        /* Lobby Class deals with technical stuff related with lobby which common for all kinds of lobbies
         * Any game feature even if it's common for all games we know should not be impletented here
         * Game specific lobby behaviour must be implemented in classes inheriting this class
         * For example we have a class "TwentyNineLobby" which implements 29 specific lobby behaviour which would be very different from lobby behaviour of
         * poker or blackjack or roulette
         * Purpose of this is to develop a lobby system that can reduce work for any kind of lobby manager development including non casino games
         */
        public string LobbyId { get; set; }
        public int BiddingScore { get; set; }
        public List<Card> Deck { get; set; }
        public Player Host { get; private set; }

        public LobbyManager(string lobbyId, Player player)
        {
            LobbyId = lobbyId;
            Host = player;
        }
    }
}
