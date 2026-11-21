using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IDevicePlacementRepository
{
    IReadOnlyList<DevicePlacement> ReadAll();
    void Create(DevicePlacement placement);
    void Delete(int id);
}
