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
        private static string initialAssemblyFile = "";

        public static string InitialAssemblyFile
        {
            get { return initialAssemblyFile; }
            set { initialAssemblyFile = value; }
        }

        #region Construtores e Inicializadores

        public FormPrincipal(string inputAssembly)
        {
            InitializeComponent();

            InitialAssemblyFile = inputAssembly;
        }

        #endregion

        #region Methods

        private void initialize()
        {
            if (!String.IsNullOrWhiteSpace(InitialAssemblyFile))
            {
                this.textBoxAssemblySelecionado.Text = InitialAssemblyFile;
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
            if (this.textBoxAssemblySelecionado.Text.Trim().Length > 0)
            {
                string fileName = this.textBoxAssemblySelecionado.Text.Trim();

                if (File.Exists(fileName))
                {
                    InitialAssemblyFile = fileName;

                    this.assemblyDetailsPrincipal.SetAssembly(InitialAssemblyFile);
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
