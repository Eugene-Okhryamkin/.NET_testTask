using DaDataTestService.Services;
using Microsoft.AspNetCore.Mvc;
using DaDataTestService.DTO;

namespace DaDataTestService.Controllers;

public class AddressController : ControllerBase
{
    private readonly ILogger<AddressController> _logger;
    private readonly IAddressService _addressService;

    public AddressController(ILogger<AddressController> logger, IAddressService addressService)
    {
        _logger = logger;
        _addressService = addressService;
    }

    [HttpGet("/Api/[controller]/")]
    public async Task<IEnumerable<AddressDto>> GetAllAddresses()
    {
        try
        {
            IEnumerable<AddressDto> addresses = await _addressService.GetAllAddressesAsync();
            return addresses;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Адреса не найдены");
            throw;
        }
    }
    
    [HttpGet("/Api/[controller]/Addresses/")]
    public async Task<IActionResult> GetAddressById([FromQuery] int id)
    {
        try
        {
            AddressDto address = await _addressService.GetAddressByIdAsync(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Такого адреса не существует");
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost("/Api/[controller]/Addresses/Add")]
    public async Task<IActionResult> CreateAddress([FromBody] AddressDto addressDto)
    {
        try
        {
            AddressDto createdAddress = await _addressService.CreateAddressAsync(addressDto);
            return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Ошибка добавления адреса");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("/Api/[controller]/Addresses/")]
    public async Task<IActionResult> DeleteAddress([FromQuery] int id)
    {
        try
        {
            bool deleted = await _addressService.DeleteAddressAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Ошибка удаления адреса");
            return StatusCode(500, "Internal Server Error");
        }
    }

}