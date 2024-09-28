using Microsoft.EntityFrameworkCore;
using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Domain.Entities;
using NathaniVilla.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NathaniVilla.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        #region Generic Repo Constructor
        private readonly ApplicationDbContext _db;
        public AmenityRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        #endregion
        
        public void Update(Amenity entity)
        {
            _db.Amenities.Update(entity);
        }
    }
}
