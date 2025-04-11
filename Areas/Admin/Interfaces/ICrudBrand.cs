using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Interfaces;

public interface ICrudBrand
{
    IEnumerable<Brand> GetAllBrand();
    bool AddBrand(Brand brand);
    bool DeleteBrand(int id);
    bool UpdateBrand(Brand brand);
    Brand GetGroupById(int id);

}
