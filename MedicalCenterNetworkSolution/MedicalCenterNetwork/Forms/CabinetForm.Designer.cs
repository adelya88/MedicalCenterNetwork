namespace MedicalCenterNetwork.Forms
{
    partial class CabinetForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxCabinetInfo;
        private System.Windows.Forms.TextBox textBoxCabinetNumber;
        private System.Windows.Forms.Label labelCabinetNumber;
        private System.Windows.Forms.TextBox textBoxPurpose;
        private System.Windows.Forms.Label labelPurpose;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CabinetForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxCabinetInfo = new System.Windows.Forms.GroupBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.textBoxPurpose = new System.Windows.Forms.TextBox();
            this.labelPurpose = new System.Windows.Forms.Label();
            this.textBoxCabinetNumber = new System.Windows.Forms.TextBox();
            this.labelCabinetNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxCabinetInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 398);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.panel1.Size = new System.Drawing.Size(742, 110);
            this.panel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(491, 20);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 62);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(314, 20);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(168, 62);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBoxCabinetInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            this.panel2.Size = new System.Drawing.Size(742, 398);
            this.panel2.TabIndex = 1;
            // 
            // groupBoxCabinetInfo
            // 
            this.groupBoxCabinetInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCabinetInfo.Controls.Add(this.labelBranch);
            this.groupBoxCabinetInfo.Controls.Add(this.textBoxPurpose);
            this.groupBoxCabinetInfo.Controls.Add(this.labelPurpose);
            this.groupBoxCabinetInfo.Controls.Add(this.textBoxCabinetNumber);
            this.groupBoxCabinetInfo.Controls.Add(this.labelCabinetNumber);
            this.groupBoxCabinetInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxCabinetInfo.Location = new System.Drawing.Point(35, 37);
            this.groupBoxCabinetInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxCabinetInfo.Name = "groupBoxCabinetInfo";
            this.groupBoxCabinetInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxCabinetInfo.Size = new System.Drawing.Size(672, 320);
            this.groupBoxCabinetInfo.TabIndex = 0;
            this.groupBoxCabinetInfo.TabStop = false;
            this.groupBoxCabinetInfo.Text = "Информация о кабинете";
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBranch.Location = new System.Drawing.Point(30, 245);
            this.labelBranch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(95, 28);
            this.labelBranch.TabIndex = 4;
            this.labelBranch.Text = "Филиал:";
            // 
            // textBoxPurpose
            // 
            this.textBoxPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPurpose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPurpose.Location = new System.Drawing.Point(297, 140);
            this.textBoxPurpose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPurpose.Name = "textBoxPurpose";
            this.textBoxPurpose.Size = new System.Drawing.Size(350, 34);
            this.textBoxPurpose.TabIndex = 1;
            this.textBoxPurpose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // labelPurpose
            // 
            this.labelPurpose.AutoSize = true;
            this.labelPurpose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPurpose.Location = new System.Drawing.Point(30, 145);
            this.labelPurpose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPurpose.Name = "labelPurpose";
            this.labelPurpose.Size = new System.Drawing.Size(126, 28);
            this.labelPurpose.TabIndex = 2;
            this.labelPurpose.Text = "Назначение:";
            // 
            // textBoxCabinetNumber
            // 
            this.textBoxCabinetNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCabinetNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCabinetNumber.Location = new System.Drawing.Point(297, 90);
            this.textBoxCabinetNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCabinetNumber.Name = "textBoxCabinetNumber";
            this.textBoxCabinetNumber.Size = new System.Drawing.Size(350, 34);
            this.textBoxCabinetNumber.TabIndex = 0;
            this.textBoxCabinetNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // labelCabinetNumber
            // 
            this.labelCabinetNumber.AutoSize = true;
            this.labelCabinetNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCabinetNumber.Location = new System.Drawing.Point(30, 95);
            this.labelCabinetNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCabinetNumber.Name = "labelCabinetNumber";
            this.labelCabinetNumber.Size = new System.Drawing.Size(167, 28);
            this.labelCabinetNumber.TabIndex = 0;
            this.labelCabinetNumber.Text = "Номер кабинета:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CabinetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(742, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CabinetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Кабинет";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxCabinetInfo.ResumeLayout(false);
            this.groupBoxCabinetInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }
    }
}