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
        IQueryable<string> Users { get; set; }
        IQueryable<Card> Cards { get; set; }
    }
}
