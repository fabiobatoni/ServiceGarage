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
    public partial class frmAdicionarProdutos : Form
    {
        Produto pro = new Produto();
        ItensOrcamento ite = new ItensOrcamento();
        Orcamento orc = new Orcamento();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        //Variaveis Simples
        private int op, cod;
        double qtd;

        public frmAdicionarProdutos()
        {
            InitializeComponent();
            dgvPesqProd.DataSource = pro.ConsultarAtivo();
        }

        public void Limpar()
        {
            txtAdicionar.Clear();
            txtDesc.Clear();
            txtNome.Clear();
            txtPesqProd.Clear();
            txtQtd.Clear();
            txtUnidade.Clear();
            cbbPesqProd.Text = null;
            btnDepositar.Enabled = false;
            txtAdicionar.Visible = false;
            lblAdc.Visible = false;
            txtRemover.Visible = false;
            lblRemover.Visible = false;
            cbbOperacao.Text = null;
            cbbOperacao.Enabled = false;
            txtAdicionar.Clear();
            txtRemover.Clear();
        }
        private void txtPesqProd_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesqProd.Text == "Nome")
            {
                dgvPesqProd.DataSource = pro.PesquisarNomeProAtivo(txtPesqProd.Text);
            }
            else if (cbbPesqProd.Text == "Descrição")
            {
                txtPesqProd.Focus();
                dgvPesqProd.DataSource = pro.PesquisarDescProAtivo(txtPesqProd.Text);
            }
        }

        private void dgvPesqProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
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

        private void dgvPesqProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpar();
            try
            {
                op = 2;
                cod = int.Parse(dgvPesqProd.SelectedCells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
        }

        private void frmAdicionarProdutos_Load(object sender, EventArgs e)
        {
            dgvPesqProd.DataSource = pro.ConsultarAtivo();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Metodo Operação
        public void Operacao()
        {
            if (cbbOperacao.Text == "Adicionar")
            {
                txtAdicionar.Visible = true;
                lblAdc.Visible = true;
                txtRemover.Visible = false;
                lblRemover.Visible = false;
                btnDepositar.Enabled = true;
                btnDepositar.Visible = true;
                btnRemover.Visible = false;
                txtAdicionar.Focus();
            }
            else if (cbbOperacao.Text == "Remover")
            {
                txtAdicionar.Visible = false;
                lblAdc.Visible = false;
                txtRemover.Visible = true;
                lblRemover.Visible = true;
                btnDepositar.Enabled = true;
                btnDepositar.Visible = false;
                btnRemover.Visible = true;
                txtRemover.Focus();
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (dgvPesqProd.SelectedCells[0].Value != null)
            {
                if(txtAdicionar.Text != "")
                {
                    try
                    {
                        cod = int.Parse(dgvPesqProd.SelectedCells[0].Value.ToString());
                        qtd = double.Parse(txtAdicionar.Text);
                        ite.AdicionarProduto(cod, qtd);
                        MessageBox.Show("Produto adicionado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvPesqProd.DataSource = pro.ConsultarAtivo();
                        Limpar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao adicionar produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Preencha o campo Adicionar para realizar a operação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Linhas vazias não possuem conteúdo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbbOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operacao();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            
            if (dgvPesqProd.SelectedCells[0].Value != null)
            {
                if (txtRemover.Text != "")
                {
                    try
                    {
                        cod = int.Parse(dgvPesqProd.SelectedCells[0].Value.ToString());
                        qtd = double.Parse(txtRemover.Text);
                        ite.RemoverProduto(cod, qtd);
                        MessageBox.Show("Produto removido com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvPesqProd.DataSource = pro.ConsultarAtivo();
                        Limpar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao remover produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Preencha o campo Remover para realizar a operação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Linhas vazias não possuem conteúdo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPesqProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpar();
        }

        private void txtPesqProd_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void TxtAdicionar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
        }

        private void TxtRemover_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
        }

        private void dgvPesqProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpar();
            if (dgvPesqProd.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    Operacao();
                    cbbOperacao.Enabled = true;
                    cod = int.Parse(dgvPesqProd.SelectedCells[0].Value.ToString());
                    txtNome.Text = dgvPesqProd.SelectedCells[2].Value.ToString();
                    txtDesc.Text = dgvPesqProd.SelectedCells[3].Value.ToString();
                    txtUnidade.Text = dgvPesqProd.SelectedCells[4].Value.ToString();
                    txtQtd.Text = dgvPesqProd.SelectedCells[5].Value.ToString();

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
    }
}
