using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceTracking.Shared.Models;

public class ServiceEntriesProcedureModel
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
