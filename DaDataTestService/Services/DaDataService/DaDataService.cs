using DaData.Interfaces;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;

namespace DaDataTestService.Services;
public class DaDataService : IDaDataService
{
    private readonly IDaDataApiClient _dataApiClient;

    public DaDataService(IDaDataApiClient dataApiClient)
    {
        _dataApiClient = dataApiClient;
    }
    
    public async Task<AddressResponse> Standardize(string address)
    {
        try
        {
            AddressRequest request = new AddressRequest { Query = address };
            AddressResponse response = await _dataApiClient.SuggestionsQueryAddress(request);

            return response;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}