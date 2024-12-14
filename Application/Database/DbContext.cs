using Application.Database.Entities;
using Database.Core;

namespace Application.Database;

public class DbContext : global::Database.Core.DbContext
{
    public Repository<BaseEntity> Entities { get; } = new(nameof(Entities));
}