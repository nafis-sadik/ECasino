using LogicLayer.Implementation;
using LogicLayer.Repositories;
using Models.DataModels;
using Models.DataModels.Entities;
using System.Collections.Generic;
using static Models.ConstantLibrary;

namespace LogicLayer.Abstraction
{
    public interface ILobbyManagerService
    {
        // For 29 & Hajari
        ResponseModel<LobbyManager> RegisterPlayerToTeam(LobbyManager lobby, Player player, DuoTeams teamSelection);
        ResponseModel<LobbyManager> RemovePlayerFromTeam(LobbyManager lobby, Player player, DuoTeams teamSelection);
        ResponseModel<LobbyManager> CreateLobby(string lobbyId, Player host, int winningScore, GameTypes gameTypes);
        ResponseModel<LobbyManager> SetNewHands(LobbyManager lobby);

        // For Poker & Blackjack
        ResponseModel<LobbyManager> CreateLobby(string lobbyId, Player host, GameTypes gameTypes);
    }
}

