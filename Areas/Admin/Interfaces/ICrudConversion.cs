using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Interfaces;

public interface ICrudConversion
{
    List<object> GetConversionsByProductId(int productId, int page, int pageSize, out int totalItems);
    IEnumerable<Conversion> getAllConversion();
    bool AddConversion(Conversion Conversion);
    bool DeleteConversion(int id);
    bool UpdateConversion(Conversion conversion);
    Conversion GetConversionById(int id);
}
