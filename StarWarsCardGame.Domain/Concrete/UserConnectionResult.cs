using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Concrete
{
    public class UserConnectionResult
    {
        public string Message { get; set; }
        public ConnectionStatuses Status { get; set; }
    }

    public enum ConnectionStatuses { Success, Error }
}
