namespace MedicalCenterNetwork.Forms
{
    partial class MedicalRecordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelPatientInfo;
        private System.Windows.Forms.Label labelPatientName;
        private System.Windows.Forms.Label labelPatientBirthDate;
        private System.Windows.Forms.Label labelPatientAge;
        private System.Windows.Forms.Label labelPatientPhone;
        private System.Windows.Forms.Label labelPatientAddress;
        private System.Windows.Forms.Label labelPatientGender;
        private System.Windows.Forms.Panel panelAppointmentInfo;
        private System.Windows.Forms.Label labelAppointmentDate;
        private System.Windows.Forms.Label labelAppointmentDoctor;
        private System.Windows.Forms.Label labelAppointmentService;
        private System.Windows.Forms.Label labelAppointmentStatus;
        private System.Windows.Forms.GroupBox groupBoxMedicalData;
        private System.Windows.Forms.Label labelComplaints;
        private System.Windows.Forms.TextBox textBoxComplaints;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.TextBox textBoxDiagnosis;
        private System.Windows.Forms.Label labelAnamnesis;
        private System.Windows.Forms.TextBox textBoxAnamnesis;
        private System.Windows.Forms.Label labelExaminationResults;
        private System.Windows.Forms.TextBox textBoxExaminationResults;
        private System.Windows.Forms.Label labelPrescriptions;
        private System.Windows.Forms.TextBox textBoxPrescriptions;
        private System.Windows.Forms.GroupBox groupBoxHistory;
        private System.Windows.Forms.Label labelHistoryCount;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonNewRecord;
        private System.Windows.Forms.Button buttonSearchPatient;
        private System.Windows.Forms.Button buttonSearchAppointment;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordID;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalRecordForm));
            this.panelPatientInfo = new System.Windows.Forms.Panel();
            this.buttonSearchPatient = new System.Windows.Forms.Button();
            this.labelPatientGender = new System.Windows.Forms.Label();
            this.labelPatientAddress = new System.Windows.Forms.Label();
            this.labelPatientPhone = new System.Windows.Forms.Label();
            this.labelPatientAge = new System.Windows.Forms.Label();
            this.labelPatientBirthDate = new System.Windows.Forms.Label();
            this.labelPatientName = new System.Windows.Forms.Label();
            this.panelAppointmentInfo = new System.Windows.Forms.Panel();
            this.buttonSearchAppointment = new System.Windows.Forms.Button();
            this.labelAppointmentStatus = new System.Windows.Forms.Label();
            this.labelAppointmentService = new System.Windows.Forms.Label();
            this.labelAppointmentDoctor = new System.Windows.Forms.Label();
            this.labelAppointmentDate = new System.Windows.Forms.Label();
            this.groupBoxMedicalData = new System.Windows.Forms.GroupBox();
            this.textBoxPrescriptions = new System.Windows.Forms.TextBox();
            this.labelPrescriptions = new System.Windows.Forms.Label();
            this.textBoxExaminationResults = new System.Windows.Forms.TextBox();
            this.labelExaminationResults = new System.Windows.Forms.Label();
            this.textBoxAnamnesis = new System.Windows.Forms.TextBox();
            this.labelAnamnesis = new System.Windows.Forms.Label();
            this.textBoxDiagnosis = new System.Windows.Forms.TextBox();
            this.labelDiagnosis = new System.Windows.Forms.Label();
            this.textBoxComplaints = new System.Windows.Forms.TextBox();
            this.labelComplaints = new System.Windows.Forms.Label();
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.labelHistoryCount = new System.Windows.Forms.Label();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonNewRecord = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPatientInfo.SuspendLayout();
            this.panelAppointmentInfo.SuspendLayout();
            this.groupBoxMedicalData.SuspendLayout();
            this.groupBoxHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPatientInfo
            // 
            this.panelPatientInfo.BackColor = System.Drawing.Color.White;
            this.panelPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPatientInfo.Controls.Add(this.buttonSearchPatient);
            this.panelPatientInfo.Controls.Add(this.labelPatientGender);
            this.panelPatientInfo.Controls.Add(this.labelPatientAddress);
            this.panelPatientInfo.Controls.Add(this.labelPatientPhone);
            this.panelPatientInfo.Controls.Add(this.labelPatientAge);
            this.panelPatientInfo.Controls.Add(this.labelPatientBirthDate);
            this.panelPatientInfo.Controls.Add(this.labelPatientName);
            this.panelPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPatientInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.panelPatientInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelPatientInfo.Name = "panelPatientInfo";
            this.panelPatientInfo.Size = new System.Drawing.Size(1200, 120);
            this.panelPatientInfo.TabIndex = 0;
            // 
            // buttonSearchPatient
            // 
            this.buttonSearchPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchPatient.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSearchPatient.FlatAppearance.BorderSize = 0;
            this.buttonSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchPatient.ForeColor = System.Drawing.Color.White;
            this.buttonSearchPatient.Location = new System.Drawing.Point(1030, 38);
            this.buttonSearchPatient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.Size = new System.Drawing.Size(150, 48);
            this.buttonSearchPatient.TabIndex = 6;
            this.buttonSearchPatient.Text = "Выбрать пациента";
            this.buttonSearchPatient.UseVisualStyleBackColor = false;
            this.buttonSearchPatient.Click += new System.EventHandler(this.buttonSearchPatient_Click);
            // 
            // labelPatientGender
            // 
            this.labelPatientGender.AutoSize = true;
            this.labelPatientGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientGender.Location = new System.Drawing.Point(450, 70);
            this.labelPatientGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientGender.Name = "labelPatientGender";
            this.labelPatientGender.Size = new System.Drawing.Size(58, 28);
            this.labelPatientGender.TabIndex = 5;
            this.labelPatientGender.Text = "Пол: ";
            // 
            // labelPatientAddress
            // 
            this.labelPatientAddress.AutoSize = true;
            this.labelPatientAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientAddress.Location = new System.Drawing.Point(22, 70);
            this.labelPatientAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientAddress.Name = "labelPatientAddress";
            this.labelPatientAddress.Size = new System.Drawing.Size(76, 28);
            this.labelPatientAddress.TabIndex = 4;
            this.labelPatientAddress.Text = "Адрес: ";
            // 
            // labelPatientPhone
            // 
            this.labelPatientPhone.AutoSize = true;
            this.labelPatientPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientPhone.Location = new System.Drawing.Point(680, 25);
            this.labelPatientPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientPhone.Name = "labelPatientPhone";
            this.labelPatientPhone.Size = new System.Drawing.Size(100, 28);
            this.labelPatientPhone.TabIndex = 3;
            this.labelPatientPhone.Text = "Телефон: ";
            // 
            // labelPatientAge
            // 
            this.labelPatientAge.AutoSize = true;
            this.labelPatientAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientAge.Location = new System.Drawing.Point(450, 25);
            this.labelPatientAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientAge.Name = "labelPatientAge";
            this.labelPatientAge.Size = new System.Drawing.Size(92, 28);
            this.labelPatientAge.TabIndex = 2;
            this.labelPatientAge.Text = "Возраст: ";
            // 
            // labelPatientBirthDate
            // 
            this.labelPatientBirthDate.AutoSize = true;
            this.labelPatientBirthDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientBirthDate.Location = new System.Drawing.Point(220, 70);
            this.labelPatientBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientBirthDate.Name = "labelPatientBirthDate";
            this.labelPatientBirthDate.Size = new System.Drawing.Size(162, 28);
            this.labelPatientBirthDate.TabIndex = 1;
            this.labelPatientBirthDate.Text = "Дата рождения: ";
            // 
            // labelPatientName
            // 
            this.labelPatientName.AutoSize = true;
            this.labelPatientName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientName.Location = new System.Drawing.Point(22, 20);
            this.labelPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientName.Name = "labelPatientName";
            this.labelPatientName.Size = new System.Drawing.Size(150, 32);
            this.labelPatientName.TabIndex = 0;
            this.labelPatientName.Text = "Пациент: ...";
            // 
            // panelAppointmentInfo
            // 
            this.panelAppointmentInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAppointmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAppointmentInfo.Controls.Add(this.buttonSearchAppointment);
            this.panelAppointmentInfo.Controls.Add(this.labelAppointmentStatus);
            this.panelAppointmentInfo.Controls.Add(this.labelAppointmentService);
            this.panelAppointmentInfo.Controls.Add(this.labelAppointmentDoctor);
            this.panelAppointmentInfo.Controls.Add(this.labelAppointmentDate);
            this.panelAppointmentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAppointmentInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelAppointmentInfo.Location = new System.Drawing.Point(0, 120);
            this.panelAppointmentInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAppointmentInfo.Name = "panelAppointmentInfo";
            this.panelAppointmentInfo.Size = new System.Drawing.Size(1200, 80);
            this.panelAppointmentInfo.TabIndex = 1;
            // 
            // buttonSearchAppointment
            // 
            this.buttonSearchAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchAppointment.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSearchAppointment.FlatAppearance.BorderSize = 0;
            this.buttonSearchAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchAppointment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchAppointment.ForeColor = System.Drawing.Color.White;
            this.buttonSearchAppointment.Location = new System.Drawing.Point(986, 15);
            this.buttonSearchAppointment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchAppointment.Name = "buttonSearchAppointment";
            this.buttonSearchAppointment.Size = new System.Drawing.Size(194, 48);
            this.buttonSearchAppointment.TabIndex = 4;
            this.buttonSearchAppointment.Text = "Выбрать прием";
            this.buttonSearchAppointment.UseVisualStyleBackColor = false;
            this.buttonSearchAppointment.Click += new System.EventHandler(this.buttonSearchAppointment_Click);
            // 
            // labelAppointmentStatus
            // 
            this.labelAppointmentStatus.AutoSize = true;
            this.labelAppointmentStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppointmentStatus.Location = new System.Drawing.Point(680, 25);
            this.labelAppointmentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppointmentStatus.Name = "labelAppointmentStatus";
            this.labelAppointmentStatus.Size = new System.Drawing.Size(78, 28);
            this.labelAppointmentStatus.TabIndex = 3;
            this.labelAppointmentStatus.Text = "Статус: ";
            // 
            // labelAppointmentService
            // 
            this.labelAppointmentService.AutoSize = true;
            this.labelAppointmentService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppointmentService.Location = new System.Drawing.Point(450, 25);
            this.labelAppointmentService.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppointmentService.Name = "labelAppointmentService";
            this.labelAppointmentService.Size = new System.Drawing.Size(80, 28);
            this.labelAppointmentService.TabIndex = 2;
            this.labelAppointmentService.Text = "Услуга: ";
            // 
            // labelAppointmentDoctor
            // 
            this.labelAppointmentDoctor.AutoSize = true;
            this.labelAppointmentDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppointmentDoctor.Location = new System.Drawing.Point(220, 25);
            this.labelAppointmentDoctor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppointmentDoctor.Name = "labelAppointmentDoctor";
            this.labelAppointmentDoctor.Size = new System.Drawing.Size(65, 28);
            this.labelAppointmentDoctor.TabIndex = 1;
            this.labelAppointmentDoctor.Text = "Врач: ";
            // 
            // labelAppointmentDate
            // 
            this.labelAppointmentDate.AutoSize = true;
            this.labelAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppointmentDate.Location = new System.Drawing.Point(22, 25);
            this.labelAppointmentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppointmentDate.Name = "labelAppointmentDate";
            this.labelAppointmentDate.Size = new System.Drawing.Size(138, 28);
            this.labelAppointmentDate.TabIndex = 0;
            this.labelAppointmentDate.Text = "Дата приема: ";
            // 
            // groupBoxMedicalData
            // 
            this.groupBoxMedicalData.Controls.Add(this.textBoxPrescriptions);
            this.groupBoxMedicalData.Controls.Add(this.labelPrescriptions);
            this.groupBoxMedicalData.Controls.Add(this.textBoxExaminationResults);
            this.groupBoxMedicalData.Controls.Add(this.labelExaminationResults);
            this.groupBoxMedicalData.Controls.Add(this.textBoxAnamnesis);
            this.groupBoxMedicalData.Controls.Add(this.labelAnamnesis);
            this.groupBoxMedicalData.Controls.Add(this.textBoxDiagnosis);
            this.groupBoxMedicalData.Controls.Add(this.labelDiagnosis);
            this.groupBoxMedicalData.Controls.Add(this.textBoxComplaints);
            this.groupBoxMedicalData.Controls.Add(this.labelComplaints);
            this.groupBoxMedicalData.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxMedicalData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMedicalData.Location = new System.Drawing.Point(0, 200);
            this.groupBoxMedicalData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMedicalData.Name = "groupBoxMedicalData";
            this.groupBoxMedicalData.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMedicalData.Size = new System.Drawing.Size(600, 614);
            this.groupBoxMedicalData.TabIndex = 2;
            this.groupBoxMedicalData.TabStop = false;
            this.groupBoxMedicalData.Text = "Данные осмотра";
            // 
            // textBoxPrescriptions
            // 
            this.textBoxPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrescriptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPrescriptions.Location = new System.Drawing.Point(18, 434);
            this.textBoxPrescriptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPrescriptions.Multiline = true;
            this.textBoxPrescriptions.Name = "textBoxPrescriptions";
            this.textBoxPrescriptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrescriptions.Size = new System.Drawing.Size(554, 60);
            this.textBoxPrescriptions.TabIndex = 9;
            // 
            // labelPrescriptions
            // 
            this.labelPrescriptions.AutoSize = true;
            this.labelPrescriptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrescriptions.Location = new System.Drawing.Point(18, 401);
            this.labelPrescriptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrescriptions.Name = "labelPrescriptions";
            this.labelPrescriptions.Size = new System.Drawing.Size(285, 28);
            this.labelPrescriptions.TabIndex = 8;
            this.labelPrescriptions.Text = "Назначения и рекомендации:";
            // 
            // textBoxExaminationResults
            // 
            this.textBoxExaminationResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExaminationResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxExaminationResults.Location = new System.Drawing.Point(18, 331);
            this.textBoxExaminationResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxExaminationResults.Multiline = true;
            this.textBoxExaminationResults.Name = "textBoxExaminationResults";
            this.textBoxExaminationResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExaminationResults.Size = new System.Drawing.Size(554, 60);
            this.textBoxExaminationResults.TabIndex = 7;
            // 
            // labelExaminationResults
            // 
            this.labelExaminationResults.AutoSize = true;
            this.labelExaminationResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExaminationResults.Location = new System.Drawing.Point(18, 298);
            this.labelExaminationResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExaminationResults.Name = "labelExaminationResults";
            this.labelExaminationResults.Size = new System.Drawing.Size(199, 28);
            this.labelExaminationResults.TabIndex = 6;
            this.labelExaminationResults.Text = "Результаты осмотра:";
            // 
            // textBoxAnamnesis
            // 
            this.textBoxAnamnesis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAnamnesis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAnamnesis.Location = new System.Drawing.Point(18, 228);
            this.textBoxAnamnesis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAnamnesis.Multiline = true;
            this.textBoxAnamnesis.Name = "textBoxAnamnesis";
            this.textBoxAnamnesis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAnamnesis.Size = new System.Drawing.Size(554, 60);
            this.textBoxAnamnesis.TabIndex = 5;
            // 
            // labelAnamnesis
            // 
            this.labelAnamnesis.AutoSize = true;
            this.labelAnamnesis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAnamnesis.Location = new System.Drawing.Point(18, 195);
            this.labelAnamnesis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAnamnesis.Name = "labelAnamnesis";
            this.labelAnamnesis.Size = new System.Drawing.Size(96, 28);
            this.labelAnamnesis.TabIndex = 4;
            this.labelAnamnesis.Text = "Анамнез:";
            // 
            // textBoxDiagnosis
            // 
            this.textBoxDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDiagnosis.Location = new System.Drawing.Point(18, 155);
            this.textBoxDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDiagnosis.Multiline = true;
            this.textBoxDiagnosis.Name = "textBoxDiagnosis";
            this.textBoxDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDiagnosis.Size = new System.Drawing.Size(554, 35);
            this.textBoxDiagnosis.TabIndex = 3;
            // 
            // labelDiagnosis
            // 
            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiagnosis.Location = new System.Drawing.Point(18, 127);
            this.labelDiagnosis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDiagnosis.Name = "labelDiagnosis";
            this.labelDiagnosis.Size = new System.Drawing.Size(93, 28);
            this.labelDiagnosis.TabIndex = 2;
            this.labelDiagnosis.Text = "Диагноз:";
            // 
            // textBoxComplaints
            // 
            this.textBoxComplaints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComplaints.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComplaints.Location = new System.Drawing.Point(18, 87);
            this.textBoxComplaints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxComplaints.Multiline = true;
            this.textBoxComplaints.Name = "textBoxComplaints";
            this.textBoxComplaints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComplaints.Size = new System.Drawing.Size(554, 35);
            this.textBoxComplaints.TabIndex = 1;
            // 
            // labelComplaints
            // 
            this.labelComplaints.AutoSize = true;
            this.labelComplaints.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComplaints.Location = new System.Drawing.Point(18, 54);
            this.labelComplaints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComplaints.Name = "labelComplaints";
            this.labelComplaints.Size = new System.Drawing.Size(92, 28);
            this.labelComplaints.TabIndex = 0;
            this.labelComplaints.Text = "Жалобы:";
            // 
            // groupBoxHistory
            // 
            this.groupBoxHistory.Controls.Add(this.labelHistoryCount);
            this.groupBoxHistory.Controls.Add(this.dataGridViewHistory);
            this.groupBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxHistory.Location = new System.Drawing.Point(600, 200);
            this.groupBoxHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxHistory.Size = new System.Drawing.Size(600, 614);
            this.groupBoxHistory.TabIndex = 3;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "История обращений";
            // 
            // labelHistoryCount
            // 
            this.labelHistoryCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHistoryCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHistoryCount.Location = new System.Drawing.Point(22, 35);
            this.labelHistoryCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHistoryCount.Name = "labelHistoryCount";
            this.labelHistoryCount.Size = new System.Drawing.Size(554, 28);
            this.labelHistoryCount.TabIndex = 1;
            this.labelHistoryCount.Text = "История обращений: 0 записей";
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewHistory.ColumnHeadersHeight = 40;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colDoctor,
            this.colDiagnosis,
            this.colRecordID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewHistory.EnableHeadersVisualStyles = false;
            this.dataGridViewHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridViewHistory.Location = new System.Drawing.Point(22, 68);
            this.dataGridViewHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewHistory.MultiSelect = false;
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.RowHeadersWidth = 51;
            this.dataGridViewHistory.RowTemplate.Height = 35;
            this.dataGridViewHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistory.Size = new System.Drawing.Size(554, 511);
            this.dataGridViewHistory.TabIndex = 0;
            this.dataGridViewHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistory_CellDoubleClick);
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.FillWeight = 30F;
            this.colDate.HeaderText = "Дата";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDoctor
            // 
            this.colDoctor.DataPropertyName = "Doctor";
            this.colDoctor.FillWeight = 30F;
            this.colDoctor.HeaderText = "Врач";
            this.colDoctor.MinimumWidth = 6;
            this.colDoctor.Name = "colDoctor";
            this.colDoctor.ReadOnly = true;
            // 
            // colDiagnosis
            // 
            this.colDiagnosis.DataPropertyName = "Diagnosis";
            this.colDiagnosis.FillWeight = 40F;
            this.colDiagnosis.HeaderText = "Диагноз";
            this.colDiagnosis.MinimumWidth = 6;
            this.colDiagnosis.Name = "colDiagnosis";
            this.colDiagnosis.ReadOnly = true;
            // 
            // colRecordID
            // 
            this.colRecordID.DataPropertyName = "RecordID";
            this.colRecordID.FillWeight = 10F;
            this.colRecordID.HeaderText = "ID";
            this.colRecordID.MinimumWidth = 6;
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.ReadOnly = true;
            this.colRecordID.Visible = false;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.buttonNewRecord);
            this.panelActions.Controls.Add(this.buttonCancel);
            this.panelActions.Controls.Add(this.buttonSave);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 814);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(22, 12, 22, 12);
            this.panelActions.Size = new System.Drawing.Size(1200, 90);
            this.panelActions.TabIndex = 4;
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewRecord.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonNewRecord.FlatAppearance.BorderSize = 0;
            this.buttonNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewRecord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewRecord.ForeColor = System.Drawing.Color.White;
            this.buttonNewRecord.Location = new System.Drawing.Point(656, 12);
            this.buttonNewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(182, 62);
            this.buttonNewRecord.TabIndex = 2;
            this.buttonNewRecord.Text = "Новая запись";
            this.buttonNewRecord.UseVisualStyleBackColor = false;
            this.buttonNewRecord.Click += new System.EventHandler(this.buttonNewRecord_Click);
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
            this.buttonCancel.Location = new System.Drawing.Point(1028, 12);
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
            this.buttonSave.Location = new System.Drawing.Point(859, 12);
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
            // MedicalRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1200, 904);
            this.Controls.Add(this.groupBoxHistory);
            this.Controls.Add(this.groupBoxMedicalData);
            this.Controls.Add(this.panelAppointmentInfo);
            this.Controls.Add(this.panelPatientInfo);
            this.Controls.Add(this.panelActions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1200, 740);
            this.Name = "MedicalRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Медицинская карта пациента";
            this.Load += new System.EventHandler(this.MedicalRecordForm_Load);
            this.panelPatientInfo.ResumeLayout(false);
            this.panelPatientInfo.PerformLayout();
            this.panelAppointmentInfo.ResumeLayout(false);
            this.panelAppointmentInfo.PerformLayout();
            this.groupBoxMedicalData.ResumeLayout(false);
            this.groupBoxMedicalData.PerformLayout();
            this.groupBoxHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }
    }
}