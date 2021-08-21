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
using MySql.Data.MySqlClient;
using OficinaGarage.Conexoes;
using OficinaGarage.Classes;

namespace OficinaGarage
{
    public partial class frmCadastrarFuncionário : Form
    {
        //Instanciar um objeto da classe MySQLCommand
        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        //várivel utilizada para verificar se o cpf informado já existe no sistema
        public static string funcionarioCpf;

        //Instanciar objetos das classes
        Funcionario fun = new Funcionario();

        public frmCadastrarFuncionário()
        {
            InitializeComponent();
            Desabilita();
            fun.Consultar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Variáveis comuns
        private int op, cod;

        //Método para limpar os textBox e combobox
        private void Limpar()
        {
            txtNome.Clear();
            txtBairro.Clear();
            txtCel.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCpf.Clear();
            txtFuncao.Clear();
            txtSalario.Clear();
            txtAdmissao.Clear();
            txtEmail.Clear();
            txtNasc.Clear();
            txtNum.Clear();
            txtPesq.Clear();
            txtRua.Clear();
            txtTel.Clear();
            cbbEstado.Text = null;
            cbbSexo.Text = null;
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
            txtCpf.Enabled = true;
            txtAdmissao.Enabled = true;
            txtSalario.Enabled = true;
            txtFuncao.Enabled = true;
            txtEmail.Enabled = true;
            txtNasc.Enabled = true;
            txtNome.Enabled = true;
            txtNum.Enabled = true;
            txtRua.Enabled = true;
            cbbSexo.Enabled = true;
            txtTel.Enabled = true;
            cbbEstado.Enabled = true;
            btnSalvar.Enabled = true;
        }

        //Metodo Desabilitar campos e botão salvar
        public void Desabilita()
        {
            txtBairro.Enabled = false;
            txtCel.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            txtCpf.Enabled = false;
            txtAdmissao.Enabled = false;
            txtSalario.Enabled = false;
            txtFuncao.Enabled = false;
            txtEmail.Enabled = false;
            txtNasc.Enabled = false;
            txtNome.Enabled = false;
            txtNum.Enabled = false;
            txtRua.Enabled = false;
            cbbSexo.Enabled = false;
            txtTel.Enabled = false;
            cbbEstado.Enabled = false;
            btnSalvar.Enabled = false;
            txtAdmissao.Enabled = false;
            txtFuncao.Enabled = false;
            txtSalario.Enabled = false;
            btnNovo.Enabled = true;
        }

        public void Habilita()
        {
            txtBairro.Enabled = true;
            txtCel.Enabled = true;
            txtCep.Enabled = true;
            txtCidade.Enabled = true;
            txtCpf.Enabled = true;
            txtAdmissao.Enabled = true;
            txtSalario.Enabled = true;
            txtFuncao.Enabled = true;
            txtEmail.Enabled = true;
            txtNasc.Enabled = true;
            txtNome.Enabled = true;
            txtNum.Enabled = true;
            txtRua.Enabled = true;
            cbbSexo.Enabled = true;
            txtTel.Enabled = true;
            cbbEstado.Enabled = true;
            btnSalvar.Enabled = true;
            txtAdmissao.Enabled = true;
            txtFuncao.Enabled = true;
            txtSalario.Enabled = true;
        }

        //Metodo para trazer os dados no DataGrid
        /*public DataTable Consultar()
        {
            dgvFuncionario.DataSource = fun.Consultar();
            sql.CommandText = "SELECT * FROM Funcionario";

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable Funcionario = new DataTable();

            da.Fill(Funcionario);
            return Funcionario;
        }*/

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Habilita();
            this.Limpar();
            op = 1;
            txtNome.Focus();
            btnAtivar.Enabled = false;
            btnDesativar.Enabled = false;
            btnNovo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Campos Obrigatórios a ser preenchidos
            if (!(txtNome.Text == "" || txtNasc.Text == "" || txtRua.Text == "" || txtCel.Text == "" ||
                txtCidade.Text == "" || txtCep.Text == ""  || txtCpf.Text == "" ||
                txtFuncao.Text == "" || txtAdmissao.Text == "" || txtBairro.Text == ""))
            {
                bool validar;
                funcionarioCpf = txtCpf.Text;
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                validar = fun.VerificarFuncionario(funcionarioCpf);
                if (dgvFuncionario.SelectedCells[6].Value.ToString() == funcionarioCpf && op != 1)
                {
                    validar = false;
                }

                if (validar == false)
                {
                    if (op == 1)
                    {
                        Funcionario fun1 = new Funcionario(0,
                            txtNome.Text,
                            txtNasc.Text,
                            cbbSexo.Text,
                            txtTel.Text,
                            txtCel.Text,
                            txtCpf.Text,
                            txtEmail.Text,
                            txtAdmissao.Text,
                            txtSalario.Text,
                            txtFuncao.Text,
                            txtRua.Text,
                            txtNum.Text,
                            txtBairro.Text,
                            txtCidade.Text,
                            cbbEstado.Text,
                            txtCep.Text);
                        fun.Cadastrar(fun1);
                        MessageBox.Show("Funcionário cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Funcionario fun2 = new Funcionario(cod,
                            txtNome.Text,
                            txtNasc.Text,
                            cbbSexo.Text,
                            txtTel.Text,
                            txtCel.Text,
                            txtCpf.Text,
                            txtEmail.Text,
                            txtAdmissao.Text,
                            txtSalario.Text,
                            txtFuncao.Text,
                            txtRua.Text,
                            txtNum.Text,
                            txtBairro.Text,
                            txtCidade.Text,
                            cbbEstado.Text,
                            txtCep.Text);
                        fun.Alterar(fun2);
                        MessageBox.Show("Funcionário alterado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    op = 0;
                    this.Limpar();
                    dgvFuncionario.DataSource = fun.Consultar();
                    Desabilita();
                }
                else
                {
                    MessageBox.Show("O CPF digitado já está cadastrado no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvFuncionario_Click(object sender, EventArgs e)
        {
            Limpar();
            btnNovo.Enabled = true;
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            Desabilita();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if(dgvFuncionario.SelectedCells[0].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja ativar este funcionário? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvFuncionario.SelectedCells[0].Value.ToString());
                        fun.Ativar(cod);
                        MessageBox.Show("Funcionário ativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        dgvFuncionario.DataSource = fun.Consultar();
                        Habilita();
                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }                    
            }
            else
            {
                MessageBox.Show("Funcionário já está ativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if(dgvFuncionario.SelectedCells[0].Value.ToString() != "INATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja desativar este funcionário? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvFuncionario.SelectedCells[0].Value.ToString());
                        fun.Desativar(cod);
                        MessageBox.Show("Funcionário desativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        dgvFuncionario.DataSource = fun.Consultar();
                        Habilita();
                        Limpar();
                        Desabilita();
                        btnNovo.Enabled = true;
                    }
                }                    
            }
            else
            {
                MessageBox.Show("Funcionário já está desativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesq.Text == "CPF")
            {
                dgvFuncionario.DataSource = fun.PesquisarCpfFun(txtPesq.Text);
            }
            else if (cbbPesq.Text == "Cidade")
            {
                dgvFuncionario.DataSource = fun.PesquisarCidadeFun(txtPesq.Text);
            }
            else if (cbbPesq.Text == "Nome")
            {
                dgvFuncionario.DataSource = fun.PesquisarNomeFun(txtPesq.Text);
            }
        }

        private void dgvFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                op = 2;
                cod = int.Parse(dgvFuncionario.SelectedCells[0].Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
        }

        private void frmCadastrarFuncionário_Load(object sender, EventArgs e)
        {
            this.Limpar();
            dgvFuncionario.DataSource = fun.Consultar();
        }

        private void dgvFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFuncionario.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    cod = int.Parse(dgvFuncionario.SelectedCells[0].Value.ToString());
                    txtNome.Text = dgvFuncionario.SelectedCells[1].Value.ToString();
                    txtNasc.Text = dgvFuncionario.SelectedCells[2].Value.ToString();
                    cbbSexo.Text = dgvFuncionario.SelectedCells[3].Value.ToString();
                    txtTel.Text = dgvFuncionario.SelectedCells[4].Value.ToString();
                    txtCel.Text = dgvFuncionario.SelectedCells[5].Value.ToString();
                    txtCpf.Text = dgvFuncionario.SelectedCells[6].Value.ToString();
                    txtFuncao.Text = dgvFuncionario.SelectedCells[7].Value.ToString();
                    txtAdmissao.Text = dgvFuncionario.SelectedCells[8].Value.ToString();
                    txtSalario.Text = dgvFuncionario.SelectedCells[9].Value.ToString();
                    txtEmail.Text = dgvFuncionario.SelectedCells[10].Value.ToString();
                    txtRua.Text = dgvFuncionario.SelectedCells[11].Value.ToString();
                    txtNum.Text = dgvFuncionario.SelectedCells[12].Value.ToString();
                    txtBairro.Text = dgvFuncionario.SelectedCells[13].Value.ToString();
                    txtCidade.Text = dgvFuncionario.SelectedCells[14].Value.ToString();
                    cbbEstado.Text = dgvFuncionario.SelectedCells[15].Value.ToString();
                    txtCep.Text = dgvFuncionario.SelectedCells[16].Value.ToString();
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

        private void DgvFuncionario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvFuncionario.Columns[0].HeaderText = "Código";
            dgvFuncionario.Columns[1].HeaderText = "Nome";
            dgvFuncionario.Columns[2].HeaderText = "Nascimento";
            dgvFuncionario.Columns[3].HeaderText = "Sexo";
            dgvFuncionario.Columns[4].HeaderText = "Telefone";
            dgvFuncionario.Columns[5].HeaderText = "Celular";
            dgvFuncionario.Columns[6].HeaderText = "CPF";
            dgvFuncionario.Columns[7].HeaderText = "Função";
            dgvFuncionario.Columns[8].HeaderText = "Admissão";
            dgvFuncionario.Columns[9].HeaderText = "Salário";
            dgvFuncionario.Columns[10].HeaderText = "E-Mail";
            dgvFuncionario.Columns[11].HeaderText = "Rua";
            dgvFuncionario.Columns[12].HeaderText = "Número";
            dgvFuncionario.Columns[13].HeaderText = "Bairro";
            dgvFuncionario.Columns[14].HeaderText = "Cidade";
            dgvFuncionario.Columns[15].HeaderText = "Estado";
            dgvFuncionario.Columns[16].HeaderText = "CEP";
            dgvFuncionario.Columns[17].HeaderText = "Status";
        }

        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula");
            }
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
                MessageBox.Show("CPF Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.Text.Length < 9)
            {
                lblTabela.Focus();
                MessageBox.Show("CEP Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void txtNasc_Leave(object sender, EventArgs e)
        {
            if (txtNasc.Text.Length < 10)
            {
                lblTabela.Focus();
                MessageBox.Show("Data de Nascimento Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void txtAdmissao_Leave(object sender, EventArgs e)
        {
            if (txtAdmissao.Text.Length < 10)
            {
                lblTabela.Focus();
                MessageBox.Show("Data de Admissão Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
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
