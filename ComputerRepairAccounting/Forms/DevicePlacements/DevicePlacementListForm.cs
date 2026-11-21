using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class DevicePlacementListForm : Form
{
    public DevicePlacementListForm() : this(new DevicePlacementRepository(), new RepairRepository(), new WarehouseRepository()) { Name = GetType().Name; }

    public DevicePlacementListForm(IDevicePlacementRepository repository, IRepairRepository repairs, IWarehouseRepository warehouses)
    {
        InitializeComponent();
        void RefreshRecords() => RecordsGrid.DataSource = repository.ReadAll().Select(x => new { x.Id, Дата = x.PlacementDate,
            Устройство = repairs.ReadAll().Single(r => r.Id == x.RepairId).DeviceName,
            Склад = warehouses.ReadAll().FirstOrDefault(w => w.Id == x.WarehouseId)?.Name ?? "Удалён", Место = x.PlaceNumber }).ToList();
        placeButton.Click += (_, _) => RunAction(() => ShowEditor(new DevicePlacementEditForm(repository, repairs, warehouses), RefreshRecords));
        releaseButton.Click += (_, _) => RunAction(() => DeleteSelected(repository.Delete, RefreshRecords));
        RefreshRecords();
    }

    private int SelectedId => RecordsGrid.CurrentRow?.Cells[0].Value is int id ? id : throw new InvalidOperationException("Выберите запись.");
    private void RunAction(Action action)
    {
        try { action(); }
        catch (Exception error) { MessageBox.Show(this, error.Message, "Ошибка"); }
    }
    private void ShowEditor(Form editor, Action refresh)
    {
        using (editor) if (editor.ShowDialog(this) == DialogResult.OK) refresh();
    }
    private void DeleteSelected(Action<int> delete, Action refresh)
    {
        var id = SelectedId;
        if (MessageBox.Show(this, "Удалить выбранную запись?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        delete(id);
        refresh();
    }
}
