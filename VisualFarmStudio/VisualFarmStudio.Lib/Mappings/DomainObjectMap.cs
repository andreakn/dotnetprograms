﻿using FluentNHibernate.Mapping;
using VisualFarmStudio.Core.Domain;

namespace VisualFarmStudio.Lib.Mappings
{
    public abstract class DomainObjectMap<TEntity> : ClassMap<TEntity> where TEntity : DomainObject
    {
        protected DomainObjectMap()
        {
            Table(typeof(TEntity).Name);
            Id(e => e.Id);
        }
    }
}