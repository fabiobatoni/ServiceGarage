using OficinaGarage.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OficinaGarage.Classes;
using OficinaGarage.Conexoes;
using MySql.Data.MySqlClient;

namespace OficinaGarage.Formularios
{
    public partial class frmProduto : Form
    {
        //Instanciar objetos das classes
        Produto pro = new Produto();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        //Variaveis Simples
        private int op, cod;

        public frmProduto()
        {
            InitializeComponent();
            Desabilita();
            Consultar();
            //HabiltarBotoes();
            btnSalvar.Enabled = false;
           // btnSalvar.Visible = false;
        }

        //Botão fechar
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo Desabilita Campos e botão salvar
        public void Desabilita()
        {
            txtNome.Enabled = false;
            txtDesc.Enabled = false;
            cbbUnidMedida.Enabled = false;
            txtQtd.Enabled = false;
            txtCusto.Enabled = false;
            txtVenda.Enabled = false;
            txtValidade.Enabled = false;
            txtLocalizacao.Enabled = false;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void HabiltarBotoes()
        {
            btnNovo.Enabled = op == 0;
            btnSalvar.Enabled = op > 0;
            btnAtivar.Enabled = ((op == 0) && (dgvProduto.RowCount > 0));
            btnDesativar.Enabled = ((op == 0) && (dgvProduto.RowCount > 0));

            btnSalvar.Enabled = true;
            txtCusto.Enabled = true;
            txtDesc.Enabled = true;
            txtNome.Enabled = true;
            txtPesq.Enabled = true;
            txtQtd.Enabled = true;
            txtValidade.Enabled = true;
            txtVenda.Enabled = true;
            cbbUnidMedida.Enabled = true;
            txtLocalizacao.Enabled = true;
        }

        //Método para limpar os textBox e combobox
        private void Limpar()
        {
            txtNome.Clear();
            txtQtd.Clear();
            txtValidade.Clear();
            txtVenda.Clear();
            txtCusto.Clear();
            txtDesc.Clear();
            txtQtd.Clear();
            cbbUnidMedida.Text = null;
            txtPesq.Clear();
            txtLocalizacao.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            op = 1;
            this.Limpar();
            // Habilita();
            HabiltarBotoes();
            txtNome.Focus();
            btnAtivar.Enabled = false;
            btnDesativar.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (op == 1)
            {
                Produto pro1 = new Produto(0,
                    txtDataProd.Text,
                    txtNome.Text,
                    txtDesc.Text,
                    txtValidade.Text,
                    cbbUnidMedida.Text,
                    double.Parse(txtQtd.Text),
                    double.Parse(txtCusto.Text),
                    double.Parse(txtVenda.Text),
                    txtLocalizacao.Text,
                    txtUsuario.Text);
                pro.Cadastrar(pro1);
                MessageBox.Show("Produto cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Produto pro2 = new Produto(cod,
                    txtDataProd.Text,
                    txtNome.Text,
                    txtDesc.Text,
                    txtValidade.Text,
                    cbbUnidMedida.Text,
                    double.Parse(txtQtd.Text),
                    double.Parse(txtCusto.Text),
                    double.Parse(txtVenda.Text),
                    txtLocalizacao.Text,
                    txtUsuario.Text);
                pro.Alterar(pro2);
                MessageBox.Show("Produto alterado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            op = 0;
            this.Limpar();
            dgvProduto.DataSource = pro.Consultar();
            Desabilita();
        }

        private void txtPesquisar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            Desabilita();
            Limpar();
        }

        private void dgvProduto_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            Desabilita();
            Limpar();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if(dgvProduto.SelectedCells[0].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja ativar este produto? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
                        pro.Ativar(cod);
                        MessageBox.Show("Produto ativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Registro vazio não pode ser ativado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Desabilita();
                        }
                    }
                    finally
                    {
                        //Atualizar o data grid
                        dgvProduto.DataSource = pro.Consultar();
                        HabiltarBotoes();
                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }                   
            }
            else
            {
                MessageBox.Show("Produto já está ativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if(dgvProduto.SelectedCells[0].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja desativar este produto? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
                        pro.Desativar(cod);
                        MessageBox.Show("Produto desativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Registro vazio não pode ser desativado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Desabilita();
                        }
                    }
                    finally
                    {
                        //Atualizar o data grid
                        dgvProduto.DataSource = pro.Consultar();
                        HabiltarBotoes();
                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }                   
            }
            else
            {
                MessageBox.Show("Produto já está desativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                op = 2;
                cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
                this.HabiltarBotoes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
            
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            txtDataProd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Limpar();
            dgvProduto.DataSource = pro.Consultar();
            frmLogin logado = new frmLogin();
            txtUsuario.Text = logado.UsuarioLogado();
            //this.HabiltarBotoes();
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvProduto.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    cod = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
                    txtDataProd.Text = dgvProduto.SelectedCells[1].Value.ToString();
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
                    if (MessageBox.Show("Erro ao fazer a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Desabilita();
                    }
                }
                finally
                {
                    btnNovo.Enabled = false;
                    btnSalvar.Enabled = true;
                    HabiltarBotoes();
                }
            }
            else
            {
                if (MessageBox.Show("Registro vazio não pode ser consultado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Desabilita();
                }
            }               
        }

        private void DgvProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void TxtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
        }

        private void TxtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
        }

        private void TxtVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
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

        private void cbbPesq_Click(object sender, EventArgs e)
        {
            Limpar();
            Desabilita();
        }

        private void dgvProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtQtd.Enabled = false;
        }

        //Metodo para trazer os dados no DataGrid
        public DataTable Consultar()
        {
            dgvProduto.DataSource = pro.Consultar();
            sql.CommandText = "SELECT pro_cod, pro_nome, pro_descricao, pro_unidadeMedida, pro_quantidade, pro_precoCompra, pro_precoVenda, pro_validade, pro_localizacao, pro_status, pro_usuario FROM Produto";

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dtProduto = new DataTable();

            da.Fill(dtProduto);
            return dtProduto;
        }
    }
}
