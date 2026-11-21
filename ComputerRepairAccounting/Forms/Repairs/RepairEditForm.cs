using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Entities.Enums;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class RepairEditForm : Form
{
    public RepairEditForm() : this(new RepairRepository(), new MasterRepository(), new ComponentRepository()) { Name = GetType().Name; }

    public RepairEditForm(IRepairRepository repository, IMasterRepository masters, IComponentRepository components)
    {
        InitializeComponent();
        master.DisplayMember = "FullName";
        master.ValueMember = "Id";
        master.DataSource = masters.ReadAll().ToList();
        repairTypes.CheckOnClick = true;
        repairTypes.Items.AddRange(new object[] { "Диагностика", "Чистка", "Замена комплектующих", "Настройка ПО" });
        revenue.DecimalPlaces = 2;
        items.BindComponents(components);
        OnSave(() =>
        {
            var flags = RepairType.None;
            foreach (int index in repairTypes.CheckedIndices) flags |= (RepairType)(1 << index);
            repository.Create(Repair.CreateOperation(0, SelectedId(master), device.Text, flags, revenue.Value, items.ReadItems()));
        });
    }

    private static int SelectedId(ComboBox choice) => choice.SelectedValue is int id ? id : throw new ArgumentException("Заполните справочники и выберите значение.");
    private void OnSave(Action save)
    {
        SaveButton.Click += (_, _) =>
        {
            try { save(); DialogResult = DialogResult.OK; Close(); }
            catch (Exception error) { MessageBox.Show(this, error.Message, "Ошибка"); }
        };
    }
}
