using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Services;

public class UnitRepository : ICrudUnit
{
    private readonly SseContext _context;
    public UnitRepository(SseContext sseContext)
    {
        this._context = sseContext;
    }
    public bool AddUnit(Unit unit)
    {
        try
        {
            _context.Units.Add(unit);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! while add Unit: {ex.Message}");
            return false;
        }
    }

    public bool DeleteUnit(int unitId)
    {
        try
        {
            var deleteUnit = _context.Units.Find(unitId);
            if (deleteUnit != null)
            {
                _context.Units.Remove(deleteUnit);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! while delete Unit: {ex.Message}");
            return false;
        }
    }

    public IEnumerable<Unit> getAllUnit()
    {
        try
        {
            return _context.Units.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! while fetching units: {ex.Message}");
            return new List<Unit>();
        }
    }

    public Unit? GetGroupByUnit(int unitId)
    {
        try
        {
            return _context.Units.FirstOrDefault(e => e.Id == unitId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching unit with ID {unitId}: {ex.Message}");
            return null;
        }
    }


    public bool UpdateUnit(Unit unit)
    {
        try
        {
            if(unit == null)
            {
                Console.WriteLine("Unit is null!");
                return false;
            }
            var updateUnit = _context.Units.FirstOrDefault(e => e.Id == unit.Id);

            if (updateUnit != null)
            {
                updateUnit.Name = unit.Name;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Unit: {ex.Message}");
            return false;
        }
    }
}
