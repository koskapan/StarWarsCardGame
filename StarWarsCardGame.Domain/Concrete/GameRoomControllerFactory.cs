using StarWarsCardGame.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Domain.Concrete
{
    public static class GameRoomControllerFactory// : IGameRoomControllerFactory
    {
        static List<IGameRoomController> gameControllers = new List<IGameRoomController>();

        static public IGameRoomController CreateController()
        {
            GameRoomController newController = new GameRoomController();
            gameControllers.Add(newController);
            return newController;
        }

        public static void DeleteController(string ControllerId)
        {
            var gc = GetController(ControllerId);
            if (gc != null)
            {
                gameControllers.Remove(gc);
            }
        }

        public static IGameRoomController GetController(string ControllerId)
        {
            return gameControllers.Find(c => c.Id == ControllerId);            
        }
    }
}