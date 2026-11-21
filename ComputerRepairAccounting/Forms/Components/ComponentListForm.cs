using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class ComponentListForm : Form
{
    public ComponentListForm() : this(new ComponentRepository()) { Name = GetType().Name; }

    private readonly IComponentRepository _repository;
    public ComponentListForm(IComponentRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        addButton.Click += (_, _) => RunAction(() => ShowEditor(new ComponentEditForm(_repository), RefreshRecords));
        editButton.Click += (_, _) => RunAction(() => ShowEditor(new ComponentEditForm(_repository, SelectedId), RefreshRecords));
        deleteButton.Click += (_, _) => RunAction(() => DeleteSelected(_repository.Delete, RefreshRecords));
        refreshButton.Click += (_, _) => RunAction(RefreshRecords);
        RefreshRecords();
    }
    private void RefreshRecords() => RecordsGrid.DataSource = _repository.ReadAll().Select(x => new { x.Id, Название = x.Name, Описание = x.Description }).ToList();

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
