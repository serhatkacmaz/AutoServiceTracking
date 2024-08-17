namespace Core.Entities;

public interface IAudit
{
    public int? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
