namespace Core.Entities.Base;

public abstract class Entity<TEntityId>
    where TEntityId : struct
{
    public TEntityId Id { get; set; }

    public Entity()
    {
        Id = default!;
    }

    public Entity(TEntityId id)
    {
        Id = id;
    }
}