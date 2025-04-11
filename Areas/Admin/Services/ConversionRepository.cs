using Microsoft.EntityFrameworkCore;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Services;

public class ConversionRepository : ICrudConversion
{
    private readonly SseContext _context;
    public ConversionRepository(SseContext context)
    {
        _context = context;
    }

    public bool AddConversion(Conversion Conversion)
    {
        try
        {
            _context.Conversions.Add(Conversion);

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while add Conversion: {ex.Message}");
            return false;
        }
    }

    public bool DeleteConversion(int id)
    {
        try
        {
            var conversion = _context.Conversions.FirstOrDefault(c => c.Id == id);
            if (conversion == null)
            {
                Console.WriteLine($"Conversion with ID {id} not found");
                return false;
            }

            _context.Conversions.Remove(conversion);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while delete Conversion: {ex.Message}");
            return false;
        }
    }


    public IEnumerable<Conversion> getAllConversion()
    {
        try
        {
            return _context.Conversions.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
            return Enumerable.Empty<Conversion>();
        }
    }

    public Conversion GetConversionById(int id)
    {
        try
        {
            return _context.Conversions.FirstOrDefault(c => c.Id == id);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching Conversion with ID: {id}, {ex.Message}");
            return null;
        }
    }

    public bool UpdateConversion(Conversion conversion)
    {
        try
        {
            if(conversion == null)
            {
                Console.WriteLine("Conversion is null");
                return false;
            }
            var updateCon = _context.Conversions.FirstOrDefault(c => c.Id == conversion.Id);
            if(updateCon == null)
            {
                Console.WriteLine("Conversion not found in database");
                return false;
            }
            else
            {
                updateCon.ConversionRate = conversion.ConversionRate;
                updateCon.FromUnit = conversion.FromUnit;
                updateCon.ToUnit = conversion.ToUnit;
                return _context.SaveChanges() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while update Conversion: {ex.Message}");
            return false;
        }
    }

    public List<object> GetConversionsByProductId(int productId, int page, int pageSize, out int totalItems)
    {
        var query = _context.Conversions
                            .Include(c => c.FromUnit)
                            .Include(c => c.ToUnit)
                            .Where(c => c.ProductId == productId);

        totalItems = query.Count(); 

        return query.OrderBy(c => c.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new
                    {
                        Id = c.Id,
                        FromUnitId = c.FromUnitId,
                        FromUnitName = c.FromUnit != null ? c.FromUnit.Name : "N/A",
                        ToUnitId = c.ToUnitId,
                        ToUnitName = c.ToUnit != null ? c.ToUnit.Name : "N/A",
                        ConversionRate = c.ConversionRate
                    })
                    .ToList<object>();
    }

}
