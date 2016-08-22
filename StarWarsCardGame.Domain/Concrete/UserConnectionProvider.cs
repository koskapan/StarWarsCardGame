using StarWarsCardGame.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Concrete
{
    public class UserConnectionProvider : IUserConnectionProvider
    {
        public UserConnectionResult Connect( IGameRoomController controller, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
