using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class ComponentReceiptEditForm : Form
{
    public ComponentReceiptEditForm() : this(new ComponentReceiptRepository(), new ComponentRepository()) { Name = GetType().Name; }

    public ComponentReceiptEditForm(IComponentReceiptRepository repository, IComponentRepository components)
    {
        InitializeComponent();
        items.BindComponents(components);
        OnSave(() => repository.Create(ComponentReceipt.CreateOperation(0, items.ReadItems())));
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
