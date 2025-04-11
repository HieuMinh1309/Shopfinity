using Microsoft.AspNetCore.Mvc;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Conversion")]
public class ConversionController : Controller
{
    private readonly ICrudConversion _conversion;

    public ConversionController(ICrudConversion conversion)
    {
        _conversion = conversion;
    }

    [HttpGet("GetAllConversions")]
    public IActionResult GetAllConversions()
    {
        var conversions = _conversion.getAllConversion();
        return Ok(conversions);
    }

    [HttpGet("{id}")]
    public IActionResult GetConversionById(int id)
    {
        var conversion = _conversion.GetConversionById(id);
        if (conversion == null)
        {
            return NotFound(new { Message = "Conversion not found" });
        }
        return Ok(conversion);
    }

[HttpGet("GetConversionsByProduct/{productId}")]
public IActionResult GetConversionsByProduct(int productId, int page = 1, int pageSize = 2)
{
    int totalItems;
    var conversions = _conversion.GetConversionsByProductId(productId, page, pageSize, out totalItems);

    return Ok(new
    {
        Data = conversions,
        TotalItems = totalItems,
        Page = page,
        PageSize = pageSize
    });
}



    [HttpPost("AddConversion")]
    public IActionResult AddConversion([FromBody] Conversion conversion)
    {
        if (conversion == null)
        {
            return BadRequest(new { Message = "Invalid conversion data" });
        }
        bool isAdded = _conversion.AddConversion(conversion);
        if (!isAdded)
        {
            return StatusCode(500, new { Message = "Error adding conversion" });
        }
        return CreatedAtAction(nameof(GetConversionById), new { id = conversion.Id }, conversion);
    }

    [HttpPut("UpdateConversion/{id}")]
    public IActionResult UpdateConversion(int id, [FromBody] Conversion conversion)
    {
        if (conversion == null || id != conversion.Id)
        {
            return BadRequest(new { Message = "Invalid conversion data" });
        }
        bool isUpdated = _conversion.UpdateConversion(conversion);
        if (!isUpdated)
        {
            return StatusCode(500, new { Message = "Error updating conversion" });
        }
        return NoContent();
    }

    [HttpDelete("DeleteConversion/{id}")]
    public IActionResult DeleteConversion(int id)
    {
        bool isDeleted = _conversion.DeleteConversion(id);
        if (!isDeleted)
        {
            return NotFound(new { Message = "Conversion not found or deletion failed" });
        }
        return NoContent();
    }
}