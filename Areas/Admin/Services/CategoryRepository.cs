using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Services;

public class CategoryRepository : ICrudCategory
{
    private readonly SseContext _context;
    public CategoryRepository(SseContext context)
    {
        _context = context;
    }
    public bool AddCategory(ProductCategory category)
    {
        try
        {
            _context.ProductCategories.Add(category);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while add category: {ex.Message}");
            return false;
        }
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            var deleCate = _context.ProductCategories.Find(id);
            if (deleCate != null)
            {
                _context.ProductCategories.Remove(deleCate);
                _context.SaveChanges(); 
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! while delete category: {ex.Message}");
            return false;
        }
    }


    public IEnumerable<ProductCategory> getAllCategories()
    {
        try
        {
            return _context.ProductCategories.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error !: {ex.Message}");
            return new List<ProductCategory>(); 
        }
    }


    public bool UpdateCategory(ProductCategory category)
    {
        try
        {
            if (category == null)
            {
                Console.WriteLine("Category is null!");
                return false;
            }
            var updateCate = _context.ProductCategories.FirstOrDefault(e => e.Id == category.Id);
            if (updateCate == null)
            {
                Console.WriteLine("Category not found in database!");
                return false;
            }
            else
            {
                updateCate.CateName = category.CateName;
                return _context.SaveChanges() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while update category: {ex.Message}");
            return false;
        }
    }

    public ProductCategory? GetCategoryById(int id)
    {
        try
        {
            return _context.ProductCategories.FirstOrDefault(c => c.Id == id);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching Category with ID: {id}, {ex.Message}");
            return null;
        }
    }
}
