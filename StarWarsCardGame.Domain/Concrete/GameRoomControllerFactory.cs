using StarWarsCardGame.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Domain.Concrete
{
    public class GameRoomControllerFactory : IGameRoomControllerFactory
    {
        List<IGameRoomController> gameControllers = new List<IGameRoomController>();

        public string CreateController()
        {
            GameRoomController newController = new GameRoomController();
            gameControllers.Add(newController);
            return newController.Id;
        }

        public void DeleteController(string ControllerId)
        {
            var gc = GetController(ControllerId);
            if (gc != null)
            {
                gameControllers.Remove(gc);
            }
        }

        public IGameRoomController GetController(string ControllerId)
        {
            return gameControllers.Find(c => c.Id == ControllerId);            
        }
    }
}