using ComputerRepairAccounting.Entities.Enums;

namespace ComputerRepairAccounting.Entities;

public class Repair
{
    public int Id { get; private set; }
    public int MasterId { get; private set; }
    public string DeviceName { get; private set; } = string.Empty;
    public RepairType RepairType { get; private set; }
    public decimal Revenue { get; private set; }
    public DateTime RepairDate { get; private set; }
    public IReadOnlyList<ComponentQuantity> Components { get; private set; } = [];

    public static Repair CreateOperation(int id, int masterId, string deviceName, RepairType repairType,
        decimal revenue, IEnumerable<ComponentQuantity> components)
    {
        if (masterId <= 0 || string.IsNullOrWhiteSpace(deviceName))
            throw new ArgumentException("Выберите мастера и укажите устройство.");
        const RepairType all = RepairType.Diagnostics | RepairType.Cleaning |
            RepairType.ComponentReplacement | RepairType.SoftwareSetup;
        if (repairType == RepairType.None || (repairType & ~all) != 0 || revenue < 0)
            throw new ArgumentException("Выберите виды ремонта и неотрицательную выручку.");
        ArgumentNullException.ThrowIfNull(components);
        var items = components.ToList();
        if (items.Any(item => item is null))
            throw new ArgumentException("Строки комплектующих не должны быть null.", nameof(components));
        if (items.Select(x => x.ComponentId).Distinct().Count() != items.Count)
            throw new ArgumentException("Комплектующие не должны повторяться.");
        return new Repair { Id = id, MasterId = masterId, DeviceName = deviceName.Trim(),
            RepairType = repairType, Revenue = revenue, RepairDate = DateTime.Now, Components = items.AsReadOnly() };
    }
}
