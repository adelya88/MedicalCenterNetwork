using System.Windows.Forms;

namespace MedicalCenterNetwork.Forms
{
    partial class MyStatisticsForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyStatisticsForm));
            this.groupBoxPeriod = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.groupBoxMainStats = new System.Windows.Forms.GroupBox();
            this.labelAvgPerDayValue = new System.Windows.Forms.Label();
            this.labelAvgPerDayLabel = new System.Windows.Forms.Label();
            this.labelRecordsCreatedValue = new System.Windows.Forms.Label();
            this.labelRecordsCreatedLabel = new System.Windows.Forms.Label();
            this.labelUniquePatientsValue = new System.Windows.Forms.Label();
            this.labelUniquePatientsLabel = new System.Windows.Forms.Label();
            this.labelNoShowValue = new System.Windows.Forms.Label();
            this.labelNoShowLabel = new System.Windows.Forms.Label();
            this.labelCanceledValue = new System.Windows.Forms.Label();
            this.labelCanceledLabel = new System.Windows.Forms.Label();
            this.labelPlannedValue = new System.Windows.Forms.Label();
            this.labelPlannedLabel = new System.Windows.Forms.Label();
            this.labelCompletedValue = new System.Windows.Forms.Label();
            this.labelCompletedLabel = new System.Windows.Forms.Label();
            this.labelTotalValue = new System.Windows.Forms.Label();
            this.labelTotalLabel = new System.Windows.Forms.Label();
            this.groupBoxPercent = new System.Windows.Forms.GroupBox();
            this.labelNoShowRate = new System.Windows.Forms.Label();
            this.labelCompletionRate = new System.Windows.Forms.Label();
            this.progressBarNoShow = new System.Windows.Forms.ProgressBar();
            this.progressBarCompletion = new System.Windows.Forms.ProgressBar();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxPeriod.SuspendLayout();
            this.groupBoxMainStats.SuspendLayout();
            this.groupBoxPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPeriod
            // 
            this.groupBoxPeriod.Controls.Add(this.btnGenerate);
            this.groupBoxPeriod.Controls.Add(this.dateTimePickerTo);
            this.groupBoxPeriod.Controls.Add(this.labelTo);
            this.groupBoxPeriod.Controls.Add(this.dateTimePickerFrom);
            this.groupBoxPeriod.Controls.Add(this.labelFrom);
            this.groupBoxPeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPeriod.Location = new System.Drawing.Point(35, 34);
            this.groupBoxPeriod.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPeriod.Name = "groupBoxPeriod";
            this.groupBoxPeriod.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPeriod.Size = new System.Drawing.Size(1457, 116);
            this.groupBoxPeriod.TabIndex = 0;
            this.groupBoxPeriod.TabStop = false;
            this.groupBoxPeriod.Text = "Период отчета";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerate.Location = new System.Drawing.Point(600, 36);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(257, 41);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Сформировать отчет";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(360, 39);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(203, 34);
            this.dateTimePickerTo.TabIndex = 3;
            this.dateTimePickerTo.Value = new System.DateTime(2024, 1, 30, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTo.Location = new System.Drawing.Point(308, 45);
            this.labelTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(41, 28);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "по:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(77, 39);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(203, 34);
            this.dateTimePickerFrom.TabIndex = 1;
            this.dateTimePickerFrom.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(35, 45);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(29, 28);
            this.labelFrom.TabIndex = 0;
            this.labelFrom.Text = "С:";
            // 
            // groupBoxMainStats
            // 
            this.groupBoxMainStats.Controls.Add(this.labelAvgPerDayValue);
            this.groupBoxMainStats.Controls.Add(this.labelAvgPerDayLabel);
            this.groupBoxMainStats.Controls.Add(this.labelRecordsCreatedValue);
            this.groupBoxMainStats.Controls.Add(this.labelRecordsCreatedLabel);
            this.groupBoxMainStats.Controls.Add(this.labelUniquePatientsValue);
            this.groupBoxMainStats.Controls.Add(this.labelUniquePatientsLabel);
            this.groupBoxMainStats.Controls.Add(this.labelNoShowValue);
            this.groupBoxMainStats.Controls.Add(this.labelNoShowLabel);
            this.groupBoxMainStats.Controls.Add(this.labelCanceledValue);
            this.groupBoxMainStats.Controls.Add(this.labelCanceledLabel);
            this.groupBoxMainStats.Controls.Add(this.labelPlannedValue);
            this.groupBoxMainStats.Controls.Add(this.labelPlannedLabel);
            this.groupBoxMainStats.Controls.Add(this.labelCompletedValue);
            this.groupBoxMainStats.Controls.Add(this.labelCompletedLabel);
            this.groupBoxMainStats.Controls.Add(this.labelTotalValue);
            this.groupBoxMainStats.Controls.Add(this.labelTotalLabel);
            this.groupBoxMainStats.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMainStats.Location = new System.Drawing.Point(35, 184);
            this.groupBoxMainStats.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxMainStats.Name = "groupBoxMainStats";
            this.groupBoxMainStats.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxMainStats.Size = new System.Drawing.Size(1457, 300);
            this.groupBoxMainStats.TabIndex = 1;
            this.groupBoxMainStats.TabStop = false;
            this.groupBoxMainStats.Text = "Основные показатели";
            // 
            // labelAvgPerDayValue
            // 
            this.labelAvgPerDayValue.AutoSize = true;
            this.labelAvgPerDayValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelAvgPerDayValue.ForeColor = System.Drawing.Color.Blue;
            this.labelAvgPerDayValue.Location = new System.Drawing.Point(951, 244);
            this.labelAvgPerDayValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAvgPerDayValue.Name = "labelAvgPerDayValue";
            this.labelAvgPerDayValue.Size = new System.Drawing.Size(22, 25);
            this.labelAvgPerDayValue.TabIndex = 15;
            this.labelAvgPerDayValue.Text = "0";
            // 
            // labelAvgPerDayLabel
            // 
            this.labelAvgPerDayLabel.AutoSize = true;
            this.labelAvgPerDayLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAvgPerDayLabel.Location = new System.Drawing.Point(635, 241);
            this.labelAvgPerDayLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelAvgPerDayLabel.Name = "labelAvgPerDayLabel";
            this.labelAvgPerDayLabel.Size = new System.Drawing.Size(258, 28);
            this.labelAvgPerDayLabel.TabIndex = 14;
            this.labelAvgPerDayLabel.Text = "Среднее приемов в день:";
            // 
            // labelRecordsCreatedValue
            // 
            this.labelRecordsCreatedValue.AutoSize = true;
            this.labelRecordsCreatedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRecordsCreatedValue.ForeColor = System.Drawing.Color.Blue;
            this.labelRecordsCreatedValue.Location = new System.Drawing.Point(951, 187);
            this.labelRecordsCreatedValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelRecordsCreatedValue.Name = "labelRecordsCreatedValue";
            this.labelRecordsCreatedValue.Size = new System.Drawing.Size(22, 25);
            this.labelRecordsCreatedValue.TabIndex = 13;
            this.labelRecordsCreatedValue.Text = "0";
            // 
            // labelRecordsCreatedLabel
            // 
            this.labelRecordsCreatedLabel.AutoSize = true;
            this.labelRecordsCreatedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRecordsCreatedLabel.Location = new System.Drawing.Point(635, 184);
            this.labelRecordsCreatedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelRecordsCreatedLabel.Name = "labelRecordsCreatedLabel";
            this.labelRecordsCreatedLabel.Size = new System.Drawing.Size(300, 28);
            this.labelRecordsCreatedLabel.TabIndex = 12;
            this.labelRecordsCreatedLabel.Text = "Создано записей в медкартах:";
            // 
            // labelUniquePatientsValue
            // 
            this.labelUniquePatientsValue.AutoSize = true;
            this.labelUniquePatientsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelUniquePatientsValue.ForeColor = System.Drawing.Color.Blue;
            this.labelUniquePatientsValue.Location = new System.Drawing.Point(951, 128);
            this.labelUniquePatientsValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelUniquePatientsValue.Name = "labelUniquePatientsValue";
            this.labelUniquePatientsValue.Size = new System.Drawing.Size(22, 25);
            this.labelUniquePatientsValue.TabIndex = 11;
            this.labelUniquePatientsValue.Text = "0";
            // 
            // labelUniquePatientsLabel
            // 
            this.labelUniquePatientsLabel.AutoSize = true;
            this.labelUniquePatientsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUniquePatientsLabel.Location = new System.Drawing.Point(635, 125);
            this.labelUniquePatientsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelUniquePatientsLabel.Name = "labelUniquePatientsLabel";
            this.labelUniquePatientsLabel.Size = new System.Drawing.Size(239, 28);
            this.labelUniquePatientsLabel.TabIndex = 10;
            this.labelUniquePatientsLabel.Text = "Уникальных пациентов:";
            // 
            // labelNoShowValue
            // 
            this.labelNoShowValue.AutoSize = true;
            this.labelNoShowValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelNoShowValue.ForeColor = System.Drawing.Color.Blue;
            this.labelNoShowValue.Location = new System.Drawing.Point(951, 69);
            this.labelNoShowValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNoShowValue.Name = "labelNoShowValue";
            this.labelNoShowValue.Size = new System.Drawing.Size(22, 25);
            this.labelNoShowValue.TabIndex = 9;
            this.labelNoShowValue.Text = "0";
            // 
            // labelNoShowLabel
            // 
            this.labelNoShowLabel.AutoSize = true;
            this.labelNoShowLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoShowLabel.Location = new System.Drawing.Point(635, 66);
            this.labelNoShowLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNoShowLabel.Name = "labelNoShowLabel";
            this.labelNoShowLabel.Size = new System.Drawing.Size(233, 28);
            this.labelNoShowLabel.TabIndex = 8;
            this.labelNoShowLabel.Text = "Пациентов не явилось:";
            // 
            // labelCanceledValue
            // 
            this.labelCanceledValue.AutoSize = true;
            this.labelCanceledValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCanceledValue.ForeColor = System.Drawing.Color.Blue;
            this.labelCanceledValue.Location = new System.Drawing.Point(327, 244);
            this.labelCanceledValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCanceledValue.Name = "labelCanceledValue";
            this.labelCanceledValue.Size = new System.Drawing.Size(22, 25);
            this.labelCanceledValue.TabIndex = 7;
            this.labelCanceledValue.Text = "0";
            // 
            // labelCanceledLabel
            // 
            this.labelCanceledLabel.AutoSize = true;
            this.labelCanceledLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCanceledLabel.Location = new System.Drawing.Point(35, 241);
            this.labelCanceledLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCanceledLabel.Name = "labelCanceledLabel";
            this.labelCanceledLabel.Size = new System.Drawing.Size(230, 28);
            this.labelCanceledLabel.TabIndex = 6;
            this.labelCanceledLabel.Text = "Отмененных приемов:";
            // 
            // labelPlannedValue
            // 
            this.labelPlannedValue.AutoSize = true;
            this.labelPlannedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPlannedValue.ForeColor = System.Drawing.Color.Blue;
            this.labelPlannedValue.Location = new System.Drawing.Point(327, 187);
            this.labelPlannedValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPlannedValue.Name = "labelPlannedValue";
            this.labelPlannedValue.Size = new System.Drawing.Size(22, 25);
            this.labelPlannedValue.TabIndex = 5;
            this.labelPlannedValue.Text = "0";
            // 
            // labelPlannedLabel
            // 
            this.labelPlannedLabel.AutoSize = true;
            this.labelPlannedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlannedLabel.Location = new System.Drawing.Point(35, 184);
            this.labelPlannedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPlannedLabel.Name = "labelPlannedLabel";
            this.labelPlannedLabel.Size = new System.Drawing.Size(280, 28);
            this.labelPlannedLabel.TabIndex = 4;
            this.labelPlannedLabel.Text = "Запланированных приемов:";
            // 
            // labelCompletedValue
            // 
            this.labelCompletedValue.AutoSize = true;
            this.labelCompletedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCompletedValue.ForeColor = System.Drawing.Color.Blue;
            this.labelCompletedValue.Location = new System.Drawing.Point(327, 128);
            this.labelCompletedValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCompletedValue.Name = "labelCompletedValue";
            this.labelCompletedValue.Size = new System.Drawing.Size(22, 25);
            this.labelCompletedValue.TabIndex = 3;
            this.labelCompletedValue.Text = "0";
            // 
            // labelCompletedLabel
            // 
            this.labelCompletedLabel.AutoSize = true;
            this.labelCompletedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCompletedLabel.Location = new System.Drawing.Point(35, 125);
            this.labelCompletedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCompletedLabel.Name = "labelCompletedLabel";
            this.labelCompletedLabel.Size = new System.Drawing.Size(240, 28);
            this.labelCompletedLabel.TabIndex = 2;
            this.labelCompletedLabel.Text = "Завершенных приемов:";
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.AutoSize = true;
            this.labelTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTotalValue.ForeColor = System.Drawing.Color.Blue;
            this.labelTotalValue.Location = new System.Drawing.Point(327, 69);
            this.labelTotalValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(22, 25);
            this.labelTotalValue.TabIndex = 1;
            this.labelTotalValue.Text = "0";
            // 
            // labelTotalLabel
            // 
            this.labelTotalLabel.AutoSize = true;
            this.labelTotalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalLabel.Location = new System.Drawing.Point(35, 66);
            this.labelTotalLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTotalLabel.Name = "labelTotalLabel";
            this.labelTotalLabel.Size = new System.Drawing.Size(160, 28);
            this.labelTotalLabel.TabIndex = 0;
            this.labelTotalLabel.Text = "Всего приемов:";
            // 
            // groupBoxPercent
            // 
            this.groupBoxPercent.Controls.Add(this.labelNoShowRate);
            this.groupBoxPercent.Controls.Add(this.labelCompletionRate);
            this.groupBoxPercent.Controls.Add(this.progressBarNoShow);
            this.groupBoxPercent.Controls.Add(this.progressBarCompletion);
            this.groupBoxPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPercent.Location = new System.Drawing.Point(35, 500);
            this.groupBoxPercent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPercent.Name = "groupBoxPercent";
            this.groupBoxPercent.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxPercent.Size = new System.Drawing.Size(1457, 166);
            this.groupBoxPercent.TabIndex = 2;
            this.groupBoxPercent.TabStop = false;
            this.groupBoxPercent.Text = "Процентные показатели";
            // 
            // labelNoShowRate
            // 
            this.labelNoShowRate.AutoSize = true;
            this.labelNoShowRate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoShowRate.Location = new System.Drawing.Point(737, 100);
            this.labelNoShowRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNoShowRate.Name = "labelNoShowRate";
            this.labelNoShowRate.Size = new System.Drawing.Size(281, 28);
            this.labelNoShowRate.TabIndex = 3;
            this.labelNoShowRate.Text = "Доля неявок пациентов: 0%";
            // 
            // labelCompletionRate
            // 
            this.labelCompletionRate.AutoSize = true;
            this.labelCompletionRate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCompletionRate.Location = new System.Drawing.Point(737, 41);
            this.labelCompletionRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCompletionRate.Name = "labelCompletionRate";
            this.labelCompletionRate.Size = new System.Drawing.Size(327, 28);
            this.labelCompletionRate.TabIndex = 2;
            this.labelCompletionRate.Text = "Доля завершенных приемов: 0%";
            // 
            // progressBarNoShow
            // 
            this.progressBarNoShow.Location = new System.Drawing.Point(35, 100);
            this.progressBarNoShow.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.progressBarNoShow.Name = "progressBarNoShow";
            this.progressBarNoShow.Size = new System.Drawing.Size(685, 41);
            this.progressBarNoShow.TabIndex = 1;
            // 
            // progressBarCompletion
            // 
            this.progressBarCompletion.Location = new System.Drawing.Point(35, 41);
            this.progressBarCompletion.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.progressBarCompletion.Name = "progressBarCompletion";
            this.progressBarCompletion.Size = new System.Drawing.Size(685, 41);
            this.progressBarCompletion.TabIndex = 0;
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Location = new System.Drawing.Point(35, 700);
            this.dataGridViewDetails.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.ReadOnly = true;
            this.dataGridViewDetails.RowHeadersWidth = 62;
            this.dataGridViewDetails.RowTemplate.Height = 25;
            this.dataGridViewDetails.Size = new System.Drawing.Size(1457, 284);
            this.dataGridViewDetails.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1002);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1543, 32);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(70, 25);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // MyStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 1034);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewDetails);
            this.Controls.Add(this.groupBoxPercent);
            this.Controls.Add(this.groupBoxMainStats);
            this.Controls.Add(this.groupBoxPeriod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моя статистика";
            this.Load += new System.EventHandler(this.MyStatisticsForm_Load);
            this.groupBoxPeriod.ResumeLayout(false);
            this.groupBoxPeriod.PerformLayout();
            this.groupBoxMainStats.ResumeLayout(false);
            this.groupBoxMainStats.PerformLayout();
            this.groupBoxPercent.ResumeLayout(false);
            this.groupBoxPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBoxPeriod;
        private Button btnGenerate;
        private DateTimePicker dateTimePickerTo;
        private Label labelTo;
        private DateTimePicker dateTimePickerFrom;
        private Label labelFrom;
        private GroupBox groupBoxMainStats;
        private Label labelAvgPerDayValue;
        private Label labelAvgPerDayLabel;
        private Label labelRecordsCreatedValue;
        private Label labelRecordsCreatedLabel;
        private Label labelUniquePatientsValue;
        private Label labelUniquePatientsLabel;
        private Label labelNoShowValue;
        private Label labelNoShowLabel;
        private Label labelCanceledValue;
        private Label labelCanceledLabel;
        private Label labelPlannedValue;
        private Label labelPlannedLabel;
        private Label labelCompletedValue;
        private Label labelCompletedLabel;
        private Label labelTotalValue;
        private Label labelTotalLabel;
        private GroupBox groupBoxPercent;
        private Label labelNoShowRate;
        private Label labelCompletionRate;
        private ProgressBar progressBarNoShow;
        private ProgressBar progressBarCompletion;
        private DataGridView dataGridViewDetails;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}