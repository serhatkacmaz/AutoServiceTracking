namespace Core.Entities;

public class ServiceEntry : Entity<int>
{
    public string LicensePlate { get; set; } // Required

    public string BrandName { get; set; } // Required

    public string ModelName { get; set; } // Required

    public int Kilometers { get; set; } // Required

    public int? ModelYear { get; set; } // Optional

    public DateTime ServiceDate { get; set; } // Required

    public bool? HasWarranty { get; set; } // Optional

    public string? ServiceCity { get; set; } // Optional

    public string? ServiceNotes { get; set; } // Optional
}
