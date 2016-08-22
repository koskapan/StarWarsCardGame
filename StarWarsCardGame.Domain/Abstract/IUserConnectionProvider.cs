using StarWarsCardGame.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Abstract
{
    public interface IUserConnectionProvider
    {
        UserConnectionResult Connect(IGameRoomController controller, string userId);
    }
}
