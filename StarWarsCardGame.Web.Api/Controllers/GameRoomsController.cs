using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarWarsCardGame.Web.Api.Controllers
{
    [RoutePrefix("api/v1/rooms")]
    public class GameRoomsController : ApiController
    {
        // GET: api/GameRooms
        [HttpGet]
        [Route("create")]
        public GameRoomControllerViewModel CreateRoom()
        {
            var newController = GameRoomControllerFactory.CreateController();
            return new GameRoomControllerViewModel { GameRoomControllerId = newController.Id };
        }

        [HttpGet]
        [Route("join/{Id}")]
        public GameRoomControllerViewModel JoinRoom(string Id)
        {
            IGameRoomController controller = GameRoomControllerFactory.GetController(Id);
            return new GameRoomControllerViewModel { GameRoomControllerId = controller == null ? "Noroom" : controller.Id };
        }
    }
}
