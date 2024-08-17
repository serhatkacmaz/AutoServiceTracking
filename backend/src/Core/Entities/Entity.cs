namespace Core.Entities;

public class Entity<TEntityId> : IAudit where TEntityId : struct
{
    public TEntityId Id { get; set; }

    public int? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Entity()
    {
        Id = default!;
    }

    public Entity(TEntityId id)
    {
        Id = id;
    }
}