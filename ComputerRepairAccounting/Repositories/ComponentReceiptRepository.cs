using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Repositories;

// ЛР1: заглушка без хранения данных. Реализация доступа к БД добавляется в ЛР2.
public class ComponentReceiptRepository : IComponentReceiptRepository
{
    public IReadOnlyList<ComponentReceipt> ReadAll() => [];
    public void Create(ComponentReceipt entity) => ArgumentNullException.ThrowIfNull(entity);
    public void Delete(int id) => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
}
