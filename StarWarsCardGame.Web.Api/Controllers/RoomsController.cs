using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace StarWarsCardGame.Web.Api.Controllers
{
    [RoutePrefix("api/v1/rooms")]
    [Authorize]
    public class RoomsController : ApiController
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
            string resultMessage = "";
            if (!controller.AcceptUser(User.Identity.Name))
            {
                resultMessage = "something wrong";
            }
            else
            {
                resultMessage = controller.Id;
            }
            return new GameRoomControllerViewModel { GameRoomControllerId = resultMessage };
        }
    }
}
