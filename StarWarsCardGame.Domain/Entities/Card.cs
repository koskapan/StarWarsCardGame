using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Entities
{
    public class Card
    {
        public string Id { get; set; }
        public string CardUrl { get; set; }
        public string CardName { get; set; }
        public string CardDescription { get; set; }
    }
}
