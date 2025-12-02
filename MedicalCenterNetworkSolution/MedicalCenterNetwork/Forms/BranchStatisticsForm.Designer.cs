using System.Windows.Forms;

namespace MedicalCenterNetwork.Forms
{
    partial class BranchStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BranchStatisticsForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelBranchName = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxFinancial = new System.Windows.Forms.GroupBox();
            this.lblRevenuePerDoctor = new System.Windows.Forms.Label();
            this.lblAvgPerDoctor = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCompletedProcedures = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblAvgAppointmentCost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxAppointments = new System.Windows.Forms.GroupBox();
            this.lblNoShowRate = new System.Windows.Forms.Label();
            this.lblCompletionRate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBarNoShow = new System.Windows.Forms.ProgressBar();
            this.progressBarCompletion = new System.Windows.Forms.ProgressBar();
            this.lblNoShowAppointments = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCanceledAppointments = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPlannedAppointments = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCompletedAppointments = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAppointments = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPersonnel = new System.Windows.Forms.GroupBox();
            this.lblTotalNurses = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblNewPatients = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalPatients = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblActiveDoctors = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalDoctors = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageDoctors = new System.Windows.Forms.TabPage();
            this.dataGridViewTopDoctors = new System.Windows.Forms.DataGridView();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.dataGridViewTopServices = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxFinancial.SuspendLayout();
            this.groupBoxAppointments.SuspendLayout();
            this.groupBoxPersonnel.SuspendLayout();
            this.tabPageDoctors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopDoctors)).BeginInit();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopServices)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.labelBranchName);
            this.panelHeader.Controls.Add(this.btnGenerate);
            this.panelHeader.Controls.Add(this.dateTimePickerTo);
            this.panelHeader.Controls.Add(this.labelTo);
            this.panelHeader.Controls.Add(this.dateTimePickerFrom);
            this.panelHeader.Controls.Add(this.labelFrom);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1648, 134);
            this.panelHeader.TabIndex = 0;
            // 
            // labelBranchName
            // 
            this.labelBranchName.AutoSize = true;
            this.labelBranchName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBranchName.Location = new System.Drawing.Point(35, 41);
            this.labelBranchName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelBranchName.Name = "labelBranchName";
            this.labelBranchName.Size = new System.Drawing.Size(242, 32);
            this.labelBranchName.TabIndex = 6;
            this.labelBranchName.Text = "Филиал: Загрузка...";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1172, 31);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(340, 50);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Сформировать отчет";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(908, 41);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(237, 30);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(857, 46);
            this.labelTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(40, 25);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "по:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(600, 41);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(237, 30);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(557, 46);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(31, 25);
            this.labelFrom.TabIndex = 0;
            this.labelFrom.Text = "С:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageDoctors);
            this.tabControl.Controls.Add(this.tabPageServices);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 134);
            this.tabControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1648, 1038);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBoxFinancial);
            this.tabPageGeneral.Controls.Add(this.groupBoxAppointments);
            this.tabPageGeneral.Controls.Add(this.groupBoxPersonnel);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 34);
            this.tabPageGeneral.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageGeneral.Size = new System.Drawing.Size(1640, 1000);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "Общая статистика";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxFinancial
            // 
            this.groupBoxFinancial.Controls.Add(this.lblRevenuePerDoctor);
            this.groupBoxFinancial.Controls.Add(this.lblAvgPerDoctor);
            this.groupBoxFinancial.Controls.Add(this.label19);
            this.groupBoxFinancial.Controls.Add(this.label20);
            this.groupBoxFinancial.Controls.Add(this.lblCompletedProcedures);
            this.groupBoxFinancial.Controls.Add(this.label17);
            this.groupBoxFinancial.Controls.Add(this.lblAvgAppointmentCost);
            this.groupBoxFinancial.Controls.Add(this.label15);
            this.groupBoxFinancial.Controls.Add(this.lblTotalRevenue);
            this.groupBoxFinancial.Controls.Add(this.label13);
            this.groupBoxFinancial.Location = new System.Drawing.Point(35, 584);
            this.groupBoxFinancial.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxFinancial.Name = "groupBoxFinancial";
            this.groupBoxFinancial.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxFinancial.Size = new System.Drawing.Size(1573, 200);
            this.groupBoxFinancial.TabIndex = 2;
            this.groupBoxFinancial.TabStop = false;
            this.groupBoxFinancial.Text = "Финансовая статистика";
            // 
            // lblRevenuePerDoctor
            // 
            this.lblRevenuePerDoctor.AutoSize = true;
            this.lblRevenuePerDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenuePerDoctor.ForeColor = System.Drawing.Color.Blue;
            this.lblRevenuePerDoctor.Location = new System.Drawing.Point(1200, 141);
            this.lblRevenuePerDoctor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRevenuePerDoctor.Name = "lblRevenuePerDoctor";
            this.lblRevenuePerDoctor.Size = new System.Drawing.Size(22, 25);
            this.lblRevenuePerDoctor.TabIndex = 9;
            this.lblRevenuePerDoctor.Text = "0";
            // 
            // lblAvgPerDoctor
            // 
            this.lblAvgPerDoctor.AutoSize = true;
            this.lblAvgPerDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvgPerDoctor.ForeColor = System.Drawing.Color.Blue;
            this.lblAvgPerDoctor.Location = new System.Drawing.Point(1200, 91);
            this.lblAvgPerDoctor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAvgPerDoctor.Name = "lblAvgPerDoctor";
            this.lblAvgPerDoctor.Size = new System.Drawing.Size(22, 25);
            this.lblAvgPerDoctor.TabIndex = 8;
            this.lblAvgPerDoctor.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(857, 141);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(291, 25);
            this.label19.TabIndex = 7;
            this.label19.Text = "Средняя выручка на врача (₽):";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(857, 91);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(268, 25);
            this.label20.TabIndex = 6;
            this.label20.Text = "Среднее приемов на врача:";
            // 
            // lblCompletedProcedures
            // 
            this.lblCompletedProcedures.AutoSize = true;
            this.lblCompletedProcedures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompletedProcedures.ForeColor = System.Drawing.Color.Blue;
            this.lblCompletedProcedures.Location = new System.Drawing.Point(1200, 41);
            this.lblCompletedProcedures.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompletedProcedures.Name = "lblCompletedProcedures";
            this.lblCompletedProcedures.Size = new System.Drawing.Size(22, 25);
            this.lblCompletedProcedures.TabIndex = 5;
            this.lblCompletedProcedures.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(857, 41);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 25);
            this.label17.TabIndex = 4;
            this.label17.Text = "Выполнено процедур:";
            // 
            // lblAvgAppointmentCost
            // 
            this.lblAvgAppointmentCost.AutoSize = true;
            this.lblAvgAppointmentCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvgAppointmentCost.ForeColor = System.Drawing.Color.Blue;
            this.lblAvgAppointmentCost.Location = new System.Drawing.Point(343, 141);
            this.lblAvgAppointmentCost.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAvgAppointmentCost.Name = "lblAvgAppointmentCost";
            this.lblAvgAppointmentCost.Size = new System.Drawing.Size(22, 25);
            this.lblAvgAppointmentCost.TabIndex = 3;
            this.lblAvgAppointmentCost.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(35, 141);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(283, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "Средняя стоимость приема:";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalRevenue.Location = new System.Drawing.Point(343, 91);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(22, 25);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 91);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Общая выручка:";
            // 
            // groupBoxAppointments
            // 
            this.groupBoxAppointments.Controls.Add(this.lblNoShowRate);
            this.groupBoxAppointments.Controls.Add(this.lblCompletionRate);
            this.groupBoxAppointments.Controls.Add(this.label12);
            this.groupBoxAppointments.Controls.Add(this.label11);
            this.groupBoxAppointments.Controls.Add(this.progressBarNoShow);
            this.groupBoxAppointments.Controls.Add(this.progressBarCompletion);
            this.groupBoxAppointments.Controls.Add(this.lblNoShowAppointments);
            this.groupBoxAppointments.Controls.Add(this.label10);
            this.groupBoxAppointments.Controls.Add(this.lblCanceledAppointments);
            this.groupBoxAppointments.Controls.Add(this.label8);
            this.groupBoxAppointments.Controls.Add(this.lblPlannedAppointments);
            this.groupBoxAppointments.Controls.Add(this.label6);
            this.groupBoxAppointments.Controls.Add(this.lblCompletedAppointments);
            this.groupBoxAppointments.Controls.Add(this.label4);
            this.groupBoxAppointments.Controls.Add(this.lblTotalAppointments);
            this.groupBoxAppointments.Controls.Add(this.label2);
            this.groupBoxAppointments.Location = new System.Drawing.Point(35, 300);
            this.groupBoxAppointments.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxAppointments.Name = "groupBoxAppointments";
            this.groupBoxAppointments.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxAppointments.Size = new System.Drawing.Size(1573, 250);
            this.groupBoxAppointments.TabIndex = 1;
            this.groupBoxAppointments.TabStop = false;
            this.groupBoxAppointments.Text = "Статистика приемов";
            // 
            // lblNoShowRate
            // 
            this.lblNoShowRate.AutoSize = true;
            this.lblNoShowRate.Location = new System.Drawing.Point(1457, 184);
            this.lblNoShowRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNoShowRate.Name = "lblNoShowRate";
            this.lblNoShowRate.Size = new System.Drawing.Size(41, 25);
            this.lblNoShowRate.TabIndex = 15;
            this.lblNoShowRate.Text = "0%";
            // 
            // lblCompletionRate
            // 
            this.lblCompletionRate.AutoSize = true;
            this.lblCompletionRate.Location = new System.Drawing.Point(1457, 134);
            this.lblCompletionRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompletionRate.Name = "lblCompletionRate";
            this.lblCompletionRate.Size = new System.Drawing.Size(41, 25);
            this.lblCompletionRate.TabIndex = 14;
            this.lblCompletionRate.Text = "0%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1115, 184);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "Доля неявок:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1115, 134);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(287, 25);
            this.label11.TabIndex = 12;
            this.label11.Text = "Доля завершенных приемов:";
            // 
            // progressBarNoShow
            // 
            this.progressBarNoShow.Location = new System.Drawing.Point(857, 184);
            this.progressBarNoShow.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.progressBarNoShow.Name = "progressBarNoShow";
            this.progressBarNoShow.Size = new System.Drawing.Size(240, 34);
            this.progressBarNoShow.TabIndex = 11;
            // 
            // progressBarCompletion
            // 
            this.progressBarCompletion.Location = new System.Drawing.Point(857, 134);
            this.progressBarCompletion.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.progressBarCompletion.Name = "progressBarCompletion";
            this.progressBarCompletion.Size = new System.Drawing.Size(240, 34);
            this.progressBarCompletion.TabIndex = 10;
            // 
            // lblNoShowAppointments
            // 
            this.lblNoShowAppointments.AutoSize = true;
            this.lblNoShowAppointments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoShowAppointments.ForeColor = System.Drawing.Color.Blue;
            this.lblNoShowAppointments.Location = new System.Drawing.Point(600, 184);
            this.lblNoShowAppointments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNoShowAppointments.Name = "lblNoShowAppointments";
            this.lblNoShowAppointments.Size = new System.Drawing.Size(22, 25);
            this.lblNoShowAppointments.TabIndex = 9;
            this.lblNoShowAppointments.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 184);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Пациент не яв.:";
            // 
            // lblCanceledAppointments
            // 
            this.lblCanceledAppointments.AutoSize = true;
            this.lblCanceledAppointments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCanceledAppointments.ForeColor = System.Drawing.Color.Blue;
            this.lblCanceledAppointments.Location = new System.Drawing.Point(600, 134);
            this.lblCanceledAppointments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCanceledAppointments.Name = "lblCanceledAppointments";
            this.lblCanceledAppointments.Size = new System.Drawing.Size(22, 25);
            this.lblCanceledAppointments.TabIndex = 7;
            this.lblCanceledAppointments.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 134);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Отменено:";
            // 
            // lblPlannedAppointments
            // 
            this.lblPlannedAppointments.AutoSize = true;
            this.lblPlannedAppointments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlannedAppointments.ForeColor = System.Drawing.Color.Blue;
            this.lblPlannedAppointments.Location = new System.Drawing.Point(600, 84);
            this.lblPlannedAppointments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPlannedAppointments.Name = "lblPlannedAppointments";
            this.lblPlannedAppointments.Size = new System.Drawing.Size(22, 25);
            this.lblPlannedAppointments.TabIndex = 5;
            this.lblPlannedAppointments.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Запланировано:";
            // 
            // lblCompletedAppointments
            // 
            this.lblCompletedAppointments.AutoSize = true;
            this.lblCompletedAppointments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompletedAppointments.ForeColor = System.Drawing.Color.Blue;
            this.lblCompletedAppointments.Location = new System.Drawing.Point(343, 184);
            this.lblCompletedAppointments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompletedAppointments.Name = "lblCompletedAppointments";
            this.lblCompletedAppointments.Size = new System.Drawing.Size(22, 25);
            this.lblCompletedAppointments.TabIndex = 3;
            this.lblCompletedAppointments.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(306, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Завершено (факт. стоимость):";
            // 
            // lblTotalAppointments
            // 
            this.lblTotalAppointments.AutoSize = true;
            this.lblTotalAppointments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAppointments.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAppointments.Location = new System.Drawing.Point(343, 84);
            this.lblTotalAppointments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalAppointments.Name = "lblTotalAppointments";
            this.lblTotalAppointments.Size = new System.Drawing.Size(22, 25);
            this.lblTotalAppointments.TabIndex = 1;
            this.lblTotalAppointments.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Всего приемов:";
            // 
            // groupBoxPersonnel
            // 
            this.groupBoxPersonnel.Controls.Add(this.lblTotalNurses);
            this.groupBoxPersonnel.Controls.Add(this.label18);
            this.groupBoxPersonnel.Controls.Add(this.lblNewPatients);
            this.groupBoxPersonnel.Controls.Add(this.label16);
            this.groupBoxPersonnel.Controls.Add(this.lblTotalPatients);
            this.groupBoxPersonnel.Controls.Add(this.label14);
            this.groupBoxPersonnel.Controls.Add(this.lblActiveDoctors);
            this.groupBoxPersonnel.Controls.Add(this.label7);
            this.groupBoxPersonnel.Controls.Add(this.lblTotalDoctors);
            this.groupBoxPersonnel.Controls.Add(this.label5);
            this.groupBoxPersonnel.Location = new System.Drawing.Point(35, 34);
            this.groupBoxPersonnel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPersonnel.Name = "groupBoxPersonnel";
            this.groupBoxPersonnel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPersonnel.Size = new System.Drawing.Size(1573, 234);
            this.groupBoxPersonnel.TabIndex = 0;
            this.groupBoxPersonnel.TabStop = false;
            this.groupBoxPersonnel.Text = "Персонал и пациенты";
            // 
            // lblTotalNurses
            // 
            this.lblTotalNurses.AutoSize = true;
            this.lblTotalNurses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalNurses.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalNurses.Location = new System.Drawing.Point(857, 141);
            this.lblTotalNurses.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalNurses.Name = "lblTotalNurses";
            this.lblTotalNurses.Size = new System.Drawing.Size(22, 25);
            this.lblTotalNurses.TabIndex = 9;
            this.lblTotalNurses.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(600, 141);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(228, 25);
            this.label18.TabIndex = 8;
            this.label18.Text = "Медсестер в филиале:";
            // 
            // lblNewPatients
            // 
            this.lblNewPatients.AutoSize = true;
            this.lblNewPatients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewPatients.ForeColor = System.Drawing.Color.Blue;
            this.lblNewPatients.Location = new System.Drawing.Point(857, 91);
            this.lblNewPatients.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNewPatients.Name = "lblNewPatients";
            this.lblNewPatients.Size = new System.Drawing.Size(22, 25);
            this.lblNewPatients.TabIndex = 7;
            this.lblNewPatients.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(600, 91);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(237, 25);
            this.label16.TabIndex = 6;
            this.label16.Text = "Новых пациентов (пер.):";
            // 
            // lblTotalPatients
            // 
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPatients.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPatients.Location = new System.Drawing.Point(857, 41);
            this.lblTotalPatients.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalPatients.Name = "lblTotalPatients";
            this.lblTotalPatients.Size = new System.Drawing.Size(22, 25);
            this.lblTotalPatients.TabIndex = 5;
            this.lblTotalPatients.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(600, 41);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(226, 25);
            this.label14.TabIndex = 4;
            this.label14.Text = "Пациентов в филиале:";
            // 
            // lblActiveDoctors
            // 
            this.lblActiveDoctors.AutoSize = true;
            this.lblActiveDoctors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiveDoctors.ForeColor = System.Drawing.Color.Blue;
            this.lblActiveDoctors.Location = new System.Drawing.Point(343, 141);
            this.lblActiveDoctors.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblActiveDoctors.Name = "lblActiveDoctors";
            this.lblActiveDoctors.Size = new System.Drawing.Size(22, 25);
            this.lblActiveDoctors.TabIndex = 3;
            this.lblActiveDoctors.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 141);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Врачей активно работает:";
            // 
            // lblTotalDoctors
            // 
            this.lblTotalDoctors.AutoSize = true;
            this.lblTotalDoctors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalDoctors.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalDoctors.Location = new System.Drawing.Point(343, 91);
            this.lblTotalDoctors.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalDoctors.Name = "lblTotalDoctors";
            this.lblTotalDoctors.Size = new System.Drawing.Size(22, 25);
            this.lblTotalDoctors.TabIndex = 1;
            this.lblTotalDoctors.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Врачей зарегистрировано:";
            // 
            // tabPageDoctors
            // 
            this.tabPageDoctors.Controls.Add(this.dataGridViewTopDoctors);
            this.tabPageDoctors.Location = new System.Drawing.Point(4, 29);
            this.tabPageDoctors.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageDoctors.Name = "tabPageDoctors";
            this.tabPageDoctors.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageDoctors.Size = new System.Drawing.Size(1640, 997);
            this.tabPageDoctors.TabIndex = 1;
            this.tabPageDoctors.Text = "Топ-5 врачей";
            this.tabPageDoctors.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTopDoctors
            // 
            this.dataGridViewTopDoctors.AllowUserToAddRows = false;
            this.dataGridViewTopDoctors.AllowUserToDeleteRows = false;
            this.dataGridViewTopDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTopDoctors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTopDoctors.Location = new System.Drawing.Point(5, 5);
            this.dataGridViewTopDoctors.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridViewTopDoctors.Name = "dataGridViewTopDoctors";
            this.dataGridViewTopDoctors.ReadOnly = true;
            this.dataGridViewTopDoctors.RowHeadersWidth = 62;
            this.dataGridViewTopDoctors.RowTemplate.Height = 25;
            this.dataGridViewTopDoctors.Size = new System.Drawing.Size(1630, 987);
            this.dataGridViewTopDoctors.TabIndex = 0;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.dataGridViewTopServices);
            this.tabPageServices.Location = new System.Drawing.Point(4, 29);
            this.tabPageServices.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Size = new System.Drawing.Size(1640, 997);
            this.tabPageServices.TabIndex = 2;
            this.tabPageServices.Text = "Топ-5 услуг";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTopServices
            // 
            this.dataGridViewTopServices.AllowUserToAddRows = false;
            this.dataGridViewTopServices.AllowUserToDeleteRows = false;
            this.dataGridViewTopServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTopServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTopServices.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTopServices.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridViewTopServices.Name = "dataGridViewTopServices";
            this.dataGridViewTopServices.ReadOnly = true;
            this.dataGridViewTopServices.RowHeadersWidth = 62;
            this.dataGridViewTopServices.RowTemplate.Height = 25;
            this.dataGridViewTopServices.Size = new System.Drawing.Size(1640, 997);
            this.dataGridViewTopServices.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 1172);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            this.statusStrip.Size = new System.Drawing.Size(1648, 32);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // BranchStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1648, 1204);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BranchStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика филиала";
            this.Load += new System.EventHandler(this.BranchStatisticsForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.groupBoxFinancial.ResumeLayout(false);
            this.groupBoxFinancial.PerformLayout();
            this.groupBoxAppointments.ResumeLayout(false);
            this.groupBoxAppointments.PerformLayout();
            this.groupBoxPersonnel.ResumeLayout(false);
            this.groupBoxPersonnel.PerformLayout();
            this.tabPageDoctors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopDoctors)).EndInit();
            this.tabPageServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopServices)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panelHeader;
        private Label labelBranchName;
        private Button btnGenerate;
        private DateTimePicker dateTimePickerTo;
        private Label labelTo;
        private DateTimePicker dateTimePickerFrom;
        private Label labelFrom;
        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private GroupBox groupBoxFinancial;
        private Label lblRevenuePerDoctor;
        private Label lblAvgPerDoctor;
        private Label label19;
        private Label label20;
        private Label lblCompletedProcedures;
        private Label label17;
        private Label lblAvgAppointmentCost;
        private Label label15;
        private Label lblTotalRevenue;
        private Label label13;
        private GroupBox groupBoxAppointments;
        private Label lblNoShowRate;
        private Label lblCompletionRate;
        private Label label12;
        private Label label11;
        private ProgressBar progressBarNoShow;
        private ProgressBar progressBarCompletion;
        private Label lblNoShowAppointments;
        private Label label10;
        private Label lblCanceledAppointments;
        private Label label8;
        private Label lblPlannedAppointments;
        private Label label6;
        private Label lblCompletedAppointments;
        private Label label4;
        private Label lblTotalAppointments;
        private Label label2;
        private GroupBox groupBoxPersonnel;
        private Label lblTotalNurses;
        private Label label18;
        private Label lblNewPatients;
        private Label label16;
        private Label lblTotalPatients;
        private Label label14;
        private Label lblActiveDoctors;
        private Label label7;
        private Label lblTotalDoctors;
        private Label label5;
        private TabPage tabPageDoctors;
        private DataGridView dataGridViewTopDoctors;
        private TabPage tabPageServices;
        private DataGridView dataGridViewTopServices;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}