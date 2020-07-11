using LogicLayer.Abstraction;
using LogicLayer.Implementation;
using Models.DataModels;
using System;
using static Models.ConstantLibrary;

namespace CasinoBE_Testting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ILobbyManagerService lobbyManagerService = new LobbyManagerService();
            lobbyManagerService.CreateLobby("LobbyId", new Player { FirstName = "Nafis" }, 4, GameTypes.TwentyNine);
        }
    }
}
