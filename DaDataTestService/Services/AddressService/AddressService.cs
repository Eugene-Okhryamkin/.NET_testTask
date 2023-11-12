using System.Collections;
using AutoMapper;
using DaData.Models.Suggestions.Responses;
using DaDataTestService.DTO;
using DaDataTestService.Models;
using DaDataTestService.Repositories;

namespace DaDataTestService.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IDaDataService _daDataService;
    private readonly IMapper _mapper;
    
    public AddressService(AddressRepository addressRepository, IDaDataService daDataService, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _daDataService = daDataService;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
    {
        IEnumerable<Address> addresses = await _addressRepository.GetAllAddressesAsync();
        return _mapper.Map<IEnumerable<AddressDto>>(addresses);
    }

    public async Task<AddressDto> GetAddressByIdAsync(int id)
    {
        Address address = await _addressRepository.GetAddressByIdAsync(id);
        return _mapper.Map<AddressDto>(address);
    }

    public async Task<AddressDto> CreateAddressAsync(AddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        AddressResponse standardizedAddress = await _daDataService.Standardize(addressDto.Value);
        addressDto.Value = standardizedAddress.Suggestions.FirstOrDefault().Value;
        
        Address createdAddress = await _addressRepository.CreateAddressAsync(address);
        return _mapper.Map<AddressDto>(createdAddress);
    }

    public async Task<bool> UpdateAddressAsync(int id, AddressDto addressDto)
    {
        Address existingAddress = await _addressRepository.GetAddressByIdAsync(id);
        if (existingAddress == null)
            return false;

        _mapper.Map(addressDto, existingAddress);

        return await _addressRepository.UpdateAddressAsync(id, existingAddress);
    }
    
    public async Task<bool> DeleteAddressAsync(int id)
    {
        return await _addressRepository.DeleteAddressAsync(id);
    }
}