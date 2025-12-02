namespace MedicalCenterNetwork.Forms
{
    partial class AddProcedureForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxPatient;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.GroupBox groupBoxProcedure;
        private System.Windows.Forms.Label labelProcedure;
        private System.Windows.Forms.ComboBox comboBoxProcedure;
        private System.Windows.Forms.GroupBox groupBoxDateTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.ListBox listBoxRecords;
        private System.Windows.Forms.TextBox textBoxPrescriptions;
        private System.Windows.Forms.Label labelPrescriptions;
        private System.Windows.Forms.Label labelNurse;
        private System.Windows.Forms.Panel panelButtons;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProcedureForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelNurse = new System.Windows.Forms.Label();
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.textBoxPrescriptions = new System.Windows.Forms.TextBox();
            this.labelPrescriptions = new System.Windows.Forms.Label();
            this.listBoxRecords = new System.Windows.Forms.ListBox();
            this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.groupBoxProcedure = new System.Windows.Forms.GroupBox();
            this.labelProcedure = new System.Windows.Forms.Label();
            this.comboBoxProcedure = new System.Windows.Forms.ComboBox();
            this.groupBoxPatient = new System.Windows.Forms.GroupBox();
            this.labelPatient = new System.Windows.Forms.Label();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxRecords.SuspendLayout();
            this.groupBoxDateTime.SuspendLayout();
            this.groupBoxProcedure.SuspendLayout();
            this.groupBoxPatient.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(22, 22);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(258, 38);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Новая процедура";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelNurse);
            this.panelMain.Controls.Add(this.groupBoxRecords);
            this.panelMain.Controls.Add(this.groupBoxDateTime);
            this.panelMain.Controls.Add(this.groupBoxProcedure);
            this.panelMain.Controls.Add(this.groupBoxPatient);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(22, 22, 22, 0);
            this.panelMain.Size = new System.Drawing.Size(800, 570);
            this.panelMain.TabIndex = 1;
            // 
            // labelNurse
            // 
            this.labelNurse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNurse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelNurse.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelNurse.Location = new System.Drawing.Point(420, 22);
            this.labelNurse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNurse.Name = "labelNurse";
            this.labelNurse.Size = new System.Drawing.Size(354, 28);
            this.labelNurse.TabIndex = 4;
            this.labelNurse.Text = "Медсестра: ";
            this.labelNurse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecords.Controls.Add(this.textBoxPrescriptions);
            this.groupBoxRecords.Controls.Add(this.labelPrescriptions);
            this.groupBoxRecords.Controls.Add(this.listBoxRecords);
            this.groupBoxRecords.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxRecords.Location = new System.Drawing.Point(22, 350);
            this.groupBoxRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRecords.Size = new System.Drawing.Size(752, 200);
            this.groupBoxRecords.TabIndex = 3;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "Медицинские записи пациента (выберите для привязки)";
            this.groupBoxRecords.Visible = false;
            // 
            // textBoxPrescriptions
            // 
            this.textBoxPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPrescriptions.Location = new System.Drawing.Point(18, 140);
            this.textBoxPrescriptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPrescriptions.Multiline = true;
            this.textBoxPrescriptions.Name = "textBoxPrescriptions";
            this.textBoxPrescriptions.ReadOnly = true;
            this.textBoxPrescriptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrescriptions.Size = new System.Drawing.Size(714, 50);
            this.textBoxPrescriptions.TabIndex = 2;
            // 
            // labelPrescriptions
            // 
            this.labelPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrescriptions.AutoSize = true;
            this.labelPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelPrescriptions.Location = new System.Drawing.Point(14, 112);
            this.labelPrescriptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrescriptions.Name = "labelPrescriptions";
            this.labelPrescriptions.Size = new System.Drawing.Size(113, 25);
            this.labelPrescriptions.TabIndex = 1;
            this.labelPrescriptions.Text = "Назначения:";
            // 
            // listBoxRecords
            // 
            this.listBoxRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecords.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxRecords.FormattingEnabled = true;
            this.listBoxRecords.ItemHeight = 25;
            this.listBoxRecords.Location = new System.Drawing.Point(18, 40);
            this.listBoxRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxRecords.Name = "listBoxRecords";
            this.listBoxRecords.Size = new System.Drawing.Size(714, 54);
            this.listBoxRecords.TabIndex = 0;
            this.listBoxRecords.SelectedIndexChanged += new System.EventHandler(this.listBoxRecords_SelectedIndexChanged);
            // 
            // groupBoxDateTime
            // 
            this.groupBoxDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDateTime.Controls.Add(this.dateTimePickerTime);
            this.groupBoxDateTime.Controls.Add(this.dateTimePickerDate);
            this.groupBoxDateTime.Controls.Add(this.labelTime);
            this.groupBoxDateTime.Controls.Add(this.labelDate);
            this.groupBoxDateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDateTime.Location = new System.Drawing.Point(22, 240);
            this.groupBoxDateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDateTime.Name = "groupBoxDateTime";
            this.groupBoxDateTime.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDateTime.Size = new System.Drawing.Size(752, 100);
            this.groupBoxDateTime.TabIndex = 2;
            this.groupBoxDateTime.TabStop = false;
            this.groupBoxDateTime.Text = "Дата и время процедуры";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.CustomFormat = "HH:mm";
            this.dateTimePickerTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTime.Location = new System.Drawing.Point(520, 45);
            this.dateTimePickerTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(120, 34);
            this.dateTimePickerTime.TabIndex = 3;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerDate.Location = new System.Drawing.Point(120, 45);
            this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(220, 34);
            this.dateTimePickerDate.TabIndex = 2;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTime.Location = new System.Drawing.Point(420, 50);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(73, 28);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Время:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDate.Location = new System.Drawing.Point(18, 50);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(58, 28);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Дата:";
            // 
            // groupBoxProcedure
            // 
            this.groupBoxProcedure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProcedure.Controls.Add(this.labelProcedure);
            this.groupBoxProcedure.Controls.Add(this.comboBoxProcedure);
            this.groupBoxProcedure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxProcedure.Location = new System.Drawing.Point(22, 130);
            this.groupBoxProcedure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxProcedure.Name = "groupBoxProcedure";
            this.groupBoxProcedure.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxProcedure.Size = new System.Drawing.Size(752, 100);
            this.groupBoxProcedure.TabIndex = 1;
            this.groupBoxProcedure.TabStop = false;
            this.groupBoxProcedure.Text = "Информация о процедуре";
            // 
            // labelProcedure
            // 
            this.labelProcedure.AutoSize = true;
            this.labelProcedure.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelProcedure.Location = new System.Drawing.Point(18, 50);
            this.labelProcedure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProcedure.Name = "labelProcedure";
            this.labelProcedure.Size = new System.Drawing.Size(119, 28);
            this.labelProcedure.TabIndex = 1;
            this.labelProcedure.Text = "Процедура:";
            // 
            // comboBoxProcedure
            // 
            this.comboBoxProcedure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProcedure.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxProcedure.FormattingEnabled = true;
            this.comboBoxProcedure.Location = new System.Drawing.Point(150, 45);
            this.comboBoxProcedure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxProcedure.Name = "comboBoxProcedure";
            this.comboBoxProcedure.Size = new System.Drawing.Size(574, 36);
            this.comboBoxProcedure.TabIndex = 0;
            // 
            // groupBoxPatient
            // 
            this.groupBoxPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPatient.Controls.Add(this.labelPatient);
            this.groupBoxPatient.Controls.Add(this.comboBoxPatient);
            this.groupBoxPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPatient.Location = new System.Drawing.Point(22, 20);
            this.groupBoxPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPatient.Name = "groupBoxPatient";
            this.groupBoxPatient.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPatient.Size = new System.Drawing.Size(752, 100);
            this.groupBoxPatient.TabIndex = 0;
            this.groupBoxPatient.TabStop = false;
            this.groupBoxPatient.Text = "Пациент";
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPatient.Location = new System.Drawing.Point(18, 50);
            this.labelPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(94, 28);
            this.labelPatient.TabIndex = 1;
            this.labelPatient.Text = "Пациент:";
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(150, 45);
            this.comboBoxPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(574, 36);
            this.comboBoxPatient.TabIndex = 0;
            this.comboBoxPatient.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatient_SelectedIndexChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 650);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(22, 12, 22, 12);
            this.panelButtons.Size = new System.Drawing.Size(800, 90);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(628, 12);
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
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(468, 12);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 62);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddProcedureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(800, 740);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelButtons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AddProcedureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление процедуры";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxRecords.ResumeLayout(false);
            this.groupBoxRecords.PerformLayout();
            this.groupBoxDateTime.ResumeLayout(false);
            this.groupBoxDateTime.PerformLayout();
            this.groupBoxProcedure.ResumeLayout(false);
            this.groupBoxProcedure.PerformLayout();
            this.groupBoxPatient.ResumeLayout(false);
            this.groupBoxPatient.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }
    }
}