using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IMasterRepository
{
    IReadOnlyList<Master> ReadAll();
    Master ReadById(int id);
    void Create(Master entity);
    void Update(Master entity);
    void Delete(int id);
}
