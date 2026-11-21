namespace ComputerRepairAccounting.Entities;

public class Warehouse
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Capacity { get; private set; }

    public static Warehouse CreateEntity(int id, string name, int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Укажите название склада.");
        if (capacity <= 0)
            throw new ArgumentException("Вместимость склада должна быть положительной.");
        return new Warehouse { Id = id, Name = name.Trim(), Capacity = capacity };
    }
}
