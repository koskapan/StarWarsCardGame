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
        List<string> _users;
        List<Card> _cards;
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
            _users = new List<string>();
            _cards = new List<Card>();
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
        
        public UserConnectionResult AcceptUser(string userId)
        {
            if (_users.Count() <= 4)
            {
                if (!_users.Contains(userId))
                {
                    _users.Add(userId);
                    return new UserConnectionResult { Status = ConnectionStatuses.Success };
                }
                else
                {
                    return new UserConnectionResult { Status = ConnectionStatuses.UserExists };
                }
            }
            else
            {
                return new UserConnectionResult { Status = ConnectionStatuses.Full };
            }
        }

        public UserConnectionResult DisconnectUser(string userId)
        {
            if (_users.Remove(userId))
            {
                return new UserConnectionResult { Status = ConnectionStatuses.Success };
            }
            else
            {
                return new UserConnectionResult { Status = ConnectionStatuses.Fail };
            }
        }
    }
}