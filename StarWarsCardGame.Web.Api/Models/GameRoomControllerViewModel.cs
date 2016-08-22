using StarWarsCardGame.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Web.Api.Models
{
    public class GameRoomControllerViewModel
    {
        public GameRoomControllerViewModel(UserConnectionResult connectionResult)
        {
            if (connectionResult != null)
            {
                StatusMessage = connectionResult.Message;
                Status = connectionResult.Status;
            }
        }

        public GameRoomControllerViewModel() : this(null) { }

        public string GameRoomControllerId { get; set; }
        public string StatusMessage { get; set; }
        public ConnectionStatuses Status { get; set; }
        public IEnumerable<string> Users { get; set; }
    }
}