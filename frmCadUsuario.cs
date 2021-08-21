using OficinaGarage.Classes;
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

namespace OficinaGarage.Formularios
{
    public partial class frmCadUsuario : Form
    {
        //Instanciar um objeto da Classe Usuario
        Usuario usu = new Usuario();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        public static string userUsuario;

        private int op = 0, cod = 0;
        public frmCadUsuario()
        {
            InitializeComponent();
            Desabilitado();
            Consultar();
            HabilitarBotoes();
            btnSalvar.Enabled = false;
        }
        //Metodo para trazer os dados no DataGrid
        public void IdentificarUser()
        {
            if(dgvUsuario.SelectedCells[0].Value.ToString() != "")
            {
                frmMenu.user = dgvUsuario.SelectedCells[1].Value.ToString();
            }
        }

        //Metodo para trazer os dados no DataGrid
        public DataTable Consultar()
        {
            dgvUsuario.DataSource = usu.Consultar();
            sql.CommandText = "SELECT usu_cod, usu_nome, usu_usuario, usu_senha, usu_acesso FROM Usuario";

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dtUsuario = new DataTable();

            da.Fill(dtUsuario);
            return dtUsuario;
        }

        //Metodo que deixa desativado os campos e botão salvar
        public void Desabilitado()
        {
            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            txtConfSenha.Enabled = false;
            cbbAcesso.Enabled = false;
            btnSalvar.Enabled = false;
        }

        //Metodo pra habilitar campos e botão salvar
        public void Habilitar()
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            txtConfSenha.Enabled = true;
            cbbAcesso.Enabled = true;
            btnSalvar.Enabled = true;
            btnAtivar.Enabled = false;
            btnDesativar.Enabled = false;
            HabilitarBotoes();
        }

        //Método para limpar os textBox
        private void Limpar()
        {
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            txtConfSenha.Clear();
            cbbAcesso.Text = null;
            txtNome.Focus();
            txtPesq.Clear();
            cbbPesq.Text = null;
        }

        //Método para Habilitar os botões
        private void HabilitarBotoes()
        {
            btnNovo.Enabled = op == 0;
            btnSalvar.Enabled = op > 0;
            btnAtivar.Enabled = ((op == 0) && (dgvUsuario.RowCount > 0));
            btnDesativar.Enabled = ((op == 0) && (dgvUsuario.RowCount > 0));
            btnSalvar.Enabled = true;
        }

