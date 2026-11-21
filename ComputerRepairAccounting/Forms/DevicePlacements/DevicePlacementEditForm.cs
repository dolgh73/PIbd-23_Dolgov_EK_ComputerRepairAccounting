using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class DevicePlacementEditForm : Form
{
    public DevicePlacementEditForm() : this(new DevicePlacementRepository(), new RepairRepository(), new WarehouseRepository()) { Name = GetType().Name; }

    public DevicePlacementEditForm(IDevicePlacementRepository repository, IRepairRepository repairs, IWarehouseRepository warehouses)
    {
        InitializeComponent();
        repair.DisplayMember = "Name";
        repair.ValueMember = "Id";
        repair.DataSource = repairs.ReadAll().Select(x => new { x.Id, Name = $"{x.Id}: {x.DeviceName}" }).ToList();
        warehouse.DisplayMember = "Name";
        warehouse.ValueMember = "Id";
        warehouse.DataSource = warehouses.ReadAll().ToList();
        place.Minimum = 1;
        OnSave(() => repository.Create(DevicePlacement.CreateOperation(0, SelectedId(repair), SelectedId(warehouse), (int)place.Value)));
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
