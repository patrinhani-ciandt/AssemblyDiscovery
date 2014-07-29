namespace AssemblyDiscovery
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonProcurarAssembly = new System.Windows.Forms.Button();
            this.textBoxAssemblySelecionado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFill = new System.Windows.Forms.Panel();
            this.assemblyDetailsPrincipal = new AssemblyDiscovery.AssemblyDetails();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelTop.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.AllowDrop = true;
            this.panelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelTop.Controls.Add(this.buttonProcurarAssembly);
            this.panelTop.Controls.Add(this.textBoxAssemblySelecionado);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(727, 52);
            this.panelTop.TabIndex = 0;
            this.panelTop.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelTop_DragDrop);
            this.panelTop.DragOver += new System.Windows.Forms.DragEventHandler(this.panelTop_DragOver);
            // 
            // buttonProcurarAssembly
            // 
            this.buttonProcurarAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcurarAssembly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProcurarAssembly.Location = new System.Drawing.Point(694, 24);
            this.buttonProcurarAssembly.Name = "buttonProcurarAssembly";
            this.buttonProcurarAssembly.Size = new System.Drawing.Size(26, 21);
            this.buttonProcurarAssembly.TabIndex = 2;
            this.buttonProcurarAssembly.Text = "...";
            this.buttonProcurarAssembly.UseVisualStyleBackColor = true;
            this.buttonProcurarAssembly.Click += new System.EventHandler(this.buttonProcurarAssembly_Click);
            // 
            // textBoxAssemblySelecionado
            // 
            this.textBoxAssemblySelecionado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAssemblySelecionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAssemblySelecionado.Location = new System.Drawing.Point(3, 25);
            this.textBoxAssemblySelecionado.Name = "textBoxAssemblySelecionado";
            this.textBoxAssemblySelecionado.Size = new System.Drawing.Size(685, 20);
            this.textBoxAssemblySelecionado.TabIndex = 1;
            this.textBoxAssemblySelecionado.TextChanged += new System.EventHandler(this.textBoxAssemblySelecionado_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assembly";
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.assemblyDetailsPrincipal);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 52);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(727, 522);
            this.panelFill.TabIndex = 1;
            // 
            // assemblyDetailsPrincipal
            // 
            this.assemblyDetailsPrincipal.BackColor = System.Drawing.Color.LightBlue;
            this.assemblyDetailsPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyDetailsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.assemblyDetailsPrincipal.Name = "assemblyDetailsPrincipal";
            this.assemblyDetailsPrincipal.Size = new System.Drawing.Size(727, 522);
            this.assemblyDetailsPrincipal.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 574);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Assembly Discovery";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFill;
        private AssemblyDiscovery.AssemblyDetails assemblyDetailsPrincipal;
        private System.Windows.Forms.Button buttonProcurarAssembly;
        private System.Windows.Forms.TextBox textBoxAssemblySelecionado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

