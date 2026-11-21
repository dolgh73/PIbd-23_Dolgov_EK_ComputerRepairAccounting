using ComputerRepairAccounting.Forms;
using Unity;

namespace ComputerRepairAccounting;

public partial class MainForm : Form
{
    private readonly IUnityContainer? _container;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(IUnityContainer container) : this()
    {
        _container = container;
    }

    private void MastersMenuItem_Click(object? sender, EventArgs e) => OpenForm<MasterListForm>();
    private void ComponentsMenuItem_Click(object? sender, EventArgs e) => OpenForm<ComponentListForm>();
    private void WarehousesMenuItem_Click(object? sender, EventArgs e) => OpenForm<WarehouseListForm>();
    private void ReceiptsMenuItem_Click(object? sender, EventArgs e) => OpenForm<ComponentReceiptListForm>();
    private void RepairsMenuItem_Click(object? sender, EventArgs e) => OpenForm<RepairListForm>();
    private void PlacementsMenuItem_Click(object? sender, EventArgs e) => OpenForm<DevicePlacementListForm>();

    private void OpenForm<T>() where T : Form
    {
        try
        {
            if (_container is null) throw new InvalidOperationException("Запустите приложение для открытия формы.");
            using var form = _container.Resolve<T>();
            form.ShowDialog(this);
        }
        catch (Exception error)
        {
            MessageBox.Show(this, error.GetBaseException().Message, "Ошибка открытия формы", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
