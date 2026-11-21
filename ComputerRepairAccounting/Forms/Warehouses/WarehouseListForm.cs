using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class WarehouseListForm : Form
{
    public WarehouseListForm() : this(new WarehouseRepository()) { Name = GetType().Name; }

    private readonly IWarehouseRepository _repository;
    public WarehouseListForm(IWarehouseRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        addButton.Click += (_, _) => RunAction(() => ShowEditor(new WarehouseEditForm(_repository), RefreshRecords));
        editButton.Click += (_, _) => RunAction(() => ShowEditor(new WarehouseEditForm(_repository, SelectedId), RefreshRecords));
        deleteButton.Click += (_, _) => RunAction(() => DeleteSelected(_repository.Delete, RefreshRecords));
        refreshButton.Click += (_, _) => RunAction(RefreshRecords);
        RefreshRecords();
    }
    private void RefreshRecords() => RecordsGrid.DataSource = _repository.ReadAll().Select(x => new { x.Id, Название = x.Name, Вместимость = x.Capacity }).ToList();

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
