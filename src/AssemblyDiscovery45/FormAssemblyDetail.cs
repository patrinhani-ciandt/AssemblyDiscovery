using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace AssemblyDiscovery
{
    public partial class FormAssemblyDetail : Form
    {
        #region Variaveis

        private AssemblyTO formAssembly;

        #endregion

        #region Construtores e Inicializadores

        public FormAssemblyDetail(AssemblyTO assembly)
        {
            InitializeComponent();

            this.formAssembly = assembly;
        }

        #endregion

        #region Métodos Estaticos

        public static void Show(AssemblyTO assembly)
        {
            FormAssemblyDetail form = new FormAssemblyDetail(assembly);

            form.ShowDialog();
        }

        #endregion

        private void FormAssemblyDetail_Load(object sender, EventArgs e)
        {
            this.assemblyDetails1.SetAssembly(this.formAssembly.Location);
        }
    }
}
