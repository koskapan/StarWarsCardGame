using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsCardGame.Domain.Entities
{
    public class User
    {
        private int _coinCount;

        public int CoinCount
        {
            get
            {
                return _coinCount;
            }
        }

        public string Login { get; set; }
        public bool IsReady { get; set; }

        public void GrantCoin()
        {
            _coinCount++;
        }

    }
}