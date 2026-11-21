using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IRepairRepository
{
    IReadOnlyList<Repair> ReadAll();
    void Create(Repair repair);
}
