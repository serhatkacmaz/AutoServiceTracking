namespace AutoServiceTracking.Shared.Dtos.ServiceEntry;

public record GetAllServiceEntryDto
{
    public string LicensePlate { get; set; }

    public string BrandName { get; set; }

    public string ModelName { get; set; }

    public int Kilometers { get; set; }

    public GetAllServiceEntryDto(string licensePlate, string brandName, string modelName, int kilometers)
    {
        LicensePlate = licensePlate;
        BrandName = brandName;
        ModelName = modelName;
        Kilometers = kilometers;
    }
}
