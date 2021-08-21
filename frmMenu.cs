using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OficinaGarage.Conexoes;
using OficinaGarage.Classes;
using OficinaGarage.Formularios;
using MySql.Data.MySqlClient;

namespace OficinaGarage.Formularios
{
    public partial class frmMenu : Form
    {
        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();
        Usuario usu = new Usuario();
        frmLogin login = new frmLogin();
        DateTime dt_hr;

        //Variaveis Normais
        public static string user;
        public static string UserC;
        public static string na;

        public frmMenu()
        {
            InitializeComponent();
            //UserC = usu.IdentificarUser().ToString();
            //lblUser.Text = user;
            //usu.ConsultarAtivo();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cli = new frmCliente();
            cli.ShowDialog();            
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmCadastrarFuncionário func = new frmCadastrarFuncionário();
                func.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmProduto pro = new frmProduto();
                pro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmCadUsuario usu = new frmCadUsuario();
                usu.ShowDialog();
            }
            else
            {
                usuárioToolStripMenuItem.Enabled = false;
                //MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ordemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrcamento orc = new frmOrcamento();
            orc.ShowDialog();
        }

        private void pesquisarOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPesquisarOS pesq = new frmPesquisarOS();
            pesq.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmBackup back = new frmBackup();
                back.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void restoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmRestory rest = new frmRestory();
                rest.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }  
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmLogin logado = new frmLogin();
            lblUser.Text = logado.UsuarioLogado();

            if(login.NivelAcesso() != "Administrador")
            {
                usuárioToolStripMenuItem.Enabled = false;
                funcionárioToolStripMenuItem.Enabled = false;
                produtoToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
                restoryToolStripMenuItem.Enabled = false;
                adicionarEstoqueToolStripMenuItem.Enabled = false;
            }
        }

        private void consultarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaEstoque estoque = new frmConsultaEstoque();
            estoque.ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dt_hr = DateTime.Now;
            lblData.Text = dt_hr.ToLongDateString();
            lblHora.Text = "Horário: " + dt_hr.ToLongTimeString();
        }

        private void adicionarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login.NivelAcesso() == "Administrador")
            {
                frmAdicionarProdutos adc = new frmAdicionarProdutos();
                adc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem acesso a rotina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void quemSomosNósToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sob = new frmSobre();
            sob.ShowDialog();
        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContato cont = new frmContato();
            cont.ShowDialog();
        }
    }
}
