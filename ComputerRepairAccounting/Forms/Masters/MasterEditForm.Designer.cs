namespace ComputerRepairAccounting.Forms;

partial class MasterEditForm
{
    private TextBox name = null!;
    private Label nameLabel = null!;
    private ComboBox qualification = null!;
    private Label qualificationLabel = null!;
    private Button SaveButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        nameLabel = new Label();
        nameLabel.Text = "ФИО";
        nameLabel.Location = new Point(16, 24);
        nameLabel.Size = new Size(170, 24);
        Controls.Add(nameLabel);
        name = new TextBox();
        name.Name = "name";
        name.Location = new Point(190, 20);
        name.Size = new Size(420, 28);
        Controls.Add(name);
        qualificationLabel = new Label();
        qualificationLabel.Text = "Квалификация";
        qualificationLabel.Location = new Point(16, 66);
        qualificationLabel.Size = new Size(170, 24);
        Controls.Add(qualificationLabel);
        qualification = new ComboBox();
        qualification.Name = "qualification";
        qualification.Location = new Point(190, 62);
        qualification.Size = new Size(420, 28);
        qualification.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(qualification);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 104);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Мастер";
        Name = "MasterEditForm";
        ClientSize = new Size(650, 164);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
