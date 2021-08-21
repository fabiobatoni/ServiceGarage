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
using OficinaGarage.Conexoes;
using OficinaGarage.Classes;
using OficinaGarage.Formularios;

namespace OficinaGarage.Formularios
{
    public partial class frmConsultaEstoque : Form
    {
        //Instanciar objetos das classes
        ConsultarEstoque cons = new ConsultarEstoque();
        Produto pro = new Produto();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        //Variaveis Simples
        private int op, cod;
        public frmConsultaEstoque()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConsultaEstoque_Load(object sender, EventArgs e)
        {
            dgvProduto.DataSource = pro.Consultar();
        }

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesq.Text == "Nome")
            {
                dgvProduto.DataSource = pro.PesquisarNomePro(txtPesq.Text);
            }
            else if (cbbPesq.Text == "Descrição")
            {
                dgvProduto.DataSource = pro.PesquisarDescPro(txtPesq.Text);
            }
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                op = 2;
                cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduto.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
                    txtCodigo.Text = dgvProduto.SelectedCells[0].Value.ToString();
                    txtData.Text = dgvProduto.SelectedCells[1].Value.ToString();
                    txtNome.Text = dgvProduto.SelectedCells[2].Value.ToString();
                    txtDesc.Text = dgvProduto.SelectedCells[3].Value.ToString();
                    cbbUnidMedida.Text = dgvProduto.SelectedCells[4].Value.ToString();
                    txtQtd.Text = dgvProduto.SelectedCells[5].Value.ToString();
                    txtCusto.Text = dgvProduto.SelectedCells[6].Value.ToString();
                    txtVenda.Text = dgvProduto.SelectedCells[7].Value.ToString();
                    txtValidade.Text = dgvProduto.SelectedCells[8].Value.ToString();
                    txtLocalizacao.Text = dgvProduto.SelectedCells[9].Value.ToString();
                    txtUsuario.Text = dgvProduto.SelectedCells[11].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fazer a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Registro vazio não pode ser consultado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvProduto.Columns[0].HeaderText = "Código";
            dgvProduto.Columns[1].HeaderText = "Data";
            dgvProduto.Columns[2].HeaderText = "Nome";
            dgvProduto.Columns[3].HeaderText = "Descrição";
            dgvProduto.Columns[4].HeaderText = "Unidade de Medida";
            dgvProduto.Columns[5].HeaderText = "Quantidade";
            dgvProduto.Columns[6].HeaderText = "Preço Compra";
            dgvProduto.Columns[7].HeaderText = "Preço Venda";
            dgvProduto.Columns[8].HeaderText = "Validade";
            dgvProduto.Columns[9].HeaderText = "Localização";
            dgvProduto.Columns[10].HeaderText = "Status";
            dgvProduto.Columns[11].HeaderText = "Incluido por";
        }

        private class ConsultarEstoque
        {
            public ConsultarEstoque()
            {
            }
        }
    }
}
