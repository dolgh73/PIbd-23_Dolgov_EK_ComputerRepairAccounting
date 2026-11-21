namespace ComputerRepairAccounting.Entities.Enums;

[Flags]
public enum RepairType
{
    None = 0,
    Diagnostics = 1,
    Cleaning = 2,
    ComponentReplacement = 4,
    SoftwareSetup = 8
}
