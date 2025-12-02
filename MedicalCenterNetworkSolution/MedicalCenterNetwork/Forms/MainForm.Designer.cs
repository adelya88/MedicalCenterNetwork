namespace MedicalCenterNetwork.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cabinetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMedicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proceduresToolStripMenuItem;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cabinetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMedicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.patientsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.medicalRecordsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.proceduresToolStripMenuItem}); // ВАЖНО: добавлен proceduresToolStripMenuItem
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2084, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.systemToolStripMenuItem.Text = "Система";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.profileToolStripMenuItem.Text = "Мой профиль";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.changePasswordToolStripMenuItem.Text = "Сменить пароль";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.cabinetsToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(222, 32);
            this.administrationToolStripMenuItem.Text = "Администрирование";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(225, 36);
            this.employeesToolStripMenuItem.Text = "Сотрудники";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // cabinetsToolStripMenuItem
            // 
            this.cabinetsToolStripMenuItem.Name = "cabinetsToolStripMenuItem";
            this.cabinetsToolStripMenuItem.Size = new System.Drawing.Size(225, 36);
            this.cabinetsToolStripMenuItem.Text = "Кабинеты";
            this.cabinetsToolStripMenuItem.Click += new System.EventHandler(this.cabinetsToolStripMenuItem_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerPatientToolStripMenuItem,
            this.searchPatientToolStripMenuItem});
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(120, 32);
            this.patientsToolStripMenuItem.Text = "Пациенты";
            // 
            // registerPatientToolStripMenuItem
            // 
            this.registerPatientToolStripMenuItem.Name = "registerPatientToolStripMenuItem";
            this.registerPatientToolStripMenuItem.Size = new System.Drawing.Size(228, 36);
            this.registerPatientToolStripMenuItem.Text = "Регистрация";
            this.registerPatientToolStripMenuItem.Click += new System.EventHandler(this.registerPatientToolStripMenuItem_Click);
            // 
            // searchPatientToolStripMenuItem
            // 
            this.searchPatientToolStripMenuItem.Name = "searchPatientToolStripMenuItem";
            this.searchPatientToolStripMenuItem.Size = new System.Drawing.Size(228, 36);
            this.searchPatientToolStripMenuItem.Text = "Поиск";
            this.searchPatientToolStripMenuItem.Click += new System.EventHandler(this.searchPatientToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myScheduleToolStripMenuItem,
            this.createAppointmentToolStripMenuItem});
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(135, 32);
            this.scheduleToolStripMenuItem.Text = "Расписание";
            // 
            // myScheduleToolStripMenuItem
            // 
            this.myScheduleToolStripMenuItem.Name = "myScheduleToolStripMenuItem";
            this.myScheduleToolStripMenuItem.Size = new System.Drawing.Size(267, 36);
            this.myScheduleToolStripMenuItem.Text = "Мое расписание";
            this.myScheduleToolStripMenuItem.Click += new System.EventHandler(this.myScheduleToolStripMenuItem_Click);
            // 
            // createAppointmentToolStripMenuItem
            // 
            this.createAppointmentToolStripMenuItem.Name = "createAppointmentToolStripMenuItem";
            this.createAppointmentToolStripMenuItem.Size = new System.Drawing.Size(267, 36);
            this.createAppointmentToolStripMenuItem.Text = "Создать запись";
            this.createAppointmentToolStripMenuItem.Click += new System.EventHandler(this.createAppointmentToolStripMenuItem_Click);
            // 
            // medicalRecordsToolStripMenuItem
            // 
            this.medicalRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMedicalRecordsToolStripMenuItem,
            this.createRecordToolStripMenuItem});
            this.medicalRecordsToolStripMenuItem.Name = "medicalRecordsToolStripMenuItem";
            this.medicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(121, 32);
            this.medicalRecordsToolStripMenuItem.Text = "Медкарты";
            // 
            // viewMedicalRecordsToolStripMenuItem
            // 
            this.viewMedicalRecordsToolStripMenuItem.Name = "viewMedicalRecordsToolStripMenuItem";
            this.viewMedicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(253, 36);
            this.viewMedicalRecordsToolStripMenuItem.Text = "Просмотр";
            this.viewMedicalRecordsToolStripMenuItem.Click += new System.EventHandler(this.viewMedicalRecordsToolStripMenuItem_Click);
            // 
            // createRecordToolStripMenuItem
            // 
            this.createRecordToolStripMenuItem.Name = "createRecordToolStripMenuItem";
            this.createRecordToolStripMenuItem.Size = new System.Drawing.Size(253, 36);
            this.createRecordToolStripMenuItem.Text = "Создать запись";
            this.createRecordToolStripMenuItem.Click += new System.EventHandler(this.createRecordToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myStatisticsToolStripMenuItem,
            this.branchStatisticsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(94, 32);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            // 
            // myStatisticsToolStripMenuItem
            // 
            this.myStatisticsToolStripMenuItem.Name = "myStatisticsToolStripMenuItem";
            this.myStatisticsToolStripMenuItem.Size = new System.Drawing.Size(298, 36);
            this.myStatisticsToolStripMenuItem.Text = "Моя статистика";
            this.myStatisticsToolStripMenuItem.Click += new System.EventHandler(this.myStatisticsToolStripMenuItem_Click);
            // 
            // branchStatisticsToolStripMenuItem
            // 
            this.branchStatisticsToolStripMenuItem.Name = "branchStatisticsToolStripMenuItem";
            this.branchStatisticsToolStripMenuItem.Size = new System.Drawing.Size(298, 36);
            this.branchStatisticsToolStripMenuItem.Text = "Статистика филиала";
            this.branchStatisticsToolStripMenuItem.Click += new System.EventHandler(this.branchStatisticsToolStripMenuItem_Click);
            // 
            // proceduresToolStripMenuItem
            // 
            this.proceduresToolStripMenuItem.Name = "proceduresToolStripMenuItem";
            this.proceduresToolStripMenuItem.Size = new System.Drawing.Size(130, 32);
            this.proceduresToolStripMenuItem.Text = "Процедуры";
            this.proceduresToolStripMenuItem.Click += new System.EventHandler(this.proceduresToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2084, 1155);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Медицинская сеть - Главная";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}