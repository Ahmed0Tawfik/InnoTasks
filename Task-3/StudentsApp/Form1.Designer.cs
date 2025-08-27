namespace StudentsApp
{
    partial class StudentsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Save = new Button();
            StudentName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            StudentAge = new TextBox();
            label3 = new Label();
            StudentMobile = new TextBox();
            Clear = new Button();
            Result = new Label();
            Error = new Label();
            ReadAllStudents = new Button();
            GetStudentById = new Button();
            StudentId = new NumericUpDown();
            UpdateStudent = new Button();
            StudentsGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)StudentId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StudentsGrid).BeginInit();
            SuspendLayout();
            // 
            // Save
            // 
            Save.Location = new Point(356, 20);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 0;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // StudentName
            // 
            StudentName.Location = new Point(88, 22);
            StudentName.Name = "StudentName";
            StudentName.Size = new Size(251, 27);
            StudentName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 25);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 76);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 4;
            label2.Text = "Age";
            // 
            // StudentAge
            // 
            StudentAge.Location = new Point(88, 73);
            StudentAge.Name = "StudentAge";
            StudentAge.Size = new Size(251, 27);
            StudentAge.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 124);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 6;
            label3.Text = "Mobile";
            // 
            // StudentMobile
            // 
            StudentMobile.Location = new Point(88, 121);
            StudentMobile.Name = "StudentMobile";
            StudentMobile.Size = new Size(251, 27);
            StudentMobile.TabIndex = 5;
            // 
            // Clear
            // 
            Clear.Location = new Point(356, 67);
            Clear.Name = "Clear";
            Clear.Size = new Size(94, 29);
            Clear.TabIndex = 7;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.Location = new Point(36, 344);
            Result.Name = "Result";
            Result.Size = new Size(0, 20);
            Result.TabIndex = 8;
            // 
            // Error
            // 
            Error.AutoSize = true;
            Error.Location = new Point(36, 391);
            Error.Name = "Error";
            Error.Size = new Size(0, 20);
            Error.TabIndex = 9;
            // 
            // ReadAllStudents
            // 
            ReadAllStudents.Location = new Point(88, 167);
            ReadAllStudents.Name = "ReadAllStudents";
            ReadAllStudents.Size = new Size(251, 29);
            ReadAllStudents.TabIndex = 10;
            ReadAllStudents.Text = "Read All Students";
            ReadAllStudents.UseVisualStyleBackColor = true;
            ReadAllStudents.Click += ReadAllStudents_Click;
            // 
            // GetStudentById
            // 
            GetStudentById.BackColor = Color.White;
            GetStudentById.Location = new Point(89, 216);
            GetStudentById.Name = "GetStudentById";
            GetStudentById.Size = new Size(135, 29);
            GetStudentById.TabIndex = 11;
            GetStudentById.Text = "Get Student";
            GetStudentById.UseVisualStyleBackColor = false;
            GetStudentById.Click += GetStudentById_Click;
            // 
            // StudentId
            // 
            StudentId.Location = new Point(230, 216);
            StudentId.Name = "StudentId";
            StudentId.Size = new Size(82, 27);
            StudentId.TabIndex = 12;
            // 
            // UpdateStudent
            // 
            UpdateStudent.Location = new Point(88, 264);
            UpdateStudent.Name = "UpdateStudent";
            UpdateStudent.Size = new Size(134, 29);
            UpdateStudent.TabIndex = 13;
            UpdateStudent.Text = "Update Student";
            UpdateStudent.UseVisualStyleBackColor = true;
            UpdateStudent.Click += UpdateStudent_Click;
            // 
            // StudentsGrid
            // 
            StudentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentsGrid.Location = new Point(456, 12);
            StudentsGrid.Name = "StudentsGrid";
            StudentsGrid.RowHeadersWidth = 51;
            StudentsGrid.Size = new Size(545, 572);
            StudentsGrid.TabIndex = 14;
            // 
            // StudentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 232, 175);
            ClientSize = new Size(1005, 588);
            Controls.Add(StudentsGrid);
            Controls.Add(UpdateStudent);
            Controls.Add(StudentId);
            Controls.Add(GetStudentById);
            Controls.Add(ReadAllStudents);
            Controls.Add(Error);
            Controls.Add(Result);
            Controls.Add(Clear);
            Controls.Add(label3);
            Controls.Add(StudentMobile);
            Controls.Add(label2);
            Controls.Add(StudentAge);
            Controls.Add(label1);
            Controls.Add(StudentName);
            Controls.Add(Save);
            Name = "StudentsForm";
            Text = "Students";
            Load += StudentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)StudentId).EndInit();
            ((System.ComponentModel.ISupportInitialize)StudentsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Save;
        private TextBox StudentName;
        private Label label1;
        private Label label2;
        private TextBox StudentAge;
        private Label label3;
        private TextBox StudentMobile;
        private Button Clear;
        private Label Result;
        private Label Error;
        private Button ReadAllStudents;
        private Button GetStudentById;
        private NumericUpDown StudentId;
        private Button UpdateStudent;
        private DataGridView StudentsGrid;
    }
}
