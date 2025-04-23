namespace GetCourseFromTDSYnnex
{
    partial class Form1
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
            button1 = new Button();
            dataGridViewCourses = new DataGridView();
            rtbDescription = new RichTextBox();
            cmbLanguage = new ComboBox();
            btnExportToEdudex = new Button();
            btnPostToEdudex = new Button();
            txtResponse = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(2, 0);
            button1.Name = "button1";
            button1.Size = new Size(113, 25);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridViewCourses
            // 
            dataGridViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCourses.Location = new Point(2, 31);
            dataGridViewCourses.Name = "dataGridViewCourses";
            dataGridViewCourses.Size = new Size(691, 434);
            dataGridViewCourses.TabIndex = 1;
            dataGridViewCourses.SelectionChanged += dataGridViewCourses_SelectionChanged_1;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(2, 500);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(788, 162);
            rtbDescription.TabIndex = 2;
            rtbDescription.Text = "";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(2, 471);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // btnExportToEdudex
            // 
            btnExportToEdudex.Location = new Point(765, 53);
            btnExportToEdudex.Name = "btnExportToEdudex";
            btnExportToEdudex.Size = new Size(145, 23);
            btnExportToEdudex.TabIndex = 4;
            btnExportToEdudex.Text = "Save output to file";
            btnExportToEdudex.UseVisualStyleBackColor = true;
            btnExportToEdudex.Click += btnExportToEdudex_Click;
            // 
            // btnPostToEdudex
            // 
            btnPostToEdudex.Location = new Point(765, 82);
            btnPostToEdudex.Name = "btnPostToEdudex";
            btnPostToEdudex.Size = new Size(145, 22);
            btnPostToEdudex.TabIndex = 5;
            btnPostToEdudex.Text = "Post To Edudex";
            btnPostToEdudex.UseVisualStyleBackColor = true;
            btnPostToEdudex.Click += btnPostToEdudex_Click;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(765, 110);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(181, 211);
            txtResponse.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 674);
            Controls.Add(txtResponse);
            Controls.Add(btnPostToEdudex);
            Controls.Add(btnExportToEdudex);
            Controls.Add(cmbLanguage);
            Controls.Add(rtbDescription);
            Controls.Add(dataGridViewCourses);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridViewCourses;
        private RichTextBox rtbDescription;
        private ComboBox cmbLanguage;
        private Button btnExportToEdudex;
        private Button btnPostToEdudex;
        private TextBox txtResponse;
    }
}
