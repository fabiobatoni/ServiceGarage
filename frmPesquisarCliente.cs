using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OficinaGarage.Classes;
using OficinaGarage.Conexoes;

namespace OficinaGarage.Formularios
{
    public partial class frmPesquisarCliente : Form
    {
        //Instanciar objetos das classes
        Cliente cli = new Cliente();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        public frmPesquisarCliente()
        {
            InitializeComponent();
            dgvPesqCli.DataSource = cli.ConsultarAtivo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPesqCli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPesqCli.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    frmOrcamento.nome = dgvPesqCli.SelectedCells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar puxar o nome do cliente para o orçamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Registro vazio não pode ser selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesqCli_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesqCli.Text == "Cliente")
            {
                dgvPesqCli.DataSource = cli.PesquisarNomeCliAtivo(txtPesqCli.Text);
            }
            else if (cbbPesqCli.Text == "CPF")
            {
                dgvPesqCli.DataSource = cli.PesquisarCpfCliAtivo(txtPesqCli.Text);
            }
            else if (cbbPesqCli.Text == "CNPJ")
            {
                dgvPesqCli.DataSource = cli.PesquisarCnpjCliAtivo(txtPesqCli.Text);
            }
            else if (cbbPesqCli.Text == "Cidade")
            {
                dgvPesqCli.DataSource = cli.PesquisarCidadeCliAtivo(txtPesqCli.Text);
            }
        }

        private void dgvPesqCli_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvPesqCli.Columns[0].HeaderText = "Código";
            dgvPesqCli.Columns[1].HeaderText = "Nome";
            dgvPesqCli.Columns[2].HeaderText = "Nascimento";
            dgvPesqCli.Columns[3].HeaderText = "Sexo";
            dgvPesqCli.Columns[4].HeaderText = "Telefone";
            dgvPesqCli.Columns[5].HeaderText = "Celular";
            dgvPesqCli.Columns[6].HeaderText = "CPF";
            dgvPesqCli.Columns[7].HeaderText = "CNPJ";
            dgvPesqCli.Columns[8].HeaderText = "E-Mail";
            dgvPesqCli.Columns[9].HeaderText = "Rua";
            dgvPesqCli.Columns[10].HeaderText = "Número";
            dgvPesqCli.Columns[11].HeaderText = "Bairro";
            dgvPesqCli.Columns[12].HeaderText = "Cidade";
            dgvPesqCli.Columns[13].HeaderText = "Estado";
            dgvPesqCli.Columns[14].HeaderText = "CEP";
            dgvPesqCli.Columns[15].HeaderText = "Status";
        }
    }
}
