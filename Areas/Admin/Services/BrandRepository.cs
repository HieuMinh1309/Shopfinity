using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Services;

public class BrandRepository : ICrudBrand
{
    private readonly SseContext _context;
    public BrandRepository(SseContext context)
    {
        _context = context;
    }
    public bool AddBrand(Brand brand)
    {
        try
        {
            _context.Brands.Add(brand);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error! {ex.Message}");
            return false;
        }
    }

    public bool DeleteBrand(int id)
    {
        try
        {
            var isDelete = _context.Brands.Find(id);
            if (isDelete != null)
            {
                _context.Brands.Remove(isDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error! {ex.Message}");
            return false;
        }
    }

    public IEnumerable<Brand> GetAllBrand()
    {
        try
        {
            return _context.Brands.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! {ex.Message}");
            return new List<Brand>();
        }
    }

    public Brand GetGroupById(int id)
    {
        try
        {
            return _context.Brands.FirstOrDefault(e => e.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! {ex.Message}");
            return null;
        }
    }

    public bool UpdateBrand(Brand brand)
    {
        try
        {
            if(brand == null)
            {
                Console.WriteLine("Brand is null");
                return false;
            }
            var updaBrand = _context.Brands.FirstOrDefault(e => e.Id == brand.Id);
            if (updaBrand == null)
            {
                Console.WriteLine("Unit not found in Database!");
                return false;
            }
            else
            {
                updaBrand.Name = brand.Name;
                return _context.SaveChanges() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error! {ex.Message}");
            return false;
        }
    }
}
