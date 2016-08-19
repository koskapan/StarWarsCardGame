using StarWarsCardGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCardGame.Domain.Abstract
{
    public interface ICardRepository
    {
        IQueryable<Card> Get();
        Card Get(string id);
    }
}
