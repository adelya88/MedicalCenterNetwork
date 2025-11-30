namespace MedicalCenterNetwork.Forms
{
    partial class AppointmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxAppointmentInfo;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.TextBox textBoxPatient;
        private System.Windows.Forms.Button buttonSearchPatient;
        private System.Windows.Forms.Label labelDoctor;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.Label labelServiceInfo;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label labelCabinet;
        private System.Windows.Forms.ComboBox comboBoxCabinet;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxActions;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentForm));
            this.groupBoxAppointmentInfo = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelCabinet = new System.Windows.Forms.Label();
            this.comboBoxCabinet = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelServiceInfo = new System.Windows.Forms.Label();
            this.labelService = new System.Windows.Forms.Label();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.labelDoctor = new System.Windows.Forms.Label();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.buttonSearchPatient = new System.Windows.Forms.Button();
            this.textBoxPatient = new System.Windows.Forms.TextBox();
            this.labelPatient = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxAppointmentInfo.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAppointmentInfo
            // 
            this.groupBoxAppointmentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAppointmentInfo.Controls.Add(this.labelStatus);
            this.groupBoxAppointmentInfo.Controls.Add(this.comboBoxStatus);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelCabinet);
            this.groupBoxAppointmentInfo.Controls.Add(this.comboBoxCabinet);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelTime);
            this.groupBoxAppointmentInfo.Controls.Add(this.dateTimePickerTime);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelDate);
            this.groupBoxAppointmentInfo.Controls.Add(this.dateTimePickerDate);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelServiceInfo);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelService);
            this.groupBoxAppointmentInfo.Controls.Add(this.comboBoxService);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelDoctor);
            this.groupBoxAppointmentInfo.Controls.Add(this.comboBoxDoctor);
            this.groupBoxAppointmentInfo.Controls.Add(this.buttonSearchPatient);
            this.groupBoxAppointmentInfo.Controls.Add(this.textBoxPatient);
            this.groupBoxAppointmentInfo.Controls.Add(this.labelPatient);
            this.groupBoxAppointmentInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxAppointmentInfo.Location = new System.Drawing.Point(19, 19);
            this.groupBoxAppointmentInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxAppointmentInfo.Name = "groupBoxAppointmentInfo";
            this.groupBoxAppointmentInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxAppointmentInfo.Size = new System.Drawing.Size(840, 548);
            this.groupBoxAppointmentInfo.TabIndex = 0;
            this.groupBoxAppointmentInfo.TabStop = false;
            this.groupBoxAppointmentInfo.Text = "Информация о записи";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(29, 469);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 28);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(180, 464);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(628, 36);
            this.comboBoxStatus.TabIndex = 7;
            // 
            // labelCabinet
            // 
            this.labelCabinet.AutoSize = true;
            this.labelCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCabinet.Location = new System.Drawing.Point(29, 406);
            this.labelCabinet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCabinet.Name = "labelCabinet";
            this.labelCabinet.Size = new System.Drawing.Size(92, 28);
            this.labelCabinet.TabIndex = 13;
            this.labelCabinet.Text = "Кабинет:";
            // 
            // comboBoxCabinet
            // 
            this.comboBoxCabinet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCabinet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCabinet.FormattingEnabled = true;
            this.comboBoxCabinet.Location = new System.Drawing.Point(180, 401);
            this.comboBoxCabinet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCabinet.Name = "comboBoxCabinet";
            this.comboBoxCabinet.Size = new System.Drawing.Size(628, 36);
            this.comboBoxCabinet.TabIndex = 6;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(420, 344);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(73, 28);
            this.labelTime.TabIndex = 11;
            this.labelTime.Text = "Время:";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.CustomFormat = "HH:mm";
            this.dateTimePickerTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(509, 339);
            this.dateTimePickerTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(148, 34);
            this.dateTimePickerTime.TabIndex = 5;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.Location = new System.Drawing.Point(29, 344);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(58, 28);
            this.labelDate.TabIndex = 9;
            this.labelDate.Text = "Дата:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDate.Location = new System.Drawing.Point(180, 339);
            this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(223, 34);
            this.dateTimePickerDate.TabIndex = 4;
            // 
            // labelServiceInfo
            // 
            this.labelServiceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelServiceInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServiceInfo.Location = new System.Drawing.Point(180, 281);
            this.labelServiceInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServiceInfo.Name = "labelServiceInfo";
            this.labelServiceInfo.Size = new System.Drawing.Size(629, 39);
            this.labelServiceInfo.TabIndex = 7;
            this.labelServiceInfo.Text = "Выберите услугу";
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelService.Location = new System.Drawing.Point(29, 235);
            this.labelService.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(75, 28);
            this.labelService.TabIndex = 6;
            this.labelService.Text = "Услуга:";
            // 
            // comboBoxService
            // 
            this.comboBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(180, 230);
            this.comboBoxService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(628, 36);
            this.comboBoxService.TabIndex = 3;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            // 
            // labelDoctor
            // 
            this.labelDoctor.AutoSize = true;
            this.labelDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDoctor.Location = new System.Drawing.Point(29, 156);
            this.labelDoctor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDoctor.Name = "labelDoctor";
            this.labelDoctor.Size = new System.Drawing.Size(60, 28);
            this.labelDoctor.TabIndex = 4;
            this.labelDoctor.Text = "Врач:";
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(180, 151);
            this.comboBoxDoctor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(628, 36);
            this.comboBoxDoctor.TabIndex = 2;
            // 
            // buttonSearchPatient
            // 
            this.buttonSearchPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchPatient.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSearchPatient.FlatAppearance.BorderSize = 0;
            this.buttonSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchPatient.ForeColor = System.Drawing.Color.White;
            this.buttonSearchPatient.Location = new System.Drawing.Point(660, 69);
            this.buttonSearchPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.Size = new System.Drawing.Size(149, 48);
            this.buttonSearchPatient.TabIndex = 1;
            this.buttonSearchPatient.Text = "Поиск";
            this.buttonSearchPatient.UseVisualStyleBackColor = false;
            this.buttonSearchPatient.Click += new System.EventHandler(this.buttonSearchPatient_Click);
            // 
            // textBoxPatient
            // 
            this.textBoxPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPatient.Location = new System.Drawing.Point(180, 76);
            this.textBoxPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPatient.Name = "textBoxPatient";
            this.textBoxPatient.ReadOnly = true;
            this.textBoxPatient.Size = new System.Drawing.Size(469, 34);
            this.textBoxPatient.TabIndex = 0;
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatient.Location = new System.Drawing.Point(29, 81);
            this.labelPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(94, 28);
            this.labelPatient.TabIndex = 0;
            this.labelPatient.Text = "Пациент:";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.buttonCancel);
            this.groupBoxActions.Controls.Add(this.buttonSave);
            this.groupBoxActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxActions.Location = new System.Drawing.Point(19, 575);
            this.groupBoxActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxActions.Size = new System.Drawing.Size(840, 125);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
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
            this.buttonCancel.Location = new System.Drawing.Point(681, 39);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(149, 62);
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
            this.buttonSave.Location = new System.Drawing.Point(509, 39);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(163, 62);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(876, 720);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxAppointmentInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(889, 750);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись на прием";
            this.groupBoxAppointmentInfo.ResumeLayout(false);
            this.groupBoxAppointmentInfo.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
        }
    }
}