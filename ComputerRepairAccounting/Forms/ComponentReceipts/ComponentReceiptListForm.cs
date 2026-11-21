using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class ComponentReceiptListForm : Form
{
    public ComponentReceiptListForm() : this(new ComponentReceiptRepository(), new ComponentRepository()) { Name = GetType().Name; }

    public ComponentReceiptListForm(IComponentReceiptRepository repository, IComponentRepository components)
    {
        InitializeComponent();
        void RefreshRecords() => RecordsGrid.DataSource = repository.ReadAll().Select(x => new { x.Id,
            Дата = x.ReceiptDate, Детали = string.Join("; ", x.Components.Select(i => $"{(components.ReadAll().FirstOrDefault(c => c.Id == i.ComponentId)?.Name ?? "Удалено")}: {i.Quantity}")) }).ToList();
        addButton.Click += (_, _) => RunAction(() => ShowEditor(new ComponentReceiptEditForm(repository, components), RefreshRecords));
        deleteButton.Click += (_, _) => RunAction(() => DeleteSelected(repository.Delete, RefreshRecords));
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
