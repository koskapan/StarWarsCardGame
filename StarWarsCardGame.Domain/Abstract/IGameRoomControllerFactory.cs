using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Abstract
{
    public interface IGameRoomControllerFactory
    {
        string CreateController();
        IGameRoomController GetController(string ControllerId);
        void DeleteController(string ControllerId);
    }
}
