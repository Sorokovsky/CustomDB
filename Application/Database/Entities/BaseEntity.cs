using Database.Attributes;

namespace Application.Database.Entities;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}