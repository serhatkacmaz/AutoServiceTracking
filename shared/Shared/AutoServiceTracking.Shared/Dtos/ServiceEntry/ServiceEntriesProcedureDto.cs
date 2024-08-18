namespace AutoServiceTracking.Shared.Dtos.ServiceEntry;

public record ServiceEntriesProcedureDto
{
    public string LicensePlate { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Kilometers { get; set; }
    public string ModelYear { get; set; }
    public string ServiceDate { get; set; }
    public string HasWarranty { get; set; }
    public string ServiceCity { get; set; }
    public string ServiceNotes { get; set; }
}
