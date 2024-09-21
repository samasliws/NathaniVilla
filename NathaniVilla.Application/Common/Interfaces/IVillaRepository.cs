﻿using NathaniVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NathaniVilla.Application.Common.Interfaces
{
    public interface IVillaRepository
    {
        IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null);
        IEnumerable<Villa> Get(Expression<Func<Villa, bool>> filter, string? includeProperties = null);
        void Add(Villa entity);
        void Update(Villa entity);
        void Delete(Villa entity);
        void Save();
    }
}