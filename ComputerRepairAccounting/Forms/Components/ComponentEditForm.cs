using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class ComponentEditForm : Form
{
    public ComponentEditForm() : this(new ComponentRepository()) { Name = GetType().Name; }

    public ComponentEditForm(IComponentRepository repository, int? id = null)
    {
        InitializeComponent();
        if (id.HasValue) { var entity = repository.ReadById(id.Value); name.Text = entity.Name; description.Text = entity.Description; }
        OnSave(() => { var entity = Component.CreateEntity(id ?? 0, name.Text, description.Text);
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
