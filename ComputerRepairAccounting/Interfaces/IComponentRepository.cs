using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IComponentRepository
{
    IReadOnlyList<Component> ReadAll();
    Component ReadById(int id);
    void Create(Component entity);
    void Update(Component entity);
    void Delete(int id);
}
