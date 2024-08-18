namespace AutoServiceTracking.Shared.Dtos.ServiceEntry;

public record GetListServiceEntryDto
{
    public string LicensePlate { get; set; }

    public string BrandName { get; set; }

    public string ModelName { get; set; }

    public int Kilometers { get; set; }

    public int? ModelYear { get; set; }

    public DateTime ServiceDate { get; set; }

    public bool? HasWarranty { get; set; }

    public string? ServiceCity { get; set; }

    public string? ServiceNotes { get; set; }

    public GetListServiceEntryDto() { }

    public GetListServiceEntryDto(string licensePlate, string brandName, string modelName, int kilometers)
    {
        LicensePlate = licensePlate;
        BrandName = brandName;
        ModelName = modelName;
        Kilometers = kilometers;
    }
}
