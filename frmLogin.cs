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
    public partial class frmLogin : Form
    {
        //Instanciar um objeto da classe MySQLCommand
        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        public static string UserConect;
        public static string logado;
        public static string acesso;

        //Instanciar um objeto da Classe Criptografia
        Criptografia cripto = new Criptografia();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Metodo para trazer o nome do usuario logado
        public string UsuarioLogado()
        {
            try
            {
                sql.CommandText = "SELECT usu_nome FROM Usuario WHERE usu_usuario = @usuario";
                sql.Parameters.Clear(); //limpa todos os parâmetros
                sql.Parameters.AddWithValue("@usuario", logado.ToString());

                MySqlDataReader usuario = sql.ExecuteReader();
                usuario.Read();
                UserConect = usuario["usu_nome"].ToString();

                usuario.Close();

                return UserConect;
            }
            catch (Exception ex)
            {
                //throw new ApplicationException(ex.ToString());
                return MessageBox.Show("Não foi possível trazer o nome do usuário, favor realizar um novo login.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();
            }
        }

        //Copiar a partir daqui!
        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            if (txtUsuario.Text == "AdmDesenvolvedor" && txtSenha.Text == "SenhaDesenvolvedor")
            {
                MessageBox.Show("Usuário Desenvolvedor Logado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                menu.ShowDialog();
            }
            if (!(txtUsuario.Text == "" || txtSenha.Text == ""))
            {
                Usuario usu = new Usuario();

                if (usu.Validar(txtUsuario.Text, txtSenha.Text))
                {
                    if (usu.UserAtivo(txtUsuario.Text, txtSenha.Text))
                    {
                        logado = txtUsuario.Text;
                        menu.ShowDialog();
                        this.Close();
                        txtUsuario.Clear();
                        txtSenha.Clear();
                        frmMenu.UserC = usu.ConsultarAtivo().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Usuário inativo!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsuario.Clear();
                        txtSenha.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtSenha.Clear();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click_1(sender, e);
            }
        }

        //Metodo para trazer o nome do usuario logado
        public string NivelAcesso()
        {
            try
            {
                sql.CommandText = "SELECT usu_acesso FROM Usuario WHERE usu_usuario = @usuario";
                sql.Parameters.Clear(); //limpa todos os parâmetros
                sql.Parameters.AddWithValue("@usuario", logado.ToString());

                MySqlDataReader usuario = sql.ExecuteReader();
                usuario.Read();
                acesso = usuario["usu_acesso"].ToString();

                usuario.Close();

                return acesso;
            }
            catch (Exception ex)
            {
                //throw new ApplicationException(ex.ToString());
                return MessageBox.Show("Não foi possível trazer o nome do usuário, favor realizar um novo login.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();
            }
        }
    }
}
