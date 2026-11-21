namespace ComputerRepairAccounting.Forms;

partial class DevicePlacementListForm
{
    private DataGridView RecordsGrid = null!;
    private Button placeButton = null!;
    private Button releaseButton = null!;

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
        placeButton = new Button();
        placeButton.Name = "placeButton";
        placeButton.Text = "Разместить";
        placeButton.Location = new Point(16, 475);
        placeButton.Size = new Size(150, 32);
        Controls.Add(placeButton);
        releaseButton = new Button();
        releaseButton.Name = "releaseButton";
        releaseButton.Text = "Выдать со склада";
        releaseButton.Location = new Point(176, 475);
        releaseButton.Size = new Size(150, 32);
        Controls.Add(releaseButton);
        Text = "Размещение готовой техники";
        Name = "DevicePlacementListForm";
        ClientSize = new Size(1040, 535);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
