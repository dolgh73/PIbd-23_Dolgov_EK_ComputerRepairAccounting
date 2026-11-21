namespace ComputerRepairAccounting.Forms;

partial class ComponentReceiptEditForm
{
    private ComponentItemsControl items = null!;
    private Label itemsLabel = null!;
    private Button SaveButton = null!;

    private void InitializeComponent()
    {
        SuspendLayout();
        itemsLabel = new Label();
        itemsLabel.Text = "Комплектующие";
        itemsLabel.Location = new Point(16, 24);
        itemsLabel.Size = new Size(170, 24);
        Controls.Add(itemsLabel);
        items = new ComponentItemsControl();
        items.Name = "items";
        items.Location = new Point(190, 20);
        items.Size = new Size(420, 200);
        Controls.Add(items);
        SaveButton = new Button();
        SaveButton.Name = "SaveButton";
        SaveButton.Text = "Сохранить";
        SaveButton.Location = new Point(16, 234);
        SaveButton.Size = new Size(150, 32);
        Controls.Add(SaveButton);
        Text = "Поступление комплектующих";
        Name = "ComponentReceiptEditForm";
        ClientSize = new Size(650, 294);
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
    }
}
