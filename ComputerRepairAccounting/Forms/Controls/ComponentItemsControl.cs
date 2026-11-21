using ComputerRepairAccounting.Repositories;
using ComputerRepairAccounting.Entities;
using ComputerRepairAccounting.Interfaces;

namespace ComputerRepairAccounting.Forms;

public class ComponentItemsControl : UserControl
{
    public ComponentItemsControl() : this(new ComponentRepository()) { Name = GetType().Name; }

    private readonly DataGridView _itemsGrid = new() { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
    public ComponentItemsControl(IComponentRepository repository)
    {
        Height = 200;
        Controls.Add(_itemsGrid);
        _itemsGrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Component", HeaderText = "Комплектующее",
            DataSource = repository.ReadAll().ToList(), DisplayMember = "Name", ValueMember = "Id" });
        _itemsGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество" });
        _itemsGrid.DataError += (_, e) => { e.ThrowException = false; MessageBox.Show("Выберите комплектующее из списка."); };
    }
    public IReadOnlyList<ComponentQuantity> ReadItems()
    {
        _itemsGrid.EndEdit();
        var items = new List<ComponentQuantity>();
        foreach (DataGridViewRow row in _itemsGrid.Rows)
        {
            if (row.IsNewRow) continue;
            if (row.Cells[0].Value is not int componentId || !int.TryParse(Convert.ToString(row.Cells[1].Value), out var quantity))
                throw new ArgumentException("Для каждой строки выберите комплектующее и целое количество.");
            items.Add(ComponentQuantity.CreateElement(componentId, quantity));
        }
        return items;
    }
    public void BindComponents(IComponentRepository repository)
    {
        ((DataGridViewComboBoxColumn)_itemsGrid.Columns[0]).DataSource = repository.ReadAll().ToList();
    }
}
