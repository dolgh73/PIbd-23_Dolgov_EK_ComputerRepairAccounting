using ComputerRepairAccounting.Entities;

namespace ComputerRepairAccounting.Interfaces;

public interface IComponentReceiptRepository
{
    IReadOnlyList<ComponentReceipt> ReadAll();
    void Create(ComponentReceipt receipt);
    void Delete(int id);
}
