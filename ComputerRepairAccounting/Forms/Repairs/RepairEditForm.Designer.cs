namespace ComputerRepairAccounting.Forms;

partial class RepairEditForm
{
    private TextBox device = null!;
    private Label deviceLabel = null!;
    private ComboBox master = null!;
    private Label masterLabel = null!;
    private CheckedListBox repairTypes = null!;
    private Label repairTypesLabel = null!;
    private NumericUpDown revenue = null!;
    private Label revenueLabel = null!;
    private ComponentItemsControl items = null!;
    private Label itemsLabel = null!;
    private Button SaveButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        deviceLabel = new Label();
        deviceLabel.Text = "Устройство / серийный номер";
        deviceLabel.Location = new Point(16, 24);
        deviceLabel.Size = new Size(170, 24);
        Controls.Add(deviceLabel);
        device = new TextBox();
        device.Name = "device";
        device.Location = new Point(190, 20);
        device.Size = new Size(420, 28);
        Controls.Add(device);
        masterLabel = new Label();
        masterLabel.Text = "Мастер";
        masterLabel.Location = new Point(16, 66);
        masterLabel.Size = new Size(170, 24);
        Controls.Add(masterLabel);
        master = new ComboBox();
        master.Name = "master";
        master.Location = new Point(190, 62);
        master.Size = new Size(420, 28);
        master.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(master);
        repairTypesLabel = new Label();
        repairTypesLabel.Text = "Виды ремонта";
        repairTypesLabel.Location = new Point(16, 108);
        repairTypesLabel.Size = new Size(170, 24);
        Controls.Add(repairTypesLabel);
        repairTypes = new CheckedListBox();
        repairTypes.Name = "repairTypes";
        repairTypes.Location = new Point(190, 104);
        repairTypes.Size = new Size(420, 110);
        Controls.Add(repairTypes);
        revenueLabel = new Label();
        revenueLabel.Text = "Выручка, руб.";
        revenueLabel.Location = new Point(16, 232);
        revenueLabel.Size = new Size(170, 24);
        Controls.Add(revenueLabel);
        revenue = new NumericUpDown();
        revenue.Name = "revenue";
        revenue.Location = new Point(190, 228);
        revenue.Size = new Size(420, 28);
        revenue.Maximum = 100000000;
        Controls.Add(revenue);
        itemsLabel = new Label();
        itemsLabel.Text = "Израсходованные детали";
        itemsLabel.Location = new Point(16, 274);
        itemsLabel.Size = new Size(170, 24);
        Controls.Add(itemsLabel);
        items = new ComponentItemsControl();
        items.Name = "items";
        items.Location = new Point(190, 270);
        items.Size = new Size(420, 200);
        Controls.Add(items);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 484);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Выполненный ремонт";
        Name = "RepairEditForm";
        ClientSize = new Size(650, 544);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
