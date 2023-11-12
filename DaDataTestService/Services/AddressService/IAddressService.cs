using DaDataTestService.DTO;
using DaDataTestService.Models;

namespace DaDataTestService.Services;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
    Task<AddressDto> GetAddressByIdAsync(int id);
    Task<AddressDto> CreateAddressAsync(AddressDto addressDto);
    Task<bool> UpdateAddressAsync(int id, AddressDto addressDto);
    Task<bool> DeleteAddressAsync(int id);
}