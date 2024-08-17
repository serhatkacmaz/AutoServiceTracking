namespace AutoServiceTracking.Shared.Dtos.ServiceEntry;

public record CreatedServiceEntryDto
{
    public string LicensePlate { get; set; }

    public string BrandName { get; set; }

    public string ModelName { get; set; }

    public DateTime ServiceDate { get; set; }

    public CreatedServiceEntryDto(string licensePlate, string brandName, string modelName, DateTime serviceDate)
    {
        LicensePlate = licensePlate;
        BrandName = brandName;
        ModelName = modelName;
        ServiceDate = serviceDate;
    }
}
