using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class RepairRepository : IRepairRepository
{
    public IReadOnlyList<Repair> ReadAll() => [];
    public void Create(Repair entity) => ArgumentNullException.ThrowIfNull(entity);
}
