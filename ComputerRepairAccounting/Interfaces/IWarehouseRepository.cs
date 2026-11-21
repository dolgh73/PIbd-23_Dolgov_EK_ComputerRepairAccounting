using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IWarehouseRepository
{
    IReadOnlyList<Warehouse> ReadAll();
    Warehouse ReadById(int id);
    void Create(Warehouse entity);
    void Update(Warehouse entity);
    void Delete(int id);
}
