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
        public string Name { get; }
        public IEnumerable<Card> Cards
        {
            get
            {
                return _cards;
            }
        }

        public IEnumerable<string> Users
        {
            get
            {
                return _users;
            }
        }

        public GameRoomController(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            _users = new List<string>();
            _cards = new List<Card>();
        }

        public UserConnectionResult AcceptUser(string userId)
        {
            if (!_users.Contains(userId))
            {
                _users.Add(userId);
                return new UserConnectionResult { Status = ConnectionStatuses.Success };
            }
            else
            {
                return new UserConnectionResult { Status = ConnectionStatuses.Error, Message = "User exists" };
            }
        }
        
    }
}