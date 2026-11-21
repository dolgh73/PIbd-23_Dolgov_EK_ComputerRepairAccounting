using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Entities.Enums;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public partial class MasterEditForm : Form
{
    public MasterEditForm() : this(new MasterRepository()) { Name = GetType().Name; }

    public MasterEditForm(IMasterRepository repository, int? id = null)
    {
        InitializeComponent();
        qualification.DisplayMember = "Text";
        qualification.ValueMember = "Value";
        qualification.DataSource =
            new[] { new { Value = MasterQualification.Technician, Text = "Техник" },
                new { Value = MasterQualification.SeniorTechnician, Text = "Старший техник" },
                new { Value = MasterQualification.Engineer, Text = "Инженер" } };
        if (id.HasValue) { var entity = repository.ReadById(id.Value); name.Text = entity.FullName; qualification.SelectedValue = entity.Qualification; }
        OnSave(() => { var entity = Master.CreateEntity(id ?? 0, name.Text, (MasterQualification)qualification.SelectedValue!);
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
