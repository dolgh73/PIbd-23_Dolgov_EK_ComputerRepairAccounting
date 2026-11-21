namespace ComputerRepairAccounting.Entities;

public class ComponentQuantity
{
    public int ComponentId { get; private set; }
    public int Quantity { get; private set; }

    public static ComponentQuantity CreateElement(int componentId, int quantity)
    {
        if (componentId <= 0 || quantity <= 0)
            throw new ArgumentException("Выберите комплектующее и положительное количество.");
        return new ComponentQuantity { ComponentId = componentId, Quantity = quantity };
    }
}
