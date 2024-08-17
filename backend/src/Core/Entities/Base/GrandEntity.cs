namespace Core.Entities.Base;

public abstract class GrandEntity<TEntityId> : Entity<TEntityId>, IAudit
    where TEntityId : struct
{
    public int? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public GrandEntity()
    {
    }

    public GrandEntity(TEntityId id, int? createdBy, DateTime createdDate, int? updatedBy, DateTime? updatedDate) : base(id)
    {
        CreatedBy = createdBy;
        CreatedDate = createdDate;
        UpdatedBy = updatedBy;
        UpdatedDate = updatedDate;
    }
}