        //Metodo para trazer os dados do datagrid
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            op = 1;
            this.Limpar();
            Habilitar();
            txtNome.Focus();
            btnAtivar.Enabled = false;
            btnDesativar.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "" ||
                txtConfSenha.Text == "" || cbbAcesso.Text == ""))
            {
                if (txtSenha.Text == txtConfSenha.Text)
                {
                    bool validar;
                    userUsuario = txtUsuario.Text;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    validar = usu.VerificarUsuario(userUsuario);
                    if (dgvUsuario.SelectedCells[2].Value.ToString() == userUsuario && op != 1)
                    {
                        validar = false;
                    }
                        if (validar == false)
                    {
                        if (op == 1)
                        {
                            try
                            {
                                Usuario usu1 = new Usuario(0,
                                txtNome.Text,
                                txtUsuario.Text,
                                txtSenha.Text,
                                txtConfSenha.Text,
                                cbbAcesso.Text);
                                usu.Incluir(usu1);
                                MessageBox.Show("Usuário cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao cadastrar usuário!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                this.Limpar();
                                op = 0;
                                dgvUsuario.DataSource = usu.Consultar();
                                this.HabilitarBotoes();
                                Desabilitado();
                                btnAtivar.Enabled = true;
                                btnDesativar.Enabled = true;
                                btnNovo.Enabled = true;
                            }
                        }
                        else
                        {
                            try
                            {
                                Usuario usu2 = new Usuario(cod,
                                txtNome.Text,
                                txtUsuario.Text,
                                txtSenha.Text,
                                txtConfSenha.Text,
                                cbbAcesso.Text);
                                usu.Alterar(usu2);
                                MessageBox.Show("Usuário alterado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao alterar usuário!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                this.Limpar();
                                op = 0;
                                dgvUsuario.DataSource = usu.Consultar();
                                this.HabilitarBotoes();
                                Desabilitado();
                                btnAtivar.Enabled = true;
                                btnDesativar.Enabled = true;
                                btnNovo.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nome de usuário já cadastrado no sistema, por favor escolha outro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Senhas não conferem, Digite novamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Clear();
                    txtConfSenha.Clear();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsuario_Click(object sender, EventArgs e)
        {
            Limpar();
            Desabilitado();
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
            btnNovo.Enabled = true;            
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if(dgvUsuario.SelectedCells[0].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja ativar este usuário? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvUsuario.SelectedCells[0].Value.ToString());
                        usu.Ativar(cod);
                        MessageBox.Show("Usuário ativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Registro vazio não pode ser ativado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Desabilitado();
                        }
                    }
                    finally
                    {
                        //Atualizar o data grid
                        dgvUsuario.DataSource = usu.Consultar();
                        HabilitarBotoes();

                        Limpar();
                        Desabilitado();
                        btnNovo.Enabled = true;
                    }
                }                    
            }
            else
            {
                MessageBox.Show("Usuário já está ativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if(dgvUsuario.SelectedCells[0].Value.ToString() != "ATIVO")
            {
                if((MessageBox.Show("Tem certeza que deseja desativar este usuário? ", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        cod = int.Parse(dgvUsuario.SelectedCells[0].Value.ToString());
                        usu.Desativar(cod);
                        MessageBox.Show("Usuário desativado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Registro vazio não pode ser desativado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Desabilitado();
                        }
                    }
                    finally
                    {
                        //Atualizar o data grid
                        dgvUsuario.DataSource = usu.Consultar();
                        HabilitarBotoes();

                        Limpar();
                        Desabilitado();
                        btnNovo.Enabled = true;
                    }
                }                   
            }
            else
            {
                MessageBox.Show("Usuário já está desativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                
        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            op = 0;
            if(dgvUsuario.SelectedCells[0].Value.ToString() != "")
            {
                try
                {
                    cod = int.Parse(dgvUsuario.SelectedCells[0].Value.ToString());
                    txtNome.Text = dgvUsuario.SelectedCells[1].Value.ToString();
                    txtUsuario.Text = dgvUsuario.SelectedCells[2].Value.ToString();
                    cbbAcesso.Text = dgvUsuario.SelectedCells[3].Value.ToString();
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("Erro ao realizar a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Desabilitado();
                    }
                }
                finally
                {
                    btnNovo.Enabled = false;
                    btnSalvar.Enabled = true;
                    Habilitar();
                }
            }
            else
            {
                if (MessageBox.Show("Registro vazio não pode ser consultado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Desabilitado();
                }
            }               
        }

        private void DgvUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvUsuario.Columns[0].HeaderText = "Código";
            dgvUsuario.Columns[1].HeaderText = "Nome";
            dgvUsuario.Columns[2].HeaderText = "Usuário";
            dgvUsuario.Columns[3].HeaderText = "Acesso";
            dgvUsuario.Columns[4].HeaderText = "Status";
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            this.Limpar();
            Desabilitado();
            dgvUsuario.DataSource = usu.Consultar();
            btnAtivar.Enabled = true;
            btnDesativar.Enabled = true;
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                op = 2;
                cod = int.Parse(dgvUsuario.SelectedCells[0].Value.ToString());

                this.HabilitarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas");
            }
        }

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesq.Text == "Nome")
            {
                dgvUsuario.DataSource = usu.PesquisarNomeUsu(txtPesq.Text);
            }
            else if (cbbPesq.Text == "Usuário")
            {
                dgvUsuario.DataSource = usu.PesquisarDescUsu(txtPesq.Text);
            }
        }

        //Botão para fechar o form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void NivelAcesso()
        {
            if(dgvUsuario.SelectedCells[4].ToString() == "Funcionário")
            {
                MessageBox.Show("Funcionario nao pode abrir tela de Usuario");
            }
        }
    }
}
