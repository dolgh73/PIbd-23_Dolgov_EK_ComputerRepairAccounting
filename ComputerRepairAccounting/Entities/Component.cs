namespace ComputerRepairAccounting.Entities;

public class Component
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public static Component CreateEntity(int id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Укажите название комплектующего.");
        return new Component { Id = id, Name = name.Trim(), Description = (description ?? string.Empty).Trim() };
    }
}
