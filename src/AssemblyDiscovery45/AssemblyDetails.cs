using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace AssemblyDiscovery
{
    public partial class AssemblyDetails : UserControl
    {
        #region Variáveis

        private Assembly assemblyDetailed = null;

        #endregion

        #region Construtores e Inicializadores

        public AssemblyDetails()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos

        private void clearDetails()
        {
            this.dtsAssemblieData.Clear();
            this.dtsAssemblieData.AcceptChanges();
        }

        private void refreshDetails()
        {
            this.clearDetails();

            if (this.assemblyDetailed != null)
            {
                this.obterAssemblyDetail();

                if (!this.checkBoxRecursiveView.Checked)
                {
                    this.obterReferencedAssemblies();
                }
                else
                {
                    this.obterReferencedAssembliesRecursive(null);

                    this.dataGridViewReferencedAssemblies.Sort(this.assemblyNameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
                }
            }
        }

        private void copySelectedAssembliesTo(string destPath)
        {
            if (Directory.Exists(destPath))
            {
                foreach (DataGridViewCell itemCell in dataGridViewReferencedAssemblies.SelectedCells)
                {
                    DataGridViewRow rowGrid = dataGridViewReferencedAssemblies.Rows[itemCell.RowIndex];

                    object objAssembly = rowGrid.Cells["AssemblyObject"].Value;

                    if (objAssembly is Assembly)
                    {
                        File.Copy((objAssembly as Assembly).Location, Path.Combine(destPath, Path.GetFileName((objAssembly as Assembly).Location)), true);
                    }
                }
            }
        }

        public void SetAssembly(Assembly assembly)
        {
            this.assemblyDetailed = assembly;

            this.refreshDetails();
        }

        #region Dados Assembly

        private void obterAssemblyDetail()
        {
            DataRow row = this.dataTableAssemblyDetail.NewRow();

            row["AssemblyName"] = this.assemblyDetailed.GetName().Name;
            row["AssemblyFullName"] = this.assemblyDetailed.GetName().FullName;
            row["AssemblyVersion"] = this.assemblyDetailed.GetName().Version.ToString();
            row["AssemblyRuntimeVersion"] = this.assemblyDetailed.ImageRuntimeVersion;

            this.dataTableAssemblyDetail.Rows.Add(row);
        }

        private void obterReferencedAssemblies()
        {
            foreach (AssemblyName assName in this.assemblyDetailed.GetReferencedAssemblies())
            {
                DataRow row = this.dataTableReferencedAssemblies.NewRow();

                row["AssemblyName"] = assName.Name;
                row["AssemblyVersion"] = assName.Version.ToString();
                row["AssemblyRuntimeVersion"] = assName.GetType().Assembly.ImageRuntimeVersion;
                row["AssemblyVersionCompatibility"] = assName.VersionCompatibility.ToString();
                row["AssemblyFullName"] = assName.FullName;
                row["ParentAssemblyObject"] = this.assemblyDetailed;

                try
                {
                    Assembly rowAssembly = Assembly.Load(assName);

                    row["AssemblyObject"] = rowAssembly;
                    row["hasInGAC"] = rowAssembly.GlobalAssemblyCache;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                        ex = ex.InnerException;

                    row["loadError"] = true;
                    row["loadErrorDescription"] = ex.Message;
                }

                this.dataTableReferencedAssemblies.Rows.Add(row);
            }

            this.dataGridViewReferencedAssemblies.Sort(this.assemblyNameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
        }

        private void obterReferencedAssembliesRecursive(AssemblyName assName)
        {
            if (assName != null)
            {
                Assembly actualAssembly = null;

                try
                {
                    actualAssembly = Assembly.Load(assName);
                }
                catch (Exception) { }

                if (actualAssembly != null)
                {
                    foreach (AssemblyName childAssName in actualAssembly.GetReferencedAssemblies())
                    {
                        int existsAdded = 0;

                        existsAdded =
                            (from a in this.dataTableReferencedAssemblies.AsEnumerable()
                             where a.Field<String>("AssemblyFullName").ToLower().Trim().Equals(childAssName.FullName.ToLower().Trim())
                             select a).Count();

                        if (existsAdded <= 0)
                        {
                            DataRow row = this.dataTableReferencedAssemblies.NewRow();

                            row["AssemblyName"] = childAssName.Name;
                            row["AssemblyVersion"] = childAssName.Version.ToString();
                            row["AssemblyRuntimeVersion"] = childAssName.GetType().Assembly.ImageRuntimeVersion;
                            row["AssemblyVersionCompatibility"] = childAssName.VersionCompatibility.ToString();
                            row["AssemblyFullName"] = childAssName.FullName;
                            row["ParentAssemblyObject"] = actualAssembly;

                            try
                            {
                                Assembly rowAssembly = Assembly.Load(childAssName);

                                row["AssemblyObject"] = rowAssembly;
                                row["hasInGAC"] = rowAssembly.GlobalAssemblyCache;
                            }
                            catch (Exception ex)
                            {
                                while (ex.InnerException != null)
                                    ex = ex.InnerException;

                                row["loadError"] = true;
                                row["loadErrorDescription"] = ex.Message;
                            }

                            this.dataTableReferencedAssemblies.Rows.Add(row);

                            obterReferencedAssembliesRecursive(childAssName);
                        }
                    }
                }
            }
            else
            {
                foreach (AssemblyName childAssName in this.assemblyDetailed.GetReferencedAssemblies())
                {
                    int existsAdded = 0;

                    existsAdded =
                        (from a in this.dataTableReferencedAssemblies.AsEnumerable()
                         where a.Field<String>("AssemblyFullName").ToLower().Trim().Equals(childAssName.FullName.ToLower().Trim())
                         select a).Count();

                    if (existsAdded <= 0)
                    {
                        DataRow row = this.dataTableReferencedAssemblies.NewRow();

                        row["AssemblyName"] = childAssName.Name;
                        row["AssemblyVersion"] = childAssName.Version.ToString();
                        row["AssemblyRuntimeVersion"] = childAssName.GetType().Assembly.ImageRuntimeVersion;
                        row["AssemblyVersionCompatibility"] = childAssName.VersionCompatibility.ToString();
                        row["AssemblyFullName"] = childAssName.FullName;

                        try
                        {
                            Assembly rowAssembly = Assembly.Load(childAssName);

                            row["AssemblyObject"] = rowAssembly;
                            row["hasInGAC"] = rowAssembly.GlobalAssemblyCache;
                        }
                        catch (Exception ex)
                        {
                            while (ex.InnerException != null)
                                ex = ex.InnerException;

                            row["loadError"] = true;
                            row["loadErrorDescription"] = ex.Message;
                        }

                        this.dataTableReferencedAssemblies.Rows.Add(row);

                        obterReferencedAssembliesRecursive(childAssName);
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Eventos

        private void dataGridViewReferencedAssemblies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.dataGridViewReferencedAssemblies.Rows[e.RowIndex].DataBoundItem is DataRowView)
                {

                    DataRow row = (this.dataGridViewReferencedAssemblies.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

                    if (row != null)
                    {
                        if (row["AssemblyObject"] != DBNull.Value)
                        {
                            FormAssemblyDetail.Show((Assembly)row["AssemblyObject"]);
                        }
                    }
                }
            }
        }

        private void checkBoxRecursiveView_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;

            this.dataTableReferencedAssemblies.Clear();
            this.dataTableReferencedAssemblies.AcceptChanges();

            if (!this.checkBoxRecursiveView.Checked)
            {
                this.obterReferencedAssemblies();
            }
            else
            {
                this.obterReferencedAssembliesRecursive(null);

                this.dataGridViewReferencedAssemblies.Sort(this.assemblyNameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
            }

            this.dataTableReferencedAssemblies.AcceptChanges();

            this.Enabled = true;
        }

        private void copyAssemblyFilesToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPrincipal.SelectedPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            if (this.folderBrowserDialogPrincipal.ShowDialog() == DialogResult.OK)
            {
                this.copySelectedAssembliesTo(this.folderBrowserDialogPrincipal.SelectedPath);
            }
        }

        private void dataGridViewReferencedAssemblies_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((bool)dataGridViewReferencedAssemblies.Rows[e.RowIndex].Cells["loadError"].Value)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(255, 164, 0, 0);
                }

                if ((bool)dataGridViewReferencedAssemblies.Rows[e.RowIndex].Cells["hasInGAC"].Value)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 201, 215, 254);
                }
            }
        }

        private void showParentAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewReferencedAssemblies.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridViewReferencedAssemblies.SelectedCells[0].RowIndex;

                DataRow row = (this.dataGridViewReferencedAssemblies.Rows[rowIndex].DataBoundItem as DataRowView).Row;

                if (row != null)
                {
                    if (row["ParentAssemblyObject"] != DBNull.Value)
                    {
                        FormAssemblyDetail.Show((Assembly)row["ParentAssemblyObject"]);
                    }
                }
            }
        }

        #endregion
    }
}
