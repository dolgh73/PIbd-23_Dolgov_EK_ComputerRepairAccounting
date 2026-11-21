using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class RepairListForm : Form
{
    public RepairListForm() : this(new RepairRepository(), new MasterRepository(), new ComponentRepository()) { Name = GetType().Name; }

    public RepairListForm(IRepairRepository repository, IMasterRepository masters, IComponentRepository components)
    {
        InitializeComponent();
        void RefreshRecords() => RecordsGrid.DataSource = repository.ReadAll().Select(x => new { x.Id, Дата = x.RepairDate,
            Устройство = x.DeviceName, Мастер = masters.ReadAll().FirstOrDefault(m => m.Id == x.MasterId)?.FullName ?? "Удалён", Виды = x.RepairType.ToString().Replace("Diagnostics", "Диагностика").Replace("Cleaning", "Чистка").Replace("ComponentReplacement", "Замена комплектующих").Replace("SoftwareSetup", "Настройка ПО"),
            Выручка = x.Revenue, Детали = string.Join("; ", x.Components.Select(i => $"{(components.ReadAll().FirstOrDefault(c => c.Id == i.ComponentId)?.Name ?? "Удалено")}: {i.Quantity}")) }).ToList();
        addButton.Click += (_, _) => RunAction(() => ShowEditor(new RepairEditForm(repository, masters, components), RefreshRecords));
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
