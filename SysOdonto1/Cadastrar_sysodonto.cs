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
    public partial class Cadastrar_sysodonto : Form
    {
        Paciente paciente;
        private int codigo;
        private string nome;
        private string dataNasc;
        private string logradouro;
        private string num;
        private string complm;
        private string bairro;
        private string cidade;
        private string estado;
        private string cep;
        private string fone;
        private bool ativo;
        public Cadastrar_sysodonto()
        {
            InitializeComponent();
            paciente = new Paciente();
            codigo = paciente.proximoCodigo();
            txtCodigo.Text = Convert.ToString(codigo);
            nome = string.Empty;
            dataNasc = string.Empty;
            logradouro = string.Empty;
            num = string.Empty;
            complm = string.Empty;
            bairro = string.Empty;
            cidade = string.Empty;
            estado = string.Empty;
            cep = string.Empty;
            fone = string.Empty;
            ativo = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clear();

        }
        private void clear()
        {
                txtCodigo.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtComplm.Text = "";
                txtLogradouro.Text = "";
                txtNome.Text = "";
                txtNumero.Text = "";
                txtTelefone.Text = "";
                cmb_UF.Text = "";
                txtCEP.Text = "";
                ckb_Ativo.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            getText();
            string[] values = { Convert.ToString(codigo),"'"+nome+"'",
                "'"+dataNasc+"'",
                "'"+logradouro+"'",
                num , "'"+complm+"'",
                "'"+bairro+"'", "'"+cidade+"'",
                "'"+estado+"'", cep,
                fone, ativo.ToString() };
            if (paciente.existeCodigo(codigo))
            {
                MessageBox.Show("Paciente cadastrado com sucesso.", "Cadastro", MessageBoxButtons.OK);
                clear();
                btnSalvar.Enabled = false;
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "Nao foi possível efetuar o cadastro. Tente novamente", "Falha", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr.Equals(DialogResult.Cancel))
                    this.Close();
            }
        }
        private void getText()
        {
            nome = txtNome.Text;
            dataNasc = dateTimePicker1.Text;
            logradouro = txtLogradouro.Text;
            num = txtNumero.Text;
            complm = txtComplm.Text;
            bairro = txtBairro.Text;
            cidade = txtCidade.Text;
            estado = cmb_UF.Text;
            cep = txtCEP.Text;
            fone = txtTelefone.Text;
            ativo = ckb_Ativo.CheckState.ToString().Equals("Checked");
        }

        private void ckb_Ativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
