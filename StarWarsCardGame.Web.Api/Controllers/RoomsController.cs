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
            if (controller == null) return new GameRoomControllerViewModel { Status = ConnectionStatuses.NoRoom, StatusMessage = "No such room" };
            var connectionResult = controller.AcceptUser(User.Identity.Name);
            switch (connectionResult.Status)
            {
                case ConnectionStatuses.Success:
                    return new GameRoomControllerViewModel(connectionResult) { GameRoomControllerId = controller.Id, Users = controller.Users };
                default:
                    return new GameRoomControllerViewModel(connectionResult);
            }
        }

        [HttpGet]
        [Route("leave")]
        public GameRoomControllerViewModel LeaveRoom(string Id)
        {
            IGameRoomController controller = GameRoomControllerFactory.GetController(Id);
            if (controller == null) return new GameRoomControllerViewModel { Status = ConnectionStatuses.NoRoom, StatusMessage = "No such room" };
            var connectionResult = controller.DisconnectUser(User.Identity.Name);
            switch (connectionResult.Status)
            {
                case ConnectionStatuses.Success:
                    return new GameRoomControllerViewModel(connectionResult) { GameRoomControllerId = controller.Id, Users = controller.Users };
                default:
                    return new GameRoomControllerViewModel(connectionResult);
            }
        }
        

        [HttpGet]
        public IEnumerable<IGameRoomController> GetControllers()
        {
            return GameRoomControllerFactory.GetControllers();
        }
    }
}
