namespace GetCourseFromTDSYnnex
{
    partial class Form2
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
            btnSubmitCourse = new Button();
            txtResponse = new TextBox();
            SuspendLayout();
            // 
            // btnSubmitCourse
            // 
            btnSubmitCourse.Location = new Point(12, 12);
            btnSubmitCourse.Name = "btnSubmitCourse";
            btnSubmitCourse.Size = new Size(118, 23);
            btnSubmitCourse.TabIndex = 0;
            btnSubmitCourse.Text = "Submit Course";
            btnSubmitCourse.UseVisualStyleBackColor = true;
            btnSubmitCourse.Click += btnSubmitCourse_Click;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(12, 41);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(272, 151);
            txtResponse.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtResponse);
            Controls.Add(btnSubmitCourse);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmitCourse;
        private TextBox txtResponse;
    }
}