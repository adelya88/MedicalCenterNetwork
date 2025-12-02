using System.Windows.Forms;

namespace MedicalCenterNetwork.Forms
{
    partial class AppointmentDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentDetailsForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxPatient = new System.Windows.Forms.GroupBox();
            this.lblPatientInfo = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxAppointment = new System.Windows.Forms.GroupBox();
            this.lblCabinet = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBaseCost = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.groupBoxPatient.SuspendLayout();
            this.groupBoxAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxPatient);
            this.panelMain.Controls.Add(this.groupBoxAppointment);
            this.panelMain.Controls.Add(this.btnChangeStatus);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(993, 934);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxPatient
            // 
            this.groupBoxPatient.Controls.Add(this.lblPatientInfo);
            this.groupBoxPatient.Controls.Add(this.lblPhone);
            this.groupBoxPatient.Controls.Add(this.lblEmail);
            this.groupBoxPatient.Controls.Add(this.label10);
            this.groupBoxPatient.Controls.Add(this.label11);
            this.groupBoxPatient.Controls.Add(this.label12);
            this.groupBoxPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPatient.Location = new System.Drawing.Point(32, 466);
            this.groupBoxPatient.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxPatient.Name = "groupBoxPatient";
            this.groupBoxPatient.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxPatient.Size = new System.Drawing.Size(931, 224);
            this.groupBoxPatient.TabIndex = 3;
            this.groupBoxPatient.TabStop = false;
            this.groupBoxPatient.Text = "Информация о пациенте";
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.AutoSize = true;
            this.lblPatientInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPatientInfo.Location = new System.Drawing.Point(188, 56);
            this.lblPatientInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(65, 28);
            this.lblPatientInfo.TabIndex = 5;
            this.lblPatientInfo.Text = "label9";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPhone.Location = new System.Drawing.Point(188, 112);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 28);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "label9";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmail.Location = new System.Drawing.Point(188, 168);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 28);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(32, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 28);
            this.label10.TabIndex = 2;
            this.label10.Text = "Пол/Возраст:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(32, 112);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 28);
            this.label11.TabIndex = 1;
            this.label11.Text = "Телефон:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(32, 168);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 28);
            this.label12.TabIndex = 0;
            this.label12.Text = "Email:";
            // 
            // groupBoxAppointment
            // 
            this.groupBoxAppointment.Controls.Add(this.lblCabinet);
            this.groupBoxAppointment.Controls.Add(this.lblStatus);
            this.groupBoxAppointment.Controls.Add(this.lblBaseCost);
            this.groupBoxAppointment.Controls.Add(this.lblDuration);
            this.groupBoxAppointment.Controls.Add(this.lblService);
            this.groupBoxAppointment.Controls.Add(this.lblDoctor);
            this.groupBoxAppointment.Controls.Add(this.lblPatient);
            this.groupBoxAppointment.Controls.Add(this.lblDateTime);
            this.groupBoxAppointment.Controls.Add(this.label8);
            this.groupBoxAppointment.Controls.Add(this.label7);
            this.groupBoxAppointment.Controls.Add(this.label6);
            this.groupBoxAppointment.Controls.Add(this.label5);
            this.groupBoxAppointment.Controls.Add(this.label4);
            this.groupBoxAppointment.Controls.Add(this.label3);
            this.groupBoxAppointment.Controls.Add(this.label2);
            this.groupBoxAppointment.Controls.Add(this.label1);
            this.groupBoxAppointment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxAppointment.Location = new System.Drawing.Point(32, 38);
            this.groupBoxAppointment.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxAppointment.Name = "groupBoxAppointment";
            this.groupBoxAppointment.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBoxAppointment.Size = new System.Drawing.Size(931, 410);
            this.groupBoxAppointment.TabIndex = 2;
            this.groupBoxAppointment.TabStop = false;
            this.groupBoxAppointment.Text = "Детали приема";
            // 
            // lblCabinet
            // 
            this.lblCabinet.AutoSize = true;
            this.lblCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCabinet.Location = new System.Drawing.Point(669, 298);
            this.lblCabinet.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCabinet.Name = "lblCabinet";
            this.lblCabinet.Size = new System.Drawing.Size(65, 28);
            this.lblCabinet.TabIndex = 17;
            this.lblCabinet.Text = "label9";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(669, 242);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 28);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "label9";
            // 
            // lblBaseCost
            // 
            this.lblBaseCost.AutoSize = true;
            this.lblBaseCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBaseCost.Location = new System.Drawing.Point(669, 186);
            this.lblBaseCost.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBaseCost.Name = "lblBaseCost";
            this.lblBaseCost.Size = new System.Drawing.Size(65, 28);
            this.lblBaseCost.TabIndex = 15;
            this.lblBaseCost.Text = "label9";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDuration.Location = new System.Drawing.Point(669, 130);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(65, 28);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.Text = "label9";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblService.Location = new System.Drawing.Point(669, 74);
            this.lblService.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(65, 28);
            this.lblService.TabIndex = 13;
            this.lblService.Text = "label9";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDoctor.Location = new System.Drawing.Point(188, 186);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(65, 28);
            this.lblDoctor.TabIndex = 12;
            this.lblDoctor.Text = "label9";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPatient.Location = new System.Drawing.Point(188, 130);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(65, 28);
            this.lblPatient.TabIndex = 11;
            this.lblPatient.Text = "label9";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateTime.Location = new System.Drawing.Point(188, 74);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(65, 28);
            this.lblDateTime.TabIndex = 10;
            this.lblDateTime.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(472, 298);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 28);
            this.label8.TabIndex = 7;
            this.label8.Text = "Кабинет:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(472, 242);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "Статус:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(472, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Цена:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(472, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Длительность:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(472, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Услуга:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(32, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Врач:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пациент:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата и время:";
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeStatus.Location = new System.Drawing.Point(523, 723);
            this.btnChangeStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(204, 56);
            this.btnChangeStatus.TabIndex = 1;
            this.btnChangeStatus.Text = "Изменить статус";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(759, 723);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(204, 56);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AppointmentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 934);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Детали записи на прием";
            this.Load += new System.EventHandler(this.AppointmentDetailsForm_Load);
            this.panelMain.ResumeLayout(false);
            this.groupBoxPatient.ResumeLayout(false);
            this.groupBoxPatient.PerformLayout();
            this.groupBoxAppointment.ResumeLayout(false);
            this.groupBoxAppointment.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel panelMain;
        private GroupBox groupBoxPatient;
        private Label lblPatientInfo;
        private Label lblPhone;
        private Label lblEmail;
        private Label label10;
        private Label label11;
        private Label label12;
        private GroupBox groupBoxAppointment;
        private Label lblCabinet;
        private Label lblStatus;
        private Label lblBaseCost;
        private Label lblDuration;
        private Label lblService;
        private Label lblDoctor;
        private Label lblPatient;
        private Label lblDateTime;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnChangeStatus;
        private Button btnClose;
    }
}