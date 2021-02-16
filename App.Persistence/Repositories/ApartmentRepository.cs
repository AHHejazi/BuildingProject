
using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository<Project>, IApartmentRepository
    {
        public ApartmentRepository()
        {

        }
        
    }
}
