namespace ComputerRepairAccounting.Forms;

partial class ComponentEditForm
{
    private TextBox name = null!;
    private Label nameLabel = null!;
    private TextBox description = null!;
    private Label descriptionLabel = null!;
    private Button SaveButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        nameLabel = new Label();
        nameLabel.Text = "Название";
        nameLabel.Location = new Point(16, 24);
        nameLabel.Size = new Size(170, 24);
        Controls.Add(nameLabel);
        name = new TextBox();
        name.Name = "name";
        name.Location = new Point(190, 20);
        name.Size = new Size(420, 28);
        Controls.Add(name);
        descriptionLabel = new Label();
        descriptionLabel.Text = "Описание";
        descriptionLabel.Location = new Point(16, 66);
        descriptionLabel.Size = new Size(170, 24);
        Controls.Add(descriptionLabel);
        description = new TextBox();
        description.Name = "description";
        description.Location = new Point(190, 62);
        description.Size = new Size(420, 28);
        Controls.Add(description);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 104);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Комплектующее";
        Name = "ComponentEditForm";
        ClientSize = new Size(650, 164);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
