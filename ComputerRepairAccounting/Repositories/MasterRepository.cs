using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class MasterRepository : IMasterRepository
{
    public IReadOnlyList<Master> ReadAll() => [];
    public Master ReadById(int id) => throw new InvalidOperationException("В ЛР1 репозиторий-заглушка не содержит записей.");
    public void Create(Master entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Update(Master entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Delete(int id) => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
}
