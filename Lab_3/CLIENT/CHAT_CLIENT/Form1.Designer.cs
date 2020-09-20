namespace CHAT_CLIENT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectGrid = new System.Windows.Forms.DataGridView();
            this.subjectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateGrid = new System.Windows.Forms.DataGridView();
            this.dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsGrid = new System.Windows.Forms.DataGridView();
            this.studentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Предмет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Список студентов";
            // 
            // SubjectGrid
            // 
            this.SubjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectCol});
            this.SubjectGrid.Location = new System.Drawing.Point(153, 41);
            this.SubjectGrid.MultiSelect = false;
            this.SubjectGrid.Name = "SubjectGrid";
            this.SubjectGrid.Size = new System.Drawing.Size(122, 389);
            this.SubjectGrid.TabIndex = 9;
            this.SubjectGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SubjectGrid_CellClick);
            // 
            // subjectCol
            // 
            this.subjectCol.HeaderText = "Предмет";
            this.subjectCol.Name = "subjectCol";
            // 
            // DateGrid
            // 
            this.DateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateCol});
            this.DateGrid.Location = new System.Drawing.Point(281, 41);
            this.DateGrid.MultiSelect = false;
            this.DateGrid.Name = "DateGrid";
            this.DateGrid.Size = new System.Drawing.Size(237, 389);
            this.DateGrid.TabIndex = 10;
            this.DateGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DateGrid_CellClick);
            // 
            // dateCol
            // 
            this.dateCol.HeaderText = "Дата занятия";
            this.dateCol.Name = "dateCol";
            // 
            // StudentsGrid
            // 
            this.StudentsGrid.AllowUserToDeleteRows = false;
            this.StudentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentCol,
            this.markCol});
            this.StudentsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.StudentsGrid.Location = new System.Drawing.Point(524, 41);
            this.StudentsGrid.MultiSelect = false;
            this.StudentsGrid.Name = "StudentsGrid";
            this.StudentsGrid.Size = new System.Drawing.Size(264, 389);
            this.StudentsGrid.StandardTab = true;
            this.StudentsGrid.TabIndex = 11;
            this.StudentsGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.StudentsGrid_RowHeaderMouseClick);
            // 
            // studentCol
            // 
            this.studentCol.HeaderText = "Студент";
            this.studentCol.Name = "studentCol";
            this.studentCol.ReadOnly = true;
            // 
            // markCol
            // 
            dataGridViewCellStyle5.NullValue = "-";
            this.markCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.markCol.HeaderText = "Присутствие";
            this.markCol.Name = "markCol";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(12, 84);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(135, 23);
            this.ConfirmBtn.TabIndex = 12;
            this.ConfirmBtn.Text = "Подтвердить";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(12, 41);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(135, 23);
            this.ConnectBtn.TabIndex = 13;
            this.ConnectBtn.Text = "Подключиться";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(13, 385);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorLabel.TabIndex = 14;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(12, 129);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(135, 23);
            this.AddBtn.TabIndex = 15;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(12, 175);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(135, 23);
            this.DelBtn.TabIndex = 16;
            this.DelBtn.Text = "Удалить";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.StudentsGrid);
            this.Controls.Add(this.DateGrid);
            this.Controls.Add(this.SubjectGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SubjectGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView SubjectGrid;
        private System.Windows.Forms.DataGridView DateGrid;
        private System.Windows.Forms.DataGridView StudentsGrid;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn markCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCol;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DelBtn;
    }
}

