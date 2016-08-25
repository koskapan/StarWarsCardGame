using StarWarsCardGame.Domain.Concrete;
using StarWarsCardGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Abstract
{
    public interface IGameRoomController
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<Card> Cards { get;  }
        IEnumerable<string> Users { get; }
        UserConnectionResult AcceptUser(string userId);
        UserConnectionResult DisconnectUser(string userId);
    }
}
