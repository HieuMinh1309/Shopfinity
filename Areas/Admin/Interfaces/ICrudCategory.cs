
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Interfaces;

public interface ICrudCategory
{
    IEnumerable<ProductCategory> getAllCategories();
    bool AddCategory (ProductCategory category);
    bool DeleteCategory (int id);
    bool UpdateCategory (ProductCategory category);
    ProductCategory GetCategoryById(int id);

}
