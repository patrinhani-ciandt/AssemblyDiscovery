namespace AssemblyDiscovery
{
    partial class AssemblyDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabPageReferencedAssemblies = new System.Windows.Forms.TabPage();
            this.dataGridViewReferencedAssemblies = new System.Windows.Forms.DataGridView();
            this.assemblyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyRuntimeVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyVersionCompatibility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadError = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasInGAC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStripGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAssemblyFilesToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtsAssemblieData = new System.Data.DataSet();
            this.dataTableReferencedAssemblies = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataTableAssemblyDetail = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.panelTop2 = new System.Windows.Forms.Panel();
            this.checkBoxRecursiveView = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRuntimeVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialogPrincipal = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showParentAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.tabControlPrincipal.SuspendLayout();
            this.tabPageReferencedAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferencedAssemblies)).BeginInit();
            this.contextMenuStripGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtsAssemblieData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableReferencedAssemblies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAssemblyDetail)).BeginInit();
            this.panelTop2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabPageReferencedAssemblies);
            this.tabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrincipal.Location = new System.Drawing.Point(0, 72);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(674, 467);
            this.tabControlPrincipal.TabIndex = 3;
            // 
            // tabPageReferencedAssemblies
            // 
            this.tabPageReferencedAssemblies.Controls.Add(this.dataGridViewReferencedAssemblies);
            this.tabPageReferencedAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageReferencedAssemblies.Name = "tabPageReferencedAssemblies";
            this.tabPageReferencedAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReferencedAssemblies.Size = new System.Drawing.Size(666, 441);
            this.tabPageReferencedAssemblies.TabIndex = 0;
            this.tabPageReferencedAssemblies.Text = "Referenced Assemblies";
            this.tabPageReferencedAssemblies.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReferencedAssemblies
            // 
            this.dataGridViewReferencedAssemblies.AllowUserToAddRows = false;
            this.dataGridViewReferencedAssemblies.AllowUserToDeleteRows = false;
            this.dataGridViewReferencedAssemblies.AllowUserToResizeRows = false;
            this.dataGridViewReferencedAssemblies.AutoGenerateColumns = false;
            this.dataGridViewReferencedAssemblies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewReferencedAssemblies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assemblyNameDataGridViewTextBoxColumn,
            this.AssemblyVersion,
            this.AssemblyRuntimeVersion,
            this.AssemblyVersionCompatibility,
            this.AssemblyFullName,
            this.loadError,
            this.hasInGAC,
            this.AssemblyObject});
            this.dataGridViewReferencedAssemblies.ContextMenuStrip = this.contextMenuStripGridView;
            this.dataGridViewReferencedAssemblies.DataMember = "ReferencedAssemblies";
            this.dataGridViewReferencedAssemblies.DataSource = this.dtsAssemblieData;
            this.dataGridViewReferencedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReferencedAssemblies.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewReferencedAssemblies.Name = "dataGridViewReferencedAssemblies";
            this.dataGridViewReferencedAssemblies.ReadOnly = true;
            this.dataGridViewReferencedAssemblies.RowHeadersVisible = false;
            this.dataGridViewReferencedAssemblies.Size = new System.Drawing.Size(660, 435);
            this.dataGridViewReferencedAssemblies.TabIndex = 0;
            this.dataGridViewReferencedAssemblies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReferencedAssemblies_CellDoubleClick);
            this.dataGridViewReferencedAssemblies.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewReferencedAssemblies_CellPainting);
            // 
            // assemblyNameDataGridViewTextBoxColumn
            // 
            this.assemblyNameDataGridViewTextBoxColumn.DataPropertyName = "AssemblyName";
            this.assemblyNameDataGridViewTextBoxColumn.HeaderText = "Assembly Name";
            this.assemblyNameDataGridViewTextBoxColumn.Name = "assemblyNameDataGridViewTextBoxColumn";
            this.assemblyNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assemblyNameDataGridViewTextBoxColumn.Width = 107;
            // 
            // AssemblyVersion
            // 
            this.AssemblyVersion.DataPropertyName = "AssemblyVersion";
            this.AssemblyVersion.HeaderText = "Assembly Version";
            this.AssemblyVersion.Name = "AssemblyVersion";
            this.AssemblyVersion.ReadOnly = true;
            this.AssemblyVersion.Width = 114;
            // 
            // AssemblyRuntimeVersion
            // 
            this.AssemblyRuntimeVersion.DataPropertyName = "AssemblyRuntimeVersion";
            this.AssemblyRuntimeVersion.HeaderText = "Runtime Version";
            this.AssemblyRuntimeVersion.Name = "AssemblyRuntimeVersion";
            this.AssemblyRuntimeVersion.ReadOnly = true;
            this.AssemblyRuntimeVersion.Width = 109;
            // 
            // AssemblyVersionCompatibility
            // 
            this.AssemblyVersionCompatibility.DataPropertyName = "AssemblyVersionCompatibility";
            this.AssemblyVersionCompatibility.HeaderText = "Assembly Version Compatibility";
            this.AssemblyVersionCompatibility.Name = "AssemblyVersionCompatibility";
            this.AssemblyVersionCompatibility.ReadOnly = true;
            this.AssemblyVersionCompatibility.Width = 175;
            // 
            // AssemblyFullName
            // 
            this.AssemblyFullName.DataPropertyName = "AssemblyFullName";
            this.AssemblyFullName.HeaderText = "Assembly Full Name";
            this.AssemblyFullName.Name = "AssemblyFullName";
            this.AssemblyFullName.ReadOnly = true;
            this.AssemblyFullName.Width = 126;
            // 
            // loadError
            // 
            this.loadError.DataPropertyName = "loadError";
            this.loadError.HeaderText = "loadError";
            this.loadError.Name = "loadError";
            this.loadError.ReadOnly = true;
            this.loadError.Visible = false;
            this.loadError.Width = 55;
            // 
            // hasInGAC
            // 
            this.hasInGAC.DataPropertyName = "hasInGAC";
            this.hasInGAC.HeaderText = "hasInGAC";
            this.hasInGAC.Name = "hasInGAC";
            this.hasInGAC.ReadOnly = true;
            this.hasInGAC.Visible = false;
            this.hasInGAC.Width = 61;
            // 
            // contextMenuStripGridView
            // 
            this.contextMenuStripGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAssemblyFilesToToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showParentAssemblyToolStripMenuItem});
            this.contextMenuStripGridView.Name = "contextMenuStripGridView";
            this.contextMenuStripGridView.Size = new System.Drawing.Size(209, 54);
            // 
            // copyAssemblyFilesToToolStripMenuItem
            // 
            this.copyAssemblyFilesToToolStripMenuItem.Name = "copyAssemblyFilesToToolStripMenuItem";
            this.copyAssemblyFilesToToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copyAssemblyFilesToToolStripMenuItem.Text = "Copy Assembly Files To...";
            this.copyAssemblyFilesToToolStripMenuItem.Click += new System.EventHandler(this.copyAssemblyFilesToToolStripMenuItem_Click);
            // 
            // dtsAssemblieData
            // 
            this.dtsAssemblieData.DataSetName = "NewDataSet";
            this.dtsAssemblieData.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableReferencedAssemblies,
            this.dataTableAssemblyDetail});
            // 
            // dataTableReferencedAssemblies
            // 
            this.dataTableReferencedAssemblies.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn8,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14});
            this.dataTableReferencedAssemblies.TableName = "ReferencedAssemblies";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "AssemblyName";
            this.dataColumn1.ColumnName = "AssemblyName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "AssemblyFullName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "AssemblyVersion";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "AssemblyVersionCompatibility";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "AssemblyRuntimeVersion";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "hasInGAC";
            this.dataColumn11.DataType = typeof(bool);
            this.dataColumn11.DefaultValue = false;
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "loadError";
            this.dataColumn12.DataType = typeof(bool);
            this.dataColumn12.DefaultValue = false;
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "loadErrorDescription";
            // 
            // dataTableAssemblyDetail
            // 
            this.dataTableAssemblyDetail.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn9});
            this.dataTableAssemblyDetail.TableName = "AssemblyDetail";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "AssemblyName";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "AssemblyFullName";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "AssemblyVersion";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "AssemblyRuntimeVersion";
            // 
            // panelTop2
            // 
            this.panelTop2.Controls.Add(this.checkBoxRecursiveView);
            this.panelTop2.Controls.Add(this.label4);
            this.panelTop2.Controls.Add(this.textBoxRuntimeVersion);
            this.panelTop2.Controls.Add(this.label3);
            this.panelTop2.Controls.Add(this.label2);
            this.panelTop2.Controls.Add(this.label1);
            this.panelTop2.Controls.Add(this.textBoxVersion);
            this.panelTop2.Controls.Add(this.textBoxFullName);
            this.panelTop2.Controls.Add(this.textBoxName);
            this.panelTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop2.Location = new System.Drawing.Point(0, 0);
            this.panelTop2.Name = "panelTop2";
            this.panelTop2.Size = new System.Drawing.Size(674, 72);
            this.panelTop2.TabIndex = 4;
            // 
            // checkBoxRecursiveView
            // 
            this.checkBoxRecursiveView.AutoSize = true;
            this.checkBoxRecursiveView.Location = new System.Drawing.Point(7, 52);
            this.checkBoxRecursiveView.Name = "checkBoxRecursiveView";
            this.checkBoxRecursiveView.Size = new System.Drawing.Size(100, 17);
            this.checkBoxRecursiveView.TabIndex = 9;
            this.checkBoxRecursiveView.Text = "Recursive View";
            this.checkBoxRecursiveView.UseVisualStyleBackColor = true;
            this.checkBoxRecursiveView.CheckedChanged += new System.EventHandler(this.checkBoxRecursiveView_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Runtime Version";
            // 
            // textBoxRuntimeVersion
            // 
            this.textBoxRuntimeVersion.BackColor = System.Drawing.Color.White;
            this.textBoxRuntimeVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRuntimeVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dtsAssemblieData, "AssemblyDetail.AssemblyRuntimeVersion", true));
            this.textBoxRuntimeVersion.Location = new System.Drawing.Point(508, 26);
            this.textBoxRuntimeVersion.Name = "textBoxRuntimeVersion";
            this.textBoxRuntimeVersion.ReadOnly = true;
            this.textBoxRuntimeVersion.Size = new System.Drawing.Size(110, 20);
            this.textBoxRuntimeVersion.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.BackColor = System.Drawing.Color.White;
            this.textBoxVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dtsAssemblieData, "AssemblyDetail.AssemblyVersion", true));
            this.textBoxVersion.Location = new System.Drawing.Point(409, 26);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.ReadOnly = true;
            this.textBoxVersion.Size = new System.Drawing.Size(93, 20);
            this.textBoxVersion.TabIndex = 2;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.BackColor = System.Drawing.Color.White;
            this.textBoxFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dtsAssemblieData, "AssemblyDetail.AssemblyFullName", true));
            this.textBoxFullName.Location = new System.Drawing.Point(189, 26);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.ReadOnly = true;
            this.textBoxFullName.Size = new System.Drawing.Size(214, 20);
            this.textBoxFullName.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.White;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dtsAssemblieData, "AssemblyDetail.AssemblyName", true));
            this.textBoxName.Location = new System.Drawing.Point(7, 26);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(176, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 539);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 33);
            this.panel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(110, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Assembly Not Found";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(215)))), ((int)(((byte)(254)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "GAC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AssemblyObject";
            this.dataGridViewTextBoxColumn1.HeaderText = "AssemblyObject";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 107;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AssemblyObject";
            this.dataGridViewTextBoxColumn2.HeaderText = "AssemblyObject";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 107;
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "ParentAssemblyObject";
            this.dataColumn14.DataType = typeof(object);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // showParentAssemblyToolStripMenuItem
            // 
            this.showParentAssemblyToolStripMenuItem.Name = "showParentAssemblyToolStripMenuItem";
            this.showParentAssemblyToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showParentAssemblyToolStripMenuItem.Text = "Show Parent Assembly";
            this.showParentAssemblyToolStripMenuItem.Click += new System.EventHandler(this.showParentAssemblyToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AssemblyObject";
            this.dataGridViewTextBoxColumn3.HeaderText = "AssemblyObject";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 107;
            // 
            // AssemblyObject
            // 
            this.AssemblyObject.DataPropertyName = "AssemblyObject";
            this.AssemblyObject.HeaderText = "AssemblyObject";
            this.AssemblyObject.Name = "AssemblyObject";
            this.AssemblyObject.ReadOnly = true;
            this.AssemblyObject.Visible = false;
            this.AssemblyObject.Width = 107;
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "AssemblyObject";
            this.dataColumn10.DataType = typeof(object);
            // 
            // AssemblyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPrincipal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop2);
            this.Name = "AssemblyDetails";
            this.Size = new System.Drawing.Size(674, 572);
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabPageReferencedAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferencedAssemblies)).EndInit();
            this.contextMenuStripGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtsAssemblieData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableReferencedAssemblies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAssemblyDetail)).EndInit();
            this.panelTop2.ResumeLayout(false);
            this.panelTop2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabPageReferencedAssemblies;
        private System.Windows.Forms.Panel panelTop2;
        private System.Data.DataSet dtsAssemblieData;
        private System.Data.DataTable dataTableReferencedAssemblies;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.DataGridView dataGridViewReferencedAssemblies;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable dataTableAssemblyDetail;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRuntimeVersion;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.CheckBox checkBoxRecursiveView;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn assemblyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyRuntimeVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyVersionCompatibility;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn loadError;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasInGAC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridView;
        private System.Windows.Forms.ToolStripMenuItem copyAssemblyFilesToToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showParentAssemblyToolStripMenuItem;
    }
}
