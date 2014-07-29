namespace AssemblyDiscovery
{
    partial class FormAssemblyDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssemblyDetail));
            this.assemblyDetails1 = new AssemblyDiscovery.AssemblyDetails();
            this.SuspendLayout();
            // 
            // assemblyDetails1
            // 
            this.assemblyDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyDetails1.Location = new System.Drawing.Point(0, 0);
            this.assemblyDetails1.Name = "assemblyDetails1";
            this.assemblyDetails1.Size = new System.Drawing.Size(718, 648);
            this.assemblyDetails1.TabIndex = 0;
            // 
            // FormAssemblyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 648);
            this.Controls.Add(this.assemblyDetails1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAssemblyDetail";
            this.Text = "FormAssemblyDetail";
            this.Load += new System.EventHandler(this.FormAssemblyDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AssemblyDetails assemblyDetails1;
    }
}