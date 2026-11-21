namespace ComputerRepairAccounting.Entities;

public class ComponentReceipt
{
    public int Id { get; private set; }
    public DateTime ReceiptDate { get; private set; }
    public IReadOnlyList<ComponentQuantity> Components { get; private set; } = [];

    public static ComponentReceipt CreateOperation(int id, IEnumerable<ComponentQuantity> components)
    {
        ArgumentNullException.ThrowIfNull(components);
        var items = components.ToList();
        if (items.Any(item => item is null))
            throw new ArgumentException("Строки комплектующих не должны быть null.", nameof(components));
        if (items.Count == 0 || items.Select(x => x.ComponentId).Distinct().Count() != items.Count)
            throw new ArgumentException("Добавьте комплектующие без повторяющихся строк.");
        return new ComponentReceipt { Id = id, ReceiptDate = DateTime.Now, Components = items.AsReadOnly() };
    }
}
