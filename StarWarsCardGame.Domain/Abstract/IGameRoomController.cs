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
        IEnumerable<string> Users { get;  }
        IEnumerable<Card> Cards { get;  }

        bool AcceptUser(string userId);
    }
}
