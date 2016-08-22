using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Web.Api.Models
{
    public class GameRoomControllerViewModel
    {
        public string GameRoomControllerId { get; set; }
        public string StatusMessage { get; set; }
        public GameRoomControllerStatuses Status { get; set; }
        public IEnumerable<string> Users { get; set; }
    }

    public enum GameRoomControllerStatuses { OK, ERR }
}