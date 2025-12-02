namespace MedicalCenterNetwork.Forms
{
    partial class ScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonNewAppointment;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDoctors;
        private System.Windows.Forms.GroupBox groupBoxViewMode;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.RadioButton radioButtonDay;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSchedule;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonNewAppointment = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDoctors = new System.Windows.Forms.ComboBox();
            this.groupBoxViewMode = new System.Windows.Forms.GroupBox();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonWeek = new System.Windows.Forms.RadioButton();
            this.radioButtonDay = new System.Windows.Forms.RadioButton();
            this.buttonToday = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.flowLayoutPanelSchedule = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.groupBoxViewMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.buttonNewAppointment);
            this.panelTop.Controls.Add(this.buttonRefresh);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.comboBoxDoctors);
            this.panelTop.Controls.Add(this.groupBoxViewMode);
            this.panelTop.Controls.Add(this.buttonToday);
            this.panelTop.Controls.Add(this.buttonNext);
            this.panelTop.Controls.Add(this.buttonPrev);
            this.panelTop.Controls.Add(this.labelDateRange);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1327, 211);
            this.panelTop.TabIndex = 0;
            // 
            // buttonNewAppointment
            // 
            this.buttonNewAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewAppointment.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonNewAppointment.FlatAppearance.BorderSize = 0;
            this.buttonNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewAppointment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewAppointment.ForeColor = System.Drawing.Color.White;
            this.buttonNewAppointment.Location = new System.Drawing.Point(1127, 84);
            this.buttonNewAppointment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNewAppointment.Name = "buttonNewAppointment";
            this.buttonNewAppointment.Size = new System.Drawing.Size(180, 40);
            this.buttonNewAppointment.TabIndex = 9;
            this.buttonNewAppointment.Text = "Новая запись";
            this.buttonNewAppointment.UseVisualStyleBackColor = false;
            this.buttonNewAppointment.Click += new System.EventHandler(this.buttonNewAppointment_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(1127, 24);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(180, 40);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Врач:";
            // 
            // comboBoxDoctors
            // 
            this.comboBoxDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDoctors.FormattingEnabled = true;
            this.comboBoxDoctors.Location = new System.Drawing.Point(99, 79);
            this.comboBoxDoctors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDoctors.Name = "comboBoxDoctors";
            this.comboBoxDoctors.Size = new System.Drawing.Size(300, 36);
            this.comboBoxDoctors.TabIndex = 6;
            this.comboBoxDoctors.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoctors_SelectedIndexChanged);
            // 
            // groupBoxViewMode
            // 
            this.groupBoxViewMode.Controls.Add(this.radioButtonMonth);
            this.groupBoxViewMode.Controls.Add(this.radioButtonWeek);
            this.groupBoxViewMode.Controls.Add(this.radioButtonDay);
            this.groupBoxViewMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxViewMode.Location = new System.Drawing.Point(454, 24);
            this.groupBoxViewMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxViewMode.Name = "groupBoxViewMode";
            this.groupBoxViewMode.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxViewMode.Size = new System.Drawing.Size(300, 100);
            this.groupBoxViewMode.TabIndex = 5;
            this.groupBoxViewMode.TabStop = false;
            this.groupBoxViewMode.Text = "Режим просмотра";
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonMonth.Location = new System.Drawing.Point(200, 45);
            this.radioButtonMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(96, 32);
            this.radioButtonMonth.TabIndex = 2;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "Месяц";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.radioButtonMonth_CheckedChanged);
            // 
            // radioButtonWeek
            // 
            this.radioButtonWeek.AutoSize = true;
            this.radioButtonWeek.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonWeek.Location = new System.Drawing.Point(100, 45);
            this.radioButtonWeek.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonWeek.Name = "radioButtonWeek";
            this.radioButtonWeek.Size = new System.Drawing.Size(103, 32);
            this.radioButtonWeek.TabIndex = 1;
            this.radioButtonWeek.TabStop = true;
            this.radioButtonWeek.Text = "Неделя";
            this.radioButtonWeek.UseVisualStyleBackColor = true;
            this.radioButtonWeek.CheckedChanged += new System.EventHandler(this.radioButtonWeek_CheckedChanged);
            // 
            // radioButtonDay
            // 
            this.radioButtonDay.AutoSize = true;
            this.radioButtonDay.Checked = true;
            this.radioButtonDay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDay.Location = new System.Drawing.Point(20, 45);
            this.radioButtonDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonDay.Name = "radioButtonDay";
            this.radioButtonDay.Size = new System.Drawing.Size(83, 32);
            this.radioButtonDay.TabIndex = 0;
            this.radioButtonDay.TabStop = true;
            this.radioButtonDay.Text = "День";
            this.radioButtonDay.UseVisualStyleBackColor = true;
            this.radioButtonDay.CheckedChanged += new System.EventHandler(this.radioButtonDay_CheckedChanged);
            // 
            // buttonToday
            // 
            this.buttonToday.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonToday.FlatAppearance.BorderSize = 0;
            this.buttonToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToday.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToday.ForeColor = System.Drawing.Color.White;
            this.buttonToday.Location = new System.Drawing.Point(945, 24);
            this.buttonToday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonToday.Name = "buttonToday";
            this.buttonToday.Size = new System.Drawing.Size(100, 40);
            this.buttonToday.TabIndex = 4;
            this.buttonToday.Text = "Сегодня";
            this.buttonToday.UseVisualStyleBackColor = false;
            this.buttonToday.Click += new System.EventHandler(this.buttonToday_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(1053, 24);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 40);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonPrev.FlatAppearance.BorderSize = 0;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrev.ForeColor = System.Drawing.Color.White;
            this.buttonPrev.Location = new System.Drawing.Point(887, 24);
            this.buttonPrev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 40);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateRange.Location = new System.Drawing.Point(34, 27);
            this.labelDateRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(151, 32);
            this.labelDateRange.TabIndex = 1;
            this.labelDateRange.Text = "Расписание";
            // 
            // flowLayoutPanelSchedule
            // 
            this.flowLayoutPanelSchedule.AutoScroll = true;
            this.flowLayoutPanelSchedule.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSchedule.Location = new System.Drawing.Point(0, 211);
            this.flowLayoutPanelSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelSchedule.Name = "flowLayoutPanelSchedule";
            this.flowLayoutPanelSchedule.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelSchedule.Size = new System.Drawing.Size(1327, 789);
            this.flowLayoutPanelSchedule.TabIndex = 1;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1327, 1000);
            this.Controls.Add(this.flowLayoutPanelSchedule);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "ScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расписание приемов";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBoxViewMode.ResumeLayout(false);
            this.groupBoxViewMode.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}