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
    public partial class frmCliente : Form
    {
        //Instanciar objetos das classes
        Cliente cli = new Cliente();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        //Variáveis comuns
        private int op, cod;

        //Variaveis para verificar a existencia de cliente por cpf e cnpj
        public static string clienteCnpj;
        public static string clienteCpf;

        public frmCliente()
        {
            InitializeComponent();
            Desabilita();
            Consultar();
        }

        //Metodo CPF e CNPJ
        public void CpfCnpj()
        {
            if(cbbPessoa.Text == "Física")
            {
                txtCpf.Visible = true;
                lblCpf.Visible = true;
                txtCnpj.Visible = false;
                lblCnpj.Visible = false;
                txtCnpj.Text = "";
            }
            else if(cbbPessoa.Text == "Jurídica")
            {
                txtCpf.Visible = false;
                lblCpf.Visible = false;
                txtCnpj.Visible = true;
                lblCnpj.Visible = true;
                txtCpf.Text = "";
            } 
        }

        //Metodo que Desabilita campos e botão salvar
        public void Desabilita()
        {
            txtBairro.Enabled = false;
            txtCel.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            txtCnpj.Enabled = false;
            txtCpf.Enabled = false;
            txtEmail.Enabled = false;
            txtNasc.Enabled = false;
            txtNome.Enabled = false;
            txtNum.Enabled = false;
            txtRua.Enabled = false;
            cbbSexo.Enabled = false;
            txtTel.Enabled = false;
            cbbEstado.Enabled = false;
            btnSalvar.Enabled = false;
            cbbPessoa.Enabled = false;
            btnNovo.Enabled = true;
        }

        //Método para limpar os textBox e combobox
        private void Limpar()
        {
            txtNome.Clear();
            txtBairro.Clear();
            txtCel.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCnpj.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtNasc.Clear();
            txtNum.Clear();
            txtPesq.Clear();
            txtRua.Clear();
            txtTel.Clear();
            cbbEstado.Text = null;
            cbbSexo.Text = null;
            cbbPessoa.Text = null;
            txtCnpj.Visible = false;
            txtCpf.Visible = false;
            lblCnpj.Visible = false;
            lblCpf.Visible = false;
            txtPesq.Clear();
        }

        //Habilitar os botões
        private void HabiltarBotoes()
        {
            btnNovo.Enabled = (op == 1);
            btnSalvar.Enabled = (op > 0);

            txtBairro.Enabled = true;
            txtCel.Enabled = true;
            txtCep.Enabled = true;
            txtCidade.Enabled = true;
            txtCnpj.Enabled = true;
            txtCpf.Enabled = true;
            txtEmail.Enabled = true;
            txtNasc.Enabled = true;
            txtNome.Enabled = true;
            txtNum.Enabled = true;
            txtRua.Enabled = true;
            cbbSexo.Enabled = true;
            txtTel.Enabled = true;
            cbbEstado.Enabled = true;
            btnSalvar.Enabled = true;
            cbbPessoa.Enabled = true;
        }

        //Metodo para trazer os dados no DataGrid
        public DataTable Consultar()
        {
            dgvCliente.DataSource = cli.Consultar();
            sql.CommandText = "SELECT cli_nome, cli_nasc, cli_sexo, cli_telefone, cli_celular, cli_cpf, " +
                              "cli_cnpj, cli_email, cli_rua, cli_num, " +
                              "cli_bairro, cli_cidade, cli_estado, cli_cep " +
                              "FROM Cliente";

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dtCliente = new DataTable();

            da.Fill(dtCliente);
            return dtCliente;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabiltarBotoes();
            this.Limpar();
            op = 1;
            txtNome.Focus();
            btnAtivar.Enabled = false;
            btnDesativar.Enabled = false;
            btnNovo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Text == "" || txtNasc.Text == "" || txtRua.Text == "" || 
                txtRua.Text == "" || txtBairro.Text == "" ||
                txtCidade.Text == "" || txtCep.Text == ""))
            {
                if(!(cbbPessoa.Text == ""))
                {
                    if (((txtCpf.Text != "   ,   ,   -") && (txtCpf.Text.Length == 14)) 
                        || ((txtCnpj.Text != "  ,   ,   /    -") && (txtCnpj.Text.Length == 18)))
                    {
                        bool validarCpf, validarCnpj;
                        if(txtCpf.Text != "   ,   ,   -")
                        {
                            clienteCpf = txtCpf.Text;
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            validarCpf = cli.VerificarCpfCliente(clienteCpf);
                            if (dgvCliente.SelectedCells[8].Value.ToString() == clienteCpf && op != 1)
                            {
                                validarCpf = false;
                            }

                            if (validarCpf == false)
                            {
                                try
                                {
                                    if (op == 1)
                                    {
                                        Cliente cli1 = new Cliente(0,
                                            txtNome.Text,
                                            txtNasc.Text,
                                            cbbSexo.Text,
                                            txtTel.Text,
                                            txtCel.Text,
                                            txtCnpj.Text,
                                            txtCpf.Text,
                                            txtEmail.Text,
                                            txtRua.Text,
                                            txtNum.Text,
                                            txtBairro.Text,
                                            txtCidade.Text,
                                            cbbEstado.Text,
                                            txtCep.Text);
                                        cli.Cadastrar(cli1);
                                        MessageBox.Show("Cliente cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        Cliente cli2 = new Cliente(cod,
                                            txtNome.Text,
                                            txtNasc.Text,
                                            cbbSexo.Text,
                                            txtTel.Text,
                                            txtCel.Text,
                                            txtCpf.Text,
                                            txtCnpj.Text,
                                            txtEmail.Text,
                                            txtRua.Text,
                                            txtNum.Text,
                                            txtBairro.Text,
                                            txtCidade.Text,
                                            cbbEstado.Text,
                                            txtCep.Text);
                                        cli.Alterar(cli2);
                                        MessageBox.Show("Cliente alterado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Você não está conectado com o banco corretamente!", "Erro De Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                finally
                                {
                                    op = 0;
                                    this.Limpar();
                                    dgvCliente.DataSource = cli.Consultar();
                                    btnSalvar.Enabled = false;
                                    Desabilita();
                                    btnAtivar.Enabled = true;
                                    btnDesativar.Enabled = true;
                                    btnNovo.Enabled = true;
                                    con.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("O CPF digitado já está cadastrado no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                            }
                        }
                        else if(txtCnpj.Text != "  ,   ,   /    -")
                        {
                            clienteCnpj = txtCnpj.Text;
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            validarCnpj = cli.VerificarCnpjCliente(clienteCnpj);
                            if (dgvCliente.SelectedCells[7].Value.ToString() == clienteCnpj && op != 1)
                            {
                                validarCnpj = false;
                            }

                            if (validarCnpj == false)
                            {
                                try
                                {
                                    if (op == 1)
                                    {
                                        Cliente cli1 = new Cliente(0,
                                            txtNome.Text,
                                            txtNasc.Text,
                                            cbbSexo.Text,
                                            txtTel.Text,
                                            txtCel.Text,
                                            txtCnpj.Text,
                                            txtCpf.Text,
                                            txtEmail.Text,
                                            txtRua.Text,
                                            txtNum.Text,
                                            txtBairro.Text,
                                            txtCidade.Text,
                                            cbbEstado.Text,
                                            txtCep.Text);
                                        cli.Cadastrar(cli1);
                                        MessageBox.Show("Cliente cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        Cliente cli2 = new Cliente(cod,
                                            txtNome.Text,
                                            txtNasc.Text,
                                            cbbSexo.Text,
                                            txtTel.Text,
                                            txtCel.Text,
                                            txtCpf.Text,
                                            txtCnpj.Text,
                                            txtEmail.Text,
                                            txtRua.Text,
                                            txtNum.Text,
                                            txtBairro.Text,
                                            txtCidade.Text,
                                            cbbEstado.Text,
                                            txtCep.Text);
                                        cli.Alterar(cli2);
                                        MessageBox.Show("Cliente alterado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Você não está conectado com o banco corretamente!", "Erro De Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                finally
                                {
                                    op = 0;
                                    this.Limpar();
                                    dgvCliente.DataSource = cli.Consultar();
                                    btnSalvar.Enabled = false;
                                    Desabilita();
                                    btnAtivar.Enabled = true;
                                    btnDesativar.Enabled = true;
                                    btnNovo.Enabled = true;
                                    con.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("O CNPJ digitado já está cadastrado no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF, CNPJ ou CEP Incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Tipo de Pessoa!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvCliente_Click(object sender, EventArgs e)
        {
            Limpar();
            btnNovo.Enabled = true;
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            Desabilita();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if(dgvCliente.SelectedCells[15].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja ativar este cliente? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvCliente.SelectedCells[0].Value.ToString());
                        cli.Ativar(cod);
                        MessageBox.Show("Cliente ativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        dgvCliente.DataSource = cli.Consultar();
                        HabiltarBotoes();

                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Cliente já está ativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if(dgvCliente.SelectedCells[15].Value.ToString() != "INATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja desativar este cliente? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvCliente.SelectedCells[0].Value.ToString());
                        cli.Desativar(cod);
                        MessageBox.Show("Cliente desativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        dgvCliente.DataSource = cli.Consultar();
                        HabiltarBotoes();

                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }                    
            }
            else
            {
                MessageBox.Show("Cliente já está desativado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Limpar();
            dgvCliente.DataSource = cli.Consultar();
        }

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            if(cbbPesq.Text == "CPF")
            {
                dgvCliente.DataSource = cli.PesquisarCpfCli(txtPesq.Text);
            }
            else if(cbbPesq.Text == "Cidade")
            {
                dgvCliente.DataSource = cli.PesquisarCidadeCli(txtPesq.Text);
            }
            else if(cbbPesq.Text == "Nome")
            {
                dgvCliente.DataSource = cli.PesquisarNomeCli(txtPesq.Text);
            }
            else if (cbbPesq.Text == "CNPJ")
            {
                dgvCliente.DataSource = cli.PesquisarCnpjCli(txtPesq.Text);
            }
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                op = 2;
                cod = int.Parse(dgvCliente.SelectedCells[0].Value.ToString());

                this.HabiltarBotoes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCliente.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    cod = int.Parse(dgvCliente.SelectedCells[0].Value.ToString());
                    txtNome.Text = dgvCliente.SelectedCells[1].Value.ToString();
                    txtNasc.Text = dgvCliente.SelectedCells[2].Value.ToString();
                    cbbSexo.Text = dgvCliente.SelectedCells[3].Value.ToString();
                    txtTel.Text = dgvCliente.SelectedCells[4].Value.ToString();
                    txtCel.Text = dgvCliente.SelectedCells[5].Value.ToString();
                    txtCpf.Text = dgvCliente.SelectedCells[6].Value.ToString();
                    txtCnpj.Text = dgvCliente.SelectedCells[7].Value.ToString();
                    txtEmail.Text = dgvCliente.SelectedCells[8].Value.ToString();
                    txtRua.Text = dgvCliente.SelectedCells[9].Value.ToString();
                    txtNum.Text = dgvCliente.SelectedCells[10].Value.ToString();
                    txtBairro.Text = dgvCliente.SelectedCells[11].Value.ToString();
                    txtCidade.Text = dgvCliente.SelectedCells[12].Value.ToString();
                    cbbEstado.Text = dgvCliente.SelectedCells[13].Value.ToString();
                    txtCep.Text = dgvCliente.SelectedCells[14].Value.ToString();

                    if (!(txtCpf.Text == "   ,   ,   -"))
                    {
                        cbbPessoa.Text = "Física";
                        txtCpf.Text = dgvCliente.SelectedCells[6].Value.ToString();
                    }
                    else if (!(txtCnpj.Text == "  ,   ,   /    -"))
                    {
                        cbbPessoa.Text = "Jurídica";
                        txtCnpj.Text = dgvCliente.SelectedCells[7].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("Erro ao realizar a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
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

        private void cbbPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CpfCnpj();
        }

        private void DgvCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvCliente.Columns[0].HeaderText = "Código";
            dgvCliente.Columns[1].HeaderText = "Nome";
            dgvCliente.Columns[2].HeaderText = "Nascimento";
            dgvCliente.Columns[3].HeaderText = "Sexo";
            dgvCliente.Columns[4].HeaderText = "Telefone";
            dgvCliente.Columns[5].HeaderText = "Celular";
            dgvCliente.Columns[6].HeaderText = "CPF";
            dgvCliente.Columns[7].HeaderText = "CNPJ";
            dgvCliente.Columns[8].HeaderText = "E-Mail";
            dgvCliente.Columns[9].HeaderText = "Rua";
            dgvCliente.Columns[10].HeaderText = "Número";
            dgvCliente.Columns[11].HeaderText = "Bairro";
            dgvCliente.Columns[12].HeaderText = "Cidade";
            dgvCliente.Columns[13].HeaderText = "Estado";
            dgvCliente.Columns[14].HeaderText = "CEP";
            dgvCliente.Columns[15].HeaderText = "Status";
        }

        private void cbbPesq_Click(object sender, EventArgs e)
        {
            Limpar();
            Desabilita();
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            if (txtCpf.Text.Length < 14)
            {
                lblTabela.Focus();
                MessageBox.Show("CPF Incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

         private void txtCnpj_Leave(object sender, EventArgs e)
         {
             if (txtCnpj.Text.Length < 18)
             {
                lblTabela.Focus();
                MessageBox.Show("CNPJ Incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
         }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.Text.Length < 9)
            {
                lblTabela.Focus();
                MessageBox.Show("CEP Incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNasc_Leave(object sender, EventArgs e)
        {
            if (txtNasc.Text.Length < 10)
            {
                lblTabela.Focus();
                MessageBox.Show("Data de Nascimento Incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void txtPesq_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            Desabilita();
            Limpar();
        }
    }
}
