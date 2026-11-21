namespace ComputerRepairAccounting;

partial class MainForm
{
    private Label titleLabel = null!;
    private MenuStrip mainMenu = null!;
    private ToolStripMenuItem directoriesMenu = null!;
    private ToolStripMenuItem operationsMenu = null!;
    private ToolStripMenuItem reportsMenu = null!;
    private ToolStripMenuItem mastersMenuItem = null!;
    private ToolStripMenuItem componentsMenuItem = null!;
    private ToolStripMenuItem warehousesMenuItem = null!;
    private ToolStripMenuItem receiptsMenuItem = null!;
    private ToolStripMenuItem repairsMenuItem = null!;
    private ToolStripMenuItem placementsMenuItem = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        mainMenu = new MenuStrip();
        directoriesMenu = new ToolStripMenuItem();
        operationsMenu = new ToolStripMenuItem();
        reportsMenu = new ToolStripMenuItem();
        reportsMenu.Name = "reportsMenu";
        reportsMenu.Text = "Отчёты";
        mastersMenuItem = new ToolStripMenuItem();
        componentsMenuItem = new ToolStripMenuItem();
        warehousesMenuItem = new ToolStripMenuItem();
        receiptsMenuItem = new ToolStripMenuItem();
        repairsMenuItem = new ToolStripMenuItem();
        placementsMenuItem = new ToolStripMenuItem();
        titleLabel = new Label();
        directoriesMenu.Text = "Справочники";
        operationsMenu.Text = "Операции";
        mastersMenuItem.Text = "Мастера";
        componentsMenuItem.Text = "Комплектующие";
        warehousesMenuItem.Text = "Склады";
        receiptsMenuItem.Text = "Поступления";
        repairsMenuItem.Text = "Ремонты";
        placementsMenuItem.Text = "Размещение техники";
        mastersMenuItem.Click += MastersMenuItem_Click;
        componentsMenuItem.Click += ComponentsMenuItem_Click;
        warehousesMenuItem.Click += WarehousesMenuItem_Click;
        receiptsMenuItem.Click += ReceiptsMenuItem_Click;
        repairsMenuItem.Click += RepairsMenuItem_Click;
        placementsMenuItem.Click += PlacementsMenuItem_Click;
        directoriesMenu.DropDownItems.AddRange(new ToolStripItem[] { mastersMenuItem, componentsMenuItem, warehousesMenuItem });
        operationsMenu.DropDownItems.AddRange(new ToolStripItem[] { receiptsMenuItem, repairsMenuItem, placementsMenuItem });
        mainMenu.Items.AddRange(new ToolStripItem[] { directoriesMenu, operationsMenu, reportsMenu });
        mainMenu.Name = "mainMenu";
        mainMenu.Dock = DockStyle.Top;
        titleLabel.Text = "Учет ремонта компьютерной техники";
        titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        titleLabel.Location = new Point(30, 70);
        titleLabel.Size = new Size(700, 70);
        Controls.Add(titleLabel);
        Controls.Add(mainMenu);
        MainMenuStrip = mainMenu;
        ClientSize = new Size(760, 400);
        MinimumSize = new Size(776, 439);
        Name = "MainForm";
        Text = "Учет ремонта компьютерной техники";
        StartPosition = FormStartPosition.CenterScreen;
        ResumeLayout(false);
        PerformLayout();
    }
}
