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
        private List<string> _users;
        private List<Card> _cards;
        public string Id { get; }

        public IEnumerable<string> Users
        {
            get
            {
                return _users;
            }
        }

        public IEnumerable<Card> Cards
        {
            get
            {
                return _cards;
            }
        }

        public GameRoomController()
        {
            this.Id = Guid.NewGuid().ToString();
            _users = new List<string>();
            _cards = new List<Card>();
        }

        public bool AcceptUser(string userId)
        {
            if (!_users.Contains(userId))
            {
                _users.Add(userId);
                return true;
            }
            else return false;
        }
    }
}