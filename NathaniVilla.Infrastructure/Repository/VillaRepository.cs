﻿using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NathaniVilla.Infrastructure.Repository
{
    public class VillaRepository : IVillaRepository
    {
        public void Add(Villa entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Villa entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Villa> Get(Expression<Func<Villa, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Villa entity)
        {
            throw new NotImplementedException();
        }
    }
}
