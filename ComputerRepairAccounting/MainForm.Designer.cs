namespace ComputerRepairAccounting;

partial class MainForm
{
    private System.Windows.Forms.Label titleLabel = null!;

    private void InitializeComponent()
    {
        this.titleLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        this.titleLabel.AutoSize = true;
        this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        this.titleLabel.Location = new System.Drawing.Point(36, 36);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Size = new System.Drawing.Size(516, 32);
        this.titleLabel.TabIndex = 0;
        this.titleLabel.Text = "Учет ремонта компьютерной техники";
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(900, 560);
        this.Controls.Add(this.titleLabel);
        this.MinimumSize = new System.Drawing.Size(700, 450);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Учет ремонта компьютерной техники";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
