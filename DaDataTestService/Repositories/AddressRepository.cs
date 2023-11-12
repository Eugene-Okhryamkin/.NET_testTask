using DaDataTestService.Models;

namespace DaDataTestService.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly List<Address> _addresses = new List<Address>();
    private int _nextId = 1;

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await Task.FromResult(_addresses);
    }

    public async Task<Address> GetAddressByIdAsync(int id)
    {
        return await Task.FromResult(_addresses.FirstOrDefault(a => a.Id == id));
    }

    public async Task<Address> CreateAddressAsync(Address address)
    {
        address.Id = _nextId++;
        _addresses.Add(address);
        return await Task.FromResult(address);
    }

    public async Task<bool> UpdateAddressAsync(int id, Address address)
    {
        Address existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
        if (existingAddress == null)
            return await Task.FromResult(false);

        existingAddress.Value = address.Value;

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAddressAsync(int id)
    {
        Address existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
        if (existingAddress == null)
            return await Task.FromResult(false);

        _addresses.Remove(existingAddress);
        return await Task.FromResult(true);
    }
}