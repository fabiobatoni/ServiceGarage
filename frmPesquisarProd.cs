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

namespace OficinaGarage.Formularios
{
    public partial class frmPesquisarProd : Form
    {
        //Instanciar objetos das classes
        Produto pro = new Produto();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        public frmPesquisarProd()
        {
            InitializeComponent();
            dgvPesqProd.DataSource = pro.ConsultarAtivo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPesqProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPesqProd.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    frmOrcamento.desc = dgvPesqProd.SelectedCells[2].Value.ToString();
                    frmOrcamento.valor = double.Parse(dgvPesqProd.SelectedCells[7].Value.ToString());
                    frmOrcamento.codProd = dgvPesqProd.SelectedCells[0].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao realizar a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtPesqProd_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesqProd.Text == "Nome")
            {
                dgvPesqProd.DataSource = pro.PesquisarNomeProAtivo(txtPesqProd.Text);
            }
            else if (cbbPesqProd.Text == "Descrição")
            {
                dgvPesqProd.DataSource = pro.PesquisarDescProAtivo(txtPesqProd.Text);
            }
        }

        private void dgvPesqProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvPesqProd.Columns[0].HeaderText = "Código";
            dgvPesqProd.Columns[1].HeaderText = "Data";
            dgvPesqProd.Columns[2].HeaderText = "Nome";
            dgvPesqProd.Columns[3].HeaderText = "Descrição";
            dgvPesqProd.Columns[4].HeaderText = "Unidade de Medida";
            dgvPesqProd.Columns[5].HeaderText = "Quantidade";
            dgvPesqProd.Columns[6].HeaderText = "Preço Compra";
            dgvPesqProd.Columns[7].HeaderText = "Preço Venda";
            dgvPesqProd.Columns[8].HeaderText = "Validade";
            dgvPesqProd.Columns[9].HeaderText = "Localização";
            dgvPesqProd.Columns[10].HeaderText = "Status";
            dgvPesqProd.Columns[11].HeaderText = "Incluido por";
        }
    }
}
