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

        private AssemblyDiscoveryService discoveryService = null;

        #endregion

        #region Construtores e Inicializadores

        public AssemblyDetails()
        {
            InitializeComponent();

            discoveryService = new AssemblyDiscoveryService();
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

            this.obterAssemblyDetail();

            this.obterReferencedAssemblies(this.checkBoxRecursiveView.Checked);
        }

        private void copySelectedAssembliesTo(string destPath)
        {
            if (Directory.Exists(destPath))
            {
                foreach (DataGridViewCell itemCell in dataGridViewReferencedAssemblies.SelectedCells)
                {
                    DataGridViewRow rowGrid = dataGridViewReferencedAssemblies.Rows[itemCell.RowIndex];

                    var objAssembly = (rowGrid.Cells["AssemblyObject"].Value as AssemblyTO);

                    if (objAssembly != null)
                    {
                        File.Copy(objAssembly.Location, Path.Combine(destPath, Path.GetFileName(objAssembly.Location)), true);
                    }
                }
            }
        }

        public void SetAssembly(string assemblyPath)
        {
            discoveryService.LoadAssembly(assemblyPath);

            this.refreshDetails();
        }

        #region Dados Assembly

        private void obterAssemblyDetail()
        {
            DataRow row = this.dataTableAssemblyDetail.NewRow();

            var assemblyDetailed = discoveryService.GetAssemblyDetail();

            row["AssemblyName"] = assemblyDetailed.Name;
            row["AssemblyFullName"] = assemblyDetailed.FullName;
            row["AssemblyVersion"] = assemblyDetailed.AssemblyVersion.ToString();
            row["AssemblyRuntimeVersion"] = assemblyDetailed.RuntimeVersion;

            this.dataTableAssemblyDetail.Rows.Add(row);
        }

        private void obterReferencedAssemblies(bool recursive)
        {
            var assemblyDetailed = discoveryService.GetAssemblyDetail(true, recursive);

            List<string> addedAssemblies = new List<string>();

            foreach (var assemblyDto in assemblyDetailed.ReferencedAssemblies)
            {
                if (addedAssemblies.Contains(assemblyDto.FullName)) continue;

                DataRow row = this.dataTableReferencedAssemblies.NewRow();

                row["AssemblyName"] = assemblyDto.Name;
                row["AssemblyVersion"] = assemblyDto.AssemblyVersion.ToString();
                row["AssemblyRuntimeVersion"] = assemblyDto.GetType().Assembly.ImageRuntimeVersion;
                row["AssemblyVersionCompatibility"] = assemblyDto.VersionCompatibility.ToString();
                row["AssemblyFullName"] = assemblyDto.FullName;
                row["ParentAssemblyObject"] = assemblyDetailed;
                row["AssemblyObject"] = assemblyDto;
                row["hasInGAC"] = assemblyDto.HasInGAC;
                row["loadError"] = assemblyDto.LoadError;
                row["loadErrorDescription"] = assemblyDto.LoadErrorDescription;

                if (!addedAssemblies.Contains(assemblyDto.FullName))
                {
                    addedAssemblies.Add(assemblyDto.FullName);
                }

                this.dataTableReferencedAssemblies.Rows.Add(row);
            }

            this.dataGridViewReferencedAssemblies.Sort(this.assemblyNameDataGridViewTextBoxColumn, ListSortDirection.Ascending);
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
                            FormAssemblyDetail.Show(row["AssemblyObject"] as AssemblyTO);
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

            this.obterReferencedAssemblies(this.checkBoxRecursiveView.Checked);

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
                        FormAssemblyDetail.Show(row["ParentAssemblyObject"] as AssemblyTO);
                    }
                }
            }
        }

        #endregion
    }
}
