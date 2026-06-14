namespace Infoeduka_PraTim3
{
    partial class LecturerDashboardForm
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
            this.btnMyCourses = new System.Windows.Forms.Button();
            this.btnMyNotifications = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "          INFOEDUKA - PREDAVAČ       ";
            // 
            // btnMyCourses
            // 
            this.btnMyCourses.Location = new System.Drawing.Point(94, 146);
            this.btnMyCourses.Name = "btnMyCourses";
            this.btnMyCourses.Size = new System.Drawing.Size(273, 45);
            this.btnMyCourses.TabIndex = 1;
            this.btnMyCourses.Text = "Moji kolegiji";
            this.btnMyCourses.UseVisualStyleBackColor = true;
            // 
            // btnMyNotifications
            // 
            this.btnMyNotifications.Location = new System.Drawing.Point(497, 146);
            this.btnMyNotifications.Name = "btnMyNotifications";
            this.btnMyNotifications.Size = new System.Drawing.Size(273, 45);
            this.btnMyNotifications.TabIndex = 2;
            this.btnMyNotifications.Text = "Moje obavijesti";
            this.btnMyNotifications.UseVisualStyleBackColor = true;
            this.btnMyNotifications.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(379, 399);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(153, 60);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Odjava";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // LecturerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 661);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyNotifications);
            this.Controls.Add(this.btnMyCourses);
            this.Controls.Add(this.label1);
            this.Name = "LecturerDashboardForm";
            this.Text = "LecturerDashboardForm";
            this.Load += new System.EventHandler(this.LecturerDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMyCourses;
        private System.Windows.Forms.Button btnMyNotifications;
        private System.Windows.Forms.Button btnLogout;
    }
}