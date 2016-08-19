using StarWarsCardGame.Domain.Abstract;
using StarWarsCardGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Domain.Concrete
{
    public class GameRoomController: IGameRoomController
    {
        public string Id { get; }

        public IQueryable<string> Users { get; set; }

        public IQueryable<Card> Cards { get; set; }

        public GameRoomController()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}