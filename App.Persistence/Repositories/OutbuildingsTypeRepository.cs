using App.Application.Contracts.Persistence;
using App.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class OutbuildingsTypeRepository : BaseRepository<OutbuildingsType>, IOutbuildingsTypeRepository
    {
        public OutbuildingsTypeRepository()
        {

        }
    }
}
