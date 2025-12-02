namespace MedicalCenterNetwork.Forms
{
    partial class NurseScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NurseScheduleForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonNextDay = new System.Windows.Forms.Button();
            this.buttonPrevDay = new System.Windows.Forms.Button();
            this.buttonToday = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.listViewProcedures = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProcedure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDiagnosis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.buttonRefresh);
            this.panelHeader.Controls.Add(this.buttonNextDay);
            this.panelHeader.Controls.Add(this.buttonPrevDay);
            this.panelHeader.Controls.Add(this.buttonToday);
            this.panelHeader.Controls.Add(this.labelDate);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1771, 134);
            this.panelHeader.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(1379, 34);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(172, 50);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonNextDay
            // 
            this.buttonNextDay.Location = new System.Drawing.Point(1097, 34);
            this.buttonNextDay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonNextDay.Name = "buttonNextDay";
            this.buttonNextDay.Size = new System.Drawing.Size(253, 50);
            this.buttonNextDay.TabIndex = 4;
            this.buttonNextDay.Text = "Следующий день";
            this.buttonNextDay.UseVisualStyleBackColor = true;
            this.buttonNextDay.Click += new System.EventHandler(this.buttonNextDay_Click);
            // 
            // buttonPrevDay
            // 
            this.buttonPrevDay.Location = new System.Drawing.Point(788, 34);
            this.buttonPrevDay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonPrevDay.Name = "buttonPrevDay";
            this.buttonPrevDay.Size = new System.Drawing.Size(281, 50);
            this.buttonPrevDay.TabIndex = 3;
            this.buttonPrevDay.Text = "Предыдущий день";
            this.buttonPrevDay.UseVisualStyleBackColor = true;
            this.buttonPrevDay.Click += new System.EventHandler(this.buttonPrevDay_Click);
            // 
            // buttonToday
            // 
            this.buttonToday.Location = new System.Drawing.Point(583, 34);
            this.buttonToday.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonToday.Name = "buttonToday";
            this.buttonToday.Size = new System.Drawing.Size(172, 50);
            this.buttonToday.TabIndex = 2;
            this.buttonToday.Text = "Сегодня";
            this.buttonToday.UseVisualStyleBackColor = true;
            this.buttonToday.Click += new System.EventHandler(this.buttonToday_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelDate.Location = new System.Drawing.Point(308, 41);
            this.labelDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(140, 32);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "01.01.2024";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(35, 34);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(251, 38);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Мои процедуры:";
            // 
            // listViewProcedures
            // 
            this.listViewProcedures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderPatient,
            this.columnHeaderProcedure,
            this.columnHeaderDiagnosis,
            this.columnHeaderStatus,
            this.columnHeaderNotes});
            this.listViewProcedures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcedures.FullRowSelect = true;
            this.listViewProcedures.GridLines = true;
            this.listViewProcedures.HideSelection = false;
            this.listViewProcedures.Location = new System.Drawing.Point(0, 134);
            this.listViewProcedures.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listViewProcedures.Name = "listViewProcedures";
            this.listViewProcedures.Size = new System.Drawing.Size(1771, 866);
            this.listViewProcedures.TabIndex = 1;
            this.listViewProcedures.UseCompatibleStateImageBehavior = false;
            this.listViewProcedures.View = System.Windows.Forms.View.Details;
            this.listViewProcedures.DoubleClick += new System.EventHandler(this.listViewProcedures_DoubleClick);
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Время";
            this.columnHeaderTime.Width = 80;
            // 
            // columnHeaderPatient
            // 
            this.columnHeaderPatient.Text = "Пациент";
            this.columnHeaderPatient.Width = 200;
            // 
            // columnHeaderProcedure
            // 
            this.columnHeaderProcedure.Text = "Процедура";
            this.columnHeaderProcedure.Width = 150;
            // 
            // columnHeaderDiagnosis
            // 
            this.columnHeaderDiagnosis.Text = "Диагноз";
            this.columnHeaderDiagnosis.Width = 150;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Статус";
            this.columnHeaderStatus.Width = 100;
            // 
            // columnHeaderNotes
            // 
            this.columnHeaderNotes.Text = "Примечания";
            this.columnHeaderNotes.Width = 200;
            // 
            // NurseScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 1000);
            this.Controls.Add(this.listViewProcedures);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "NurseScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расписание процедур медсестры";
            this.Load += new System.EventHandler(this.NurseScheduleForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonNextDay;
        private System.Windows.Forms.Button buttonPrevDay;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListView listViewProcedures;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderPatient;
        private System.Windows.Forms.ColumnHeader columnHeaderProcedure;
        private System.Windows.Forms.ColumnHeader columnHeaderDiagnosis;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderNotes;
    }
}