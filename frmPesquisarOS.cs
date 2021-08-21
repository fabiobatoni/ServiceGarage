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
using System.Drawing.Printing;

namespace OficinaGarage.Formularios
{
    public partial class frmPesquisarOS : Form
    {
        //Instanciar objetos das classes
        Orcamento orc = new Orcamento();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();
        private MySqlDataReader result;

        //Variaveis simples
        int cod = 0;

        public frmPesquisarOS()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesqOrc_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesqOrc.Text == "Cliente")
            {
                dgvPesqOrc.DataSource = orc.PesquisarNomeOrc(txtPesqOrc.Text);
            }
            else if (cbbPesqOrc.Text == "Placa")
            {
                dgvPesqOrc.DataSource = orc.PesquisarPlacaOrc(txtPesqOrc.Text);
            }
        }

        private void frmPesquisarOS_Load(object sender, EventArgs e)
        {
            dgvPesqOrc.DataSource = orc.ConsultarOrcamentoAprovado();
        }

        private void dgvPesqOrc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvPesqOrc.Columns[0].HeaderText = "Orçamento";
            dgvPesqOrc.Columns[1].HeaderText = "Data";
            dgvPesqOrc.Columns[2].HeaderText = "Responsável";
            dgvPesqOrc.Columns[3].HeaderText = "Funcionário";
            dgvPesqOrc.Columns[4].HeaderText = "Cliente";
            dgvPesqOrc.Columns[5].HeaderText = "Carro";
            dgvPesqOrc.Columns[6].HeaderText = "Marca";
            dgvPesqOrc.Columns[7].HeaderText = "Placa";
            dgvPesqOrc.Columns[8].HeaderText = "Ano/Modelo";
            dgvPesqOrc.Columns[9].HeaderText = "Modelo";
            dgvPesqOrc.Columns[10].HeaderText = "Total";
            dgvPesqOrc.Columns[11].HeaderText = "Ordem Serviço";
        }

        public void VisualizarImpressao()
        {            
            try
            {
                cod = int.Parse(dgvPesqOrc.SelectedCells[0].Value.ToString());
                PrintDocument doc = new PrintDocument();
                    doc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    PrintPreviewDialog visualizar = new PrintPreviewDialog();
                    visualizar.WindowState = FormWindowState.Maximized;
                    visualizar.PrintPreviewControl.Zoom = 1;
                    visualizar.Document = doc;
                    visualizar.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item selecionado em branco não possui informações!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Imprimir()
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                MySqlConnection con = Conexao.Conectar();
                MySqlCommand sql = con.CreateCommand();

                sql.CommandText = "SELECT orc_cod, orc_data, orc_respon, orc_funcionario, orc_cliNome, " +
                                  "orc_nomeCar, orc_marcaCar, orc_placaCar, orc_anoModCar, orc_modeloCar, orc_valorTotal, orc_statusOS FROM Orcamento";

                result = sql.ExecuteReader();
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Variáveis para definir configurações
            int contador = 0;
            float mE = e.MarginBounds.Left;
            float mS = e.MarginBounds.Top;
            float mD = e.MarginBounds.Right;
            float p = mS;
            SizeF s;
            string cliente = "";

            //Fontes utilizadas
            Font f14b = new Font("Arial", 14, FontStyle.Bold);
            Font f12b = new Font("Arial", 12, FontStyle.Bold);
            Font f10 = new Font("Arial", 10, FontStyle.Regular);

            //Cor da fonte
            SolidBrush preto = new SolidBrush(Color.Black);
            SolidBrush vermelho = new SolidBrush(Color.Red);

            //Variavel para criar um traço
            string traco = "";

            e.Graphics.DrawString("SISTEMA GARAGE",
                f14b, preto, mE, p, new StringFormat());

            e.Graphics.DrawString("Emitido em: " + DateTime.Now.ToString(),
                f12b, preto, mD - 300, p + 30, new StringFormat());

            //Verificar o tamanho do texto para centralizar
            s = e.Graphics.MeasureString("RELATÓRIO DA ORDEM DE SERVIÇO", f14b);

            //Colocar um traço "linha" no relatório
            e.Graphics.DrawString(traco.PadRight(80, '_'),
                f12b, vermelho, mE, p + 60, new StringFormat());

            e.Graphics.DrawString("RELATÓRIO DA ORDEM DE SERVIÇO",
                f14b, preto, (mD - s.Width) / 2, p + 80, new StringFormat());

            //Outro Traço
            e.Graphics.DrawString("RELATÓRIO DA ORDEM DE SERVIÇO",
                f14b, preto, (mD - s.Width) / 2, p + 80, new StringFormat());

            contador += 10;

            while (contador <= 850)
            {
                if (result.Read())
                {
                    if (!(result["orc_cliNome"].ToString().Equals(cliente)) || (contador == 10))
                    {
                        cliente = result["orc_cliNome"].ToString();
                        contador += 30;

                        e.Graphics.DrawString("Nome: " + cliente + "  Responsável: " + result["orc_respon"].ToString(), 
                             f12b, vermelho, mE, p + 130 + contador, new StringFormat());
                        contador += 20;

                        e.Graphics.DrawString("Funcionário: " + result["orc_funcionario"].ToString(), f10, preto, mE + 10, p + 130 + contador, new StringFormat());
                    }
                    else
                    {
                        contador += 20;
                        e.Graphics.DrawString("Funcionário: " + result["orc_funcionario"].ToString() + "  IBGE" +
                            result["orc_funcionario"].ToString(), f10, preto, mE + 10, p + 130 + contador, new StringFormat());
                    }
                }
                else
                {
                    contador = 900;
                }
            }

            if (contador < 900)
            {
                e.HasMorePages = true;
                contador = 10;
            }
            else
            {
                e.HasMorePages = false;
            }

            preto.Dispose();
            vermelho.Dispose();
        }

        private void BtnImprimirOS_Click(object sender, EventArgs e)
        {
            this.Imprimir();
        }

        private void btnRelatorioOS_Click(object sender, EventArgs e)
        {
            MySqlConnection con = Conexao.Conectar();
            MySqlCommand sql = con.CreateCommand();

            sql.CommandText = "SELECT orc_cod, orc_data, orc_respon, orc_funcionario, orc_cliNome, " +
                              "orc_nomeCar, orc_marcaCar, orc_placaCar, orc_anoModCar, orc_modeloCar, orc_valorTotal, orc_statusOS FROM Orcamento";

            /*sql.CommandText = "SELECT cidade, (estados.codIbge + " +
                "cidades.codIbge) AS ibge, estado, sigla FROM Cidades " +
                "INNER JOIN estados ON estados.codEstado = cidades.codEstado " +
                "ORDER BY estado, cidade";*/

            result = sql.ExecuteReader();
            this.VisualizarImpressao();
        }
    }
}
