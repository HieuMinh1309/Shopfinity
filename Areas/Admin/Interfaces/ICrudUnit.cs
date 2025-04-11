using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Interfaces;

public interface ICrudUnit
{
    IEnumerable<Unit> getAllUnit();
    bool AddUnit(Unit unit);
    bool DeleteUnit(int unitId);
    bool UpdateUnit(Unit unit);
    Unit GetGroupByUnit(int unitId);
}
