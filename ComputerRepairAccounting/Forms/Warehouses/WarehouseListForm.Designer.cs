namespace ComputerRepairAccounting.Forms;

partial class WarehouseListForm
{
    private DataGridView RecordsGrid = null!;
    private Button addButton = null!;
    private Button editButton = null!;
    private Button deleteButton = null!;
    private Button refreshButton = null!;

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
        editButton = new Button();
        editButton.Name = "editButton";
        editButton.Text = "Изменить";
        editButton.Location = new Point(176, 475);
        editButton.Size = new Size(150, 32);
        Controls.Add(editButton);
        deleteButton = new Button();
        deleteButton.Name = "deleteButton";
        deleteButton.Text = "Удалить";
        deleteButton.Location = new Point(336, 475);
        deleteButton.Size = new Size(150, 32);
        Controls.Add(deleteButton);
        refreshButton = new Button();
        refreshButton.Name = "refreshButton";
        refreshButton.Text = "Обновить";
        refreshButton.Location = new Point(496, 475);
        refreshButton.Size = new Size(150, 32);
        Controls.Add(refreshButton);
        Text = "Склады готовой техники";
        Name = "WarehouseListForm";
        ClientSize = new Size(1040, 535);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
