using DaData.Models.Suggestions.Responses;

namespace DaDataTestService.Services;

public interface IDaDataService
{
    Task<AddressResponse> Standardize(string address);
}