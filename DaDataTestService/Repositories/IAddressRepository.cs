using DaDataTestService.Models;

namespace DaDataTestService.Repositories;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAllAddressesAsync();
    Task<Address> GetAddressByIdAsync(int id);
    Task<Address> CreateAddressAsync(Address address);
    Task<bool> UpdateAddressAsync(int id, Address address);
    Task<bool> DeleteAddressAsync(int id);
}