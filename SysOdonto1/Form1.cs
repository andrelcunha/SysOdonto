using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysOdonto1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastrar_sysodonto child = new Cadastrar_sysodonto();
            child.MdiParent = this;
            child.Show();

        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPesquisa child = new frmPesquisa();
            child.MdiParent = this;
            child.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelatorio child = new FrmRelatorio();
            child.MdiParent = this;
            child.Show();
        }
    }
}
