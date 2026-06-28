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
            this.label1.Location = new System.Drawing.Point(130, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "          INFOEDUKA - PREDAVAČ       ";
            // 
            // btnMyCourses
            // 
            this.btnMyCourses.Location = new System.Drawing.Point(47, 76);
            this.btnMyCourses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMyCourses.Name = "btnMyCourses";
            this.btnMyCourses.Size = new System.Drawing.Size(136, 23);
            this.btnMyCourses.TabIndex = 1;
            this.btnMyCourses.Text = "Moji kolegiji";
            this.btnMyCourses.UseVisualStyleBackColor = true;
            // 
            // btnMyNotifications
            // 
            this.btnMyNotifications.Location = new System.Drawing.Point(248, 76);
            this.btnMyNotifications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMyNotifications.Name = "btnMyNotifications";
            this.btnMyNotifications.Size = new System.Drawing.Size(136, 23);
            this.btnMyNotifications.TabIndex = 2;
            this.btnMyNotifications.Text = "Moje obavijesti";
            this.btnMyNotifications.UseVisualStyleBackColor = true;
            this.btnMyNotifications.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(190, 207);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(76, 31);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Odjava";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LecturerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 344);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyNotifications);
            this.Controls.Add(this.btnMyCourses);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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