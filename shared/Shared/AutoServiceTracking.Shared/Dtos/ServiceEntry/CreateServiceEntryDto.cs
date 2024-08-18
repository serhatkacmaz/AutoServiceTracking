namespace AutoServiceTracking.Shared.Dtos.ServiceEntry;

public class CreateServiceEntryDto
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

    public CreateServiceEntryDto()
    {

    }

    public CreateServiceEntryDto(string licensePlate, string brandName, string modelName, int kilometers, int? modelYear, DateTime serviceDate, bool? hasWarranty, string? serviceCity, string? serviceNotes)
    {
        LicensePlate = licensePlate;
        BrandName = brandName;
        ModelName = modelName;
        Kilometers = kilometers;
        ModelYear = modelYear;
        ServiceDate = serviceDate;
        HasWarranty = hasWarranty;
        ServiceCity = serviceCity;
        ServiceNotes = serviceNotes;
    }
}
