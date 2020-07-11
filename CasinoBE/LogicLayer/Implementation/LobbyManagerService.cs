using LogicLayer.Abstraction;
using LogicLayer.Repositories;
using Models;
using Models.DataModels;
using Models.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Models.ConstantLibrary;

namespace LogicLayer.Implementation
{
    public class LobbyManagerService : ILobbyManagerService
    {
        private const int cardCountOfSpecificType = 14;
        private ICrashLoggingService _crashLoggingService;
        private dynamic response;
        
        public LobbyManagerService ()
        {
            _crashLoggingService = new CrashLoggingService();
            response = new ResponseModel<LobbyManager>();
        }
        public ResponseModel<LobbyManager> CreateLobby(string LobbyId, Player player, int winningScore, GameTypes gameTypes)
        {
            try
            {
                LobbyManager _lobby;
                switch (gameTypes)
                {
                    case GameTypes.TwentyNine:
                        _lobby = new TwentyNineLobby(LobbyId, player, winningScore);
                        break;
                    default:
                        // Lobby for requested game type not created yet, potential major bug or security threat
                        response = new ResponseModel<LobbyManager>
                        {
                            IsValidResponse = false,
                            msg = "Invalid game type selected",
                            ObjResponse = null
                        };
                        _crashLoggingService.log(response.msg);
                        return response;
                }

                response = new ResponseModel<LobbyManager>
                {
                    IsValidResponse = true,
                    msg = null,
                    ObjResponse = _lobby
                };
            }
            catch (Exception ex)
            {
                response.IsValidResponse = false;
                response.msg = "Error: Excepton at LobbyManager_29 => CreateLobby => " + ex.InnerException.Message;
                _crashLoggingService.log(response.msg);
            }
            return response;
        }
        public ResponseModel<LobbyManager> SetNewHands(LobbyManager lobby)
        {
            throw new NotImplementedException();
        }
        public ResponseModel<LobbyManager> RegisterPlayerToTeam(LobbyManager lobby, Player player, DuoTeams teamSelection)
        {
            throw new NotImplementedException();
        }
        public ResponseModel<LobbyManager> RemovePlayerFromTeam(LobbyManager lobby, Player player, DuoTeams teamSelection)
        {
            throw new NotImplementedException();
        }
        public ResponseModel<LobbyManager> CreateLobby(string lobbyId, Player host, GameTypes gameTypes)
        {
            throw new NotImplementedException();
        }
    }
}
