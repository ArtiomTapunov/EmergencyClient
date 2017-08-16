namespace EmergencyClient
{
    partial class SaveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.wordRadioButton = new System.Windows.Forms.RadioButton();
            this.excelRadioButton = new System.Windows.Forms.RadioButton();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.DepartmentCheckBox = new System.Windows.Forms.CheckBox();
            this.userGroupCheckBox = new System.Windows.Forms.CheckBox();
            this.longitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.phoneCheckBox = new System.Windows.Forms.CheckBox();
            this.latitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.emailCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите поля для сохранения в файл:";
            // 
            // wordRadioButton
            // 
            this.wordRadioButton.AutoSize = true;
            this.wordRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordRadioButton.Location = new System.Drawing.Point(12, 144);
            this.wordRadioButton.Name = "wordRadioButton";
            this.wordRadioButton.Size = new System.Drawing.Size(59, 20);
            this.wordRadioButton.TabIndex = 1;
            this.wordRadioButton.TabStop = true;
            this.wordRadioButton.Text = "Word";
            this.wordRadioButton.UseVisualStyleBackColor = true;
            // 
            // excelRadioButton
            // 
            this.excelRadioButton.AutoSize = true;
            this.excelRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.excelRadioButton.Location = new System.Drawing.Point(189, 144);
            this.excelRadioButton.Name = "excelRadioButton";
            this.excelRadioButton.Size = new System.Drawing.Size(59, 20);
            this.excelRadioButton.TabIndex = 2;
            this.excelRadioButton.TabStop = true;
            this.excelRadioButton.Text = "Excel";
            this.excelRadioButton.UseVisualStyleBackColor = true;
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusCheckBox.Location = new System.Drawing.Point(12, 42);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(151, 20);
            this.statusCheckBox.TabIndex = 3;
            this.statusCheckBox.Text = "Статус готовности";
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // DepartmentCheckBox
            // 
            this.DepartmentCheckBox.AutoSize = true;
            this.DepartmentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepartmentCheckBox.Location = new System.Drawing.Point(12, 65);
            this.DepartmentCheckBox.Name = "DepartmentCheckBox";
            this.DepartmentCheckBox.Size = new System.Drawing.Size(133, 20);
            this.DepartmentCheckBox.TabIndex = 4;
            this.DepartmentCheckBox.Text = "Подразделение";
            this.DepartmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // userGroupCheckBox
            // 
            this.userGroupCheckBox.AutoSize = true;
            this.userGroupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userGroupCheckBox.Location = new System.Drawing.Point(12, 88);
            this.userGroupCheckBox.Name = "userGroupCheckBox";
            this.userGroupCheckBox.Size = new System.Drawing.Size(170, 20);
            this.userGroupCheckBox.TabIndex = 5;
            this.userGroupCheckBox.Text = "Группа пользователя";
            this.userGroupCheckBox.UseVisualStyleBackColor = true;
            // 
            // longitudeCheckBox
            // 
            this.longitudeCheckBox.AutoSize = true;
            this.longitudeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.longitudeCheckBox.Location = new System.Drawing.Point(189, 65);
            this.longitudeCheckBox.Name = "longitudeCheckBox";
            this.longitudeCheckBox.Size = new System.Drawing.Size(81, 20);
            this.longitudeCheckBox.TabIndex = 6;
            this.longitudeCheckBox.Text = "Долгота";
            this.longitudeCheckBox.UseVisualStyleBackColor = true;
            // 
            // phoneCheckBox
            // 
            this.phoneCheckBox.AutoSize = true;
            this.phoneCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneCheckBox.Location = new System.Drawing.Point(189, 42);
            this.phoneCheckBox.Name = "phoneCheckBox";
            this.phoneCheckBox.Size = new System.Drawing.Size(166, 20);
            this.phoneCheckBox.TabIndex = 7;
            this.phoneCheckBox.Text = "Номер пользователя";
            this.phoneCheckBox.UseVisualStyleBackColor = true;
            // 
            // latitudeCheckBox
            // 
            this.latitudeCheckBox.AutoSize = true;
            this.latitudeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.latitudeCheckBox.Location = new System.Drawing.Point(189, 88);
            this.latitudeCheckBox.Name = "latitudeCheckBox";
            this.latitudeCheckBox.Size = new System.Drawing.Size(77, 20);
            this.latitudeCheckBox.TabIndex = 9;
            this.latitudeCheckBox.Text = "Широта";
            this.latitudeCheckBox.UseVisualStyleBackColor = true;
            // 
            // emailCheckBox
            // 
            this.emailCheckBox.AutoSize = true;
            this.emailCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailCheckBox.Location = new System.Drawing.Point(12, 114);
            this.emailCheckBox.Name = "emailCheckBox";
            this.emailCheckBox.Size = new System.Drawing.Size(65, 20);
            this.emailCheckBox.TabIndex = 10;
            this.emailCheckBox.Text = "E-mail";
            this.emailCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(117, 183);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(131, 35);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 230);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.emailCheckBox);
            this.Controls.Add(this.latitudeCheckBox);
            this.Controls.Add(this.phoneCheckBox);
            this.Controls.Add(this.longitudeCheckBox);
            this.Controls.Add(this.userGroupCheckBox);
            this.Controls.Add(this.DepartmentCheckBox);
            this.Controls.Add(this.statusCheckBox);
            this.Controls.Add(this.excelRadioButton);
            this.Controls.Add(this.wordRadioButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(388, 269);
            this.MinimumSize = new System.Drawing.Size(388, 269);
            this.Name = "SaveForm";
            this.Text = "Сохранение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton wordRadioButton;
        private System.Windows.Forms.RadioButton excelRadioButton;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.CheckBox DepartmentCheckBox;
        private System.Windows.Forms.CheckBox userGroupCheckBox;
        private System.Windows.Forms.CheckBox longitudeCheckBox;
        private System.Windows.Forms.CheckBox phoneCheckBox;
        private System.Windows.Forms.CheckBox latitudeCheckBox;
        private System.Windows.Forms.CheckBox emailCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}