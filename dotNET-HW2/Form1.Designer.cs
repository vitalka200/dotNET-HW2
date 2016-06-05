using System.Globalization;
using System.Threading;

namespace dotNET_HW2
{
    partial class Form1
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
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDialog = new System.Windows.Forms.Button();
            this.buttonDeleteStud = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(62, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(456, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonDialog
            // 
            this.buttonDialog.Location = new System.Drawing.Point(62, 27);
            this.buttonDialog.Name = "buttonDialog";
            this.buttonDialog.Size = new System.Drawing.Size(85, 47);
            this.buttonDialog.TabIndex = 1;
            this.buttonDialog.Text = "Dialog";
            this.buttonDialog.UseVisualStyleBackColor = true;
            this.buttonDialog.Click += new System.EventHandler(this.buttonDialog_Click);
            // 
            // buttonDeleteStud
            // 
            this.buttonDeleteStud.Location = new System.Drawing.Point(62, 92);
            this.buttonDeleteStud.Name = "buttonDeleteStud";
            this.buttonDeleteStud.Size = new System.Drawing.Size(85, 46);
            this.buttonDeleteStud.TabIndex = 2;
            this.buttonDeleteStud.Text = "DeleteStudent";
            this.buttonDeleteStud.UseVisualStyleBackColor = true;
            this.buttonDeleteStud.Click += new System.EventHandler(this.buttonDeleteStud_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 420);
            this.Controls.Add(this.buttonDeleteStud);
            this.Controls.Add(this.buttonDialog);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDialog;
        private System.Windows.Forms.Button buttonDeleteStud;
    }
}

