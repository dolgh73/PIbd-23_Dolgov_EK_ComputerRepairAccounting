using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class MasterListForm : Form
{
    public MasterListForm() : this(new MasterRepository()) { Name = GetType().Name; }

    private readonly IMasterRepository _repository;
    public MasterListForm(IMasterRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        addButton.Click += (_, _) => RunAction(() => ShowEditor(new MasterEditForm(_repository), RefreshRecords));
        editButton.Click += (_, _) => RunAction(() => ShowEditor(new MasterEditForm(_repository, SelectedId), RefreshRecords));
        deleteButton.Click += (_, _) => RunAction(() => DeleteSelected(_repository.Delete, RefreshRecords));
        refreshButton.Click += (_, _) => RunAction(RefreshRecords);
        RefreshRecords();
    }
    private void RefreshRecords() => RecordsGrid.DataSource = _repository.ReadAll().Select(x => new { x.Id, ФИО = x.FullName, Квалификация = x.Qualification switch { Entities.Enums.MasterQualification.Technician => "Техник", Entities.Enums.MasterQualification.SeniorTechnician => "Старший техник", _ => "Инженер" } }).ToList();

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
