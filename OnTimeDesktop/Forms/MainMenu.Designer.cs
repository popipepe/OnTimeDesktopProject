namespace OnTimeDesktop.Forms
{
    partial class MainMenu
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
            this.grbProject = new System.Windows.Forms.GroupBox();
            this.btnUpProj = new System.Windows.Forms.Button();
            this.grbProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbProject
            // 
            this.grbProject.Controls.Add(this.btnUpProj);
            this.grbProject.Location = new System.Drawing.Point(215, 187);
            this.grbProject.Name = "grbProject";
            this.grbProject.Size = new System.Drawing.Size(236, 169);
            this.grbProject.TabIndex = 0;
            this.grbProject.TabStop = false;
            this.grbProject.Text = "Project and Activities";
            // 
            // btnUpProj
            // 
            this.btnUpProj.Location = new System.Drawing.Point(25, 69);
            this.btnUpProj.Name = "btnUpProj";
            this.btnUpProj.Size = new System.Drawing.Size(81, 46);
            this.btnUpProj.TabIndex = 0;
            this.btnUpProj.Text = "Upload Project";
            this.btnUpProj.UseVisualStyleBackColor = true;
            this.btnUpProj.Click += new System.EventHandler(this.btnUpProj_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 368);
            this.Controls.Add(this.grbProject);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.grbProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProject;
        private System.Windows.Forms.Button btnUpProj;
    }
}