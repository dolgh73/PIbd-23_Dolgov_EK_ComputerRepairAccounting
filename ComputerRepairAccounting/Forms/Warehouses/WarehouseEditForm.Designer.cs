namespace ComputerRepairAccounting.Forms;

partial class WarehouseEditForm
{
    private TextBox name = null!;
    private Label nameLabel = null!;
    private NumericUpDown capacity = null!;
    private Label capacityLabel = null!;
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
        capacityLabel = new Label();
        capacityLabel.Text = "Количество мест";
        capacityLabel.Location = new Point(16, 66);
        capacityLabel.Size = new Size(170, 24);
        Controls.Add(capacityLabel);
        capacity = new NumericUpDown();
        capacity.Name = "capacity";
        capacity.Location = new Point(190, 62);
        capacity.Size = new Size(420, 28);
        capacity.Maximum = 100000000;
        Controls.Add(capacity);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 104);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Склад готовой техники";
        Name = "WarehouseEditForm";
        ClientSize = new Size(650, 164);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
