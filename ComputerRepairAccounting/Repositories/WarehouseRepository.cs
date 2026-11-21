using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class WarehouseRepository : IWarehouseRepository
{
    public IReadOnlyList<Warehouse> ReadAll() => [];
    public Warehouse ReadById(int id) => throw new InvalidOperationException("В ЛР1 репозиторий-заглушка не содержит записей.");
    public void Create(Warehouse entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Update(Warehouse entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Delete(int id) => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
}
