using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Models;
using Core.Entities;
using Core.Ioc.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository.Contexts;

namespace Repository.Repositories;

public class ServiceEntryRepository : GenericRepository<ServiceEntry, int>, IServiceEntryRepository
{
    public ServiceEntryRepository(AutoServiceTrackingContext context) : base(context) { }

    public async Task<List<ServiceEntriesProcedureModel>> GetServiceEntriesByProcedureAsync()
    {
        var result = new List<ServiceEntriesProcedureModel>();

        using (var command = context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "GetServiceEntries";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Open the connection if it's not already open
            if (command.Connection.State != System.Data.ConnectionState.Open)
            {
                await command.Connection.OpenAsync();
            }

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new ServiceEntriesProcedureModel
                    {
                        LicensePlate = reader["LicensePlate"]?.ToString() ?? "-",
                        BrandName = reader["BrandName"]?.ToString() ?? "-",
                        ModelName = reader["ModelName"]?.ToString() ?? "-",
                        Kilometers = reader["Kilometers"]?.ToString() ?? "-",
                        ModelYear = reader["ModelYear"]?.ToString() ?? "-",
                        ServiceDate = reader["ServiceDate"]?.ToString() ?? "-",
                        HasWarranty = reader["HasWarranty"]?.ToString() ?? "-",
                        ServiceCity = reader["ServiceCity"]?.ToString() ?? "-",
                        ServiceNotes = reader["ServiceNotes"]?.ToString() ?? "-"
                    });
                }
            }
        }

        return result;
    }
}