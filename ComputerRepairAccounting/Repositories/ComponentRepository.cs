using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class ComponentRepository : IComponentRepository
{
    public IReadOnlyList<Component> ReadAll() => [];
    public Component ReadById(int id) => throw new InvalidOperationException("В ЛР1 репозиторий-заглушка не содержит записей.");
    public void Create(Component entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Update(Component entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Delete(int id) => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
}
