using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class WarehouseEditForm : Form
{
    public WarehouseEditForm() : this(new WarehouseRepository()) { Name = GetType().Name; }

    public WarehouseEditForm(IWarehouseRepository repository, int? id = null)
    {
        InitializeComponent();
        capacity.Minimum = 1;
        if (id.HasValue) { var entity = repository.ReadById(id.Value); name.Text = entity.Name; capacity.Value = entity.Capacity; }
        OnSave(() => { var entity = Warehouse.CreateEntity(id ?? 0, name.Text, (int)capacity.Value);
            if (id.HasValue) repository.Update(entity); else repository.Create(entity); });
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
