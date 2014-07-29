using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace AssemblyDiscovery
{
    public partial class FormPrincipal : Form
    {
        private string strInitialFile = "";

        #region Construtores e Inicializadores

        public FormPrincipal(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    this.strInitialFile = args[0]; 
                }
            }
        }

        #endregion

        #region Methods

        private void initialize()
        {
            if (this.strInitialFile.Length != 0)
            {
                this.textBoxAssemblySelecionado.Text = this.strInitialFile;
            }
        }

        #endregion Methods

        #region Eventos

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            this.initialize();
        }

        private void textBoxAssemblySelecionado_TextChanged(object sender, EventArgs e)
        {
            this.assemblyDetailsPrincipal.SetAssembly(null);

            if (this.textBoxAssemblySelecionado.Text.Trim().Length > 0)
            {
                string fileName = this.textBoxAssemblySelecionado.Text.Trim();

                if (File.Exists(fileName))
                {
                    Assembly asmbly = null;

                    try
                    {
                        asmbly = Assembly.LoadFrom(fileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("O arquivo selecionado não é um arquivo Assembly válido.");

                        this.textBoxAssemblySelecionado.Text = String.Empty;
                    }

                    if (asmbly != null)
                    {
                        this.assemblyDetailsPrincipal.SetAssembly(asmbly);
                    }
                }
            }
        }

        private void buttonProcurarAssembly_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxAssemblySelecionado.Text = this.openFileDialog1.FileName;
            }
        }

        private void panelTop_DragOver(object sender, DragEventArgs e)
        {
            string[] commingFormats = e.Data.GetFormats(true);

            int countExists =
                (from a in commingFormats
                 where a.Trim().ToLower().Equals(DataFormats.FileDrop.Trim().ToLower())
                 select a).Count();

            if (countExists > 0)
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void panelTop_DragDrop(object sender, DragEventArgs e)
        {
            string[] commingFormats = e.Data.GetFormats(true);

            int countExists =
                (from a in commingFormats
                 where a.Trim().ToLower().Equals(DataFormats.FileDrop.Trim().ToLower())
                 select a).Count();

            if (countExists > 0)
            {
                e.Effect = DragDropEffects.Link;

                if (e.Data.GetData(DataFormats.FileDrop) is string[])
                {
                    string[] strFileNames = (string[])e.Data.GetData(DataFormats.FileDrop);

                    if (strFileNames.Length > 0)
                    {
                        this.textBoxAssemblySelecionado.Text = strFileNames[0];
                    }
                }
            }
        }

        #endregion
    }
}
