namespace ComputerRepairAccounting.Entities;

public class DevicePlacement
{
    public int Id { get; private set; }
    public int RepairId { get; private set; }
    public int WarehouseId { get; private set; }
    public int PlaceNumber { get; private set; }
    public DateTime PlacementDate { get; private set; }

    public static DevicePlacement CreateOperation(int id, int repairId, int warehouseId, int placeNumber)
    {
        if (repairId <= 0 || warehouseId <= 0 || placeNumber <= 0)
            throw new ArgumentException("Выберите ремонт, склад и номер места.");
        return new DevicePlacement { Id = id, RepairId = repairId, WarehouseId = warehouseId,
            PlaceNumber = placeNumber, PlacementDate = DateTime.Now };
    }
}
