using System.Windows.Forms;

namespace MedicalCenterNetwork.Forms
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelEmployeeInfo;
        private Label labelOldPassword;
        private TextBox textBoxOldPassword;
        private Label labelNewPassword;
        private TextBox textBoxNewPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonSave;
        private Button buttonCancel;
        private Button buttonGenerate;
        private CheckBox checkBoxShowPassword;
        private ErrorProvider errorProvider;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBoxPassword;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.labelEmployeeInfo = new System.Windows.Forms.Label();
            this.groupBoxPassword = new System.Windows.Forms.GroupBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxPassword.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmployeeInfo
            // 
            this.labelEmployeeInfo.AutoSize = true;
            this.labelEmployeeInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmployeeInfo.Location = new System.Drawing.Point(30, 40);
            this.labelEmployeeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmployeeInfo.Name = "labelEmployeeInfo";
            this.labelEmployeeInfo.Size = new System.Drawing.Size(121, 28);
            this.labelEmployeeInfo.TabIndex = 0;
            this.labelEmployeeInfo.Text = "Сотрудник:";
            // 
            // groupBoxPassword
            // 
            this.groupBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPassword.Controls.Add(this.checkBoxShowPassword);
            this.groupBoxPassword.Controls.Add(this.buttonGenerate);
            this.groupBoxPassword.Controls.Add(this.textBoxConfirmPassword);
            this.groupBoxPassword.Controls.Add(this.labelConfirmPassword);
            this.groupBoxPassword.Controls.Add(this.textBoxNewPassword);
            this.groupBoxPassword.Controls.Add(this.labelNewPassword);
            this.groupBoxPassword.Controls.Add(this.textBoxOldPassword);
            this.groupBoxPassword.Controls.Add(this.labelOldPassword);
            this.groupBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPassword.Location = new System.Drawing.Point(35, 95);
            this.groupBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPassword.Name = "groupBoxPassword";
            this.groupBoxPassword.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPassword.Size = new System.Drawing.Size(672, 320);
            this.groupBoxPassword.TabIndex = 1;
            this.groupBoxPassword.TabStop = false;
            this.groupBoxPassword.Text = "Смена пароля";
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(241, 222);
            this.checkBoxShowPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(193, 32);
            this.checkBoxShowPassword.TabIndex = 5;
            this.checkBoxShowPassword.Text = "Показать пароль";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerate.FlatAppearance.BorderSize = 0;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGenerate.ForeColor = System.Drawing.Color.White;
            this.buttonGenerate.Location = new System.Drawing.Point(442, 215);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(205, 45);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "Сгенерировать";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(297, 165);
            this.textBoxConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(350, 34);
            this.textBoxConfirmPassword.TabIndex = 3;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConfirmPassword.Location = new System.Drawing.Point(30, 170);
            this.labelConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(164, 28);
            this.labelConfirmPassword.TabIndex = 6;
            this.labelConfirmPassword.Text = "Подтверждение:";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(297, 115);
            this.textBoxNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(350, 34);
            this.textBoxNewPassword.TabIndex = 2;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNewPassword.Location = new System.Drawing.Point(30, 120);
            this.labelNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(151, 28);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "Новый пароль:";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOldPassword.Location = new System.Drawing.Point(297, 65);
            this.textBoxOldPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(350, 34);
            this.textBoxOldPassword.TabIndex = 1;
            this.textBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOldPassword.Location = new System.Drawing.Point(30, 70);
            this.labelOldPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(156, 28);
            this.labelOldPassword.TabIndex = 0;
            this.labelOldPassword.Text = "Старый пароль:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.panel1.Size = new System.Drawing.Size(742, 110);
            this.panel1.TabIndex = 2;
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
            this.buttonCancel.Location = new System.Drawing.Point(557, 20);
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
            this.buttonSave.Location = new System.Drawing.Point(380, 20);
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
            this.panel2.Controls.Add(this.groupBoxPassword);
            this.panel2.Controls.Add(this.labelEmployeeInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            this.panel2.Size = new System.Drawing.Size(742, 475);
            this.panel2.TabIndex = 3;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(742, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Смена пароля";
            this.groupBoxPassword.ResumeLayout(false);
            this.groupBoxPassword.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }
    }
}