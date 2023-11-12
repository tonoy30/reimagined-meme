using RecapApi.Attributes;

namespace RecapApi.Entities;

public class BaseEntity
{
    [GenerateOnAdd] public DateTime CreatedAt { get; set; }

    [GenerateOnAddOrUpdate] public DateTime ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }
}
