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
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        #region : Generic Repo Constructor
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        #endregion
        
        public void Update(Villa entity)
        {
            _db.Villas.Update(entity);
        }
    }
}
