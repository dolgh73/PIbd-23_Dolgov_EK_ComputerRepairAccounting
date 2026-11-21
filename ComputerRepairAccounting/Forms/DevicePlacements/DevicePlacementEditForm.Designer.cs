namespace ComputerRepairAccounting.Forms;

partial class DevicePlacementEditForm
{
    private ComboBox repair = null!;
    private Label repairLabel = null!;
    private ComboBox warehouse = null!;
    private Label warehouseLabel = null!;
    private NumericUpDown place = null!;
    private Label placeLabel = null!;
    private Button SaveButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        repairLabel = new Label();
        repairLabel.Text = "Выполненный ремонт";
        repairLabel.Location = new Point(16, 24);
        repairLabel.Size = new Size(170, 24);
        Controls.Add(repairLabel);
        repair = new ComboBox();
        repair.Name = "repair";
        repair.Location = new Point(190, 20);
        repair.Size = new Size(420, 28);
        repair.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(repair);
        warehouseLabel = new Label();
        warehouseLabel.Text = "Склад";
        warehouseLabel.Location = new Point(16, 66);
        warehouseLabel.Size = new Size(170, 24);
        Controls.Add(warehouseLabel);
        warehouse = new ComboBox();
        warehouse.Name = "warehouse";
        warehouse.Location = new Point(190, 62);
        warehouse.Size = new Size(420, 28);
        warehouse.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(warehouse);
        placeLabel = new Label();
        placeLabel.Text = "Номер места";
        placeLabel.Location = new Point(16, 108);
        placeLabel.Size = new Size(170, 24);
        Controls.Add(placeLabel);
        place = new NumericUpDown();
        place.Name = "place";
        place.Location = new Point(190, 104);
        place.Size = new Size(420, 28);
        place.Maximum = 100000000;
        Controls.Add(place);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 146);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Размещение готовой техники";
        Name = "DevicePlacementEditForm";
        ClientSize = new Size(650, 206);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
