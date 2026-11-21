using ComputerRepairAccounting.Entities.Enums;

namespace ComputerRepairAccounting.Entities;

public class Master
{
    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public MasterQualification Qualification { get; private set; }

    public static Master CreateEntity(int id, string fullName, MasterQualification qualification)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Укажите ФИО мастера.");
        if (qualification == MasterQualification.None || !Enum.IsDefined(qualification))
            throw new ArgumentException("Выберите квалификацию мастера.");
        return new Master { Id = id, FullName = fullName.Trim(), Qualification = qualification };
    }
}
