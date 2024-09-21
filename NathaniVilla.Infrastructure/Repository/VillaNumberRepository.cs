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
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        #region : Generic Repo Constructor
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        #endregion
        
        public void Update(VillaNumber entity)
        {
            _db.VillaNumbers.Update(entity);
        }
    }
}
