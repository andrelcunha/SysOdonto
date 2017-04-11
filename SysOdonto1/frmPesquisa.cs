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
    public partial class frmPesquisa : Form
    {
        Paciente paciente;
        string codigo = string.Empty;
        string nome = string.Empty;
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
        public frmPesquisa()
        {
            InitializeComponent();
            paciente = new Paciente();
            

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            codigo = txtCodigo.Text;
            nome = txtNome.Text;
            var dt = new DataTable();
            if (!(codigo.Equals(string.Empty)))
            {
                dt=paciente.Searchbycodigo_dt(Convert.ToInt32(codigo));
                string sRow = string.Empty;
                if (dt.Rows.Count != 0)
                    for (int i=0;i<dt.Rows[0].ItemArray.Length;i++)
                    {
                        switch (i) {
                            case 1: txtNome.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 2: dateTimePicker1.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 3: txtLogradouro.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 4: txtNumero.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 5: txtComplm.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 6: txtBairro.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 7: txtCidade.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 8: cmb_UF.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 9: txtCEP.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 10: txtTelefone.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 11: ckb_Ativo.Checked  = Convert.ToBoolean(dt.Rows[0].ItemArray[i].ToString()); break;
                        }
                    }
            }
            else if (!(nome.Equals(string.Empty)))
            {
                dt=paciente.Searchbyname_dt(nome);
                string sRow = string.Empty;
                if (dt.Rows.Count != 0)
                    for (int i = 0; i < dt.Rows[0].ItemArray.Length; i++)
                    {
                        switch (i)
                        {
                            case 0: txtCodigo.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 2: dateTimePicker1.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 3: txtLogradouro.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 4: txtNumero.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 5: txtComplm.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 6: txtBairro.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 7: txtCidade.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 8: cmb_UF.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 9: txtCEP.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 10: txtTelefone.Text = dt.Rows[0].ItemArray[i].ToString(); break;
                            case 11: ckb_Ativo.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[i].ToString()); break;
                        }
                    }
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ckb_Ativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmb_UF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComplm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogradouro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btmAtualizar_Click(object sender, EventArgs e)
        {
            getText();
            if (paciente.existeCodigo(Convert.ToInt32(codigo)))
                codigo = paciente.proximoCodigo().ToString();
            string[] values = { Convert.ToString(codigo),"'"+nome+"'",
                "'"+dataNasc+"'",
                "'"+logradouro+"'",
                num , "'"+complm+"'",
                "'"+bairro+"'", "'"+cidade+"'",
                "'"+estado+"'", cep,
                fone, ativo.ToString() };
            if (!paciente.existeCodigo(Convert.ToInt32(codigo)))
            {
                paciente.Insert(values);
                if (paciente.existeCodigo(Convert.ToInt32(codigo)))
                {
                    //btnSalvar.Visible = false;
                }
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

    }
}
