namespace ComputerRepairAccounting.Forms;

partial class RepairListForm
{
    private DataGridView RecordsGrid = null!;
    private Button addButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        RecordsGrid = new DataGridView();
        RecordsGrid.Name = "RecordsGrid";
        RecordsGrid.Location = new Point(16, 20);
        RecordsGrid.Size = new Size(1000, 440);
        RecordsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        RecordsGrid.ReadOnly = true;
        RecordsGrid.AllowUserToAddRows = false;
        RecordsGrid.MultiSelect = false;
        RecordsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        RecordsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        Controls.Add(RecordsGrid);
        addButton = new Button();
        addButton.Name = "addButton";
        addButton.Text = "Добавить";
        addButton.Location = new Point(16, 475);
        addButton.Size = new Size(150, 32);
        Controls.Add(addButton);
        Text = "Выполненные ремонты";
        Name = "RepairListForm";
        ClientSize = new Size(1040, 535);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
