using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class DevicePlacementRepository : IDevicePlacementRepository
{
    public IReadOnlyList<DevicePlacement> ReadAll() => [];
    public void Create(DevicePlacement entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Delete(int id) => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
}
