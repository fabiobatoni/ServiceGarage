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
    public partial class frmOrcamento : Form
    {
        //Instanciar objetos das classes
        Orcamento orc = new Orcamento();
        Cliente cli = new Cliente();
        Produto pro = new Produto();
        Funcionario fun = new Funcionario();
        Usuario usu = new Usuario();
        ItensOrcamento ite = new ItensOrcamento();

        static MySqlConnection con = Conexao.Conectar();
        static MySqlCommand sql = con.CreateCommand();

        MySqlTransaction tr;

        //////////##ATRIBUTOS SIMPLES##///////////
        int op, cod, codI;
        private int codItem = 0;
        
        //variaveis para pesquisa de produto
        public static string desc;
        public static double valor;
        public static string codProd;

        //Variaveis para pesquisa de cliente
        public static string nome;

        //Iniciando a tela com a função desabilita
        public frmOrcamento()
        {
            InitializeComponent();
            Desabilita();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpar();
            Desabilita();
            btnNovo.Focus();
            this.Close();
        }

        //Metodo para Desabilitar campos na pesquisa do Datagrid
        public void DesabilitarConsulta()
        {
            cbbResponsavel.Enabled = false;
            cbbFuncionario.Enabled = false;
            txtCarro.Enabled = false;
            txtMarca.Enabled = false;
            txtPlaca.Enabled = false;
            txtAno.Enabled = false;
            txtModelo.Enabled = false;
            txtQtd.Enabled = false;
            txtMaoObra.Enabled = false;
            txtValorObra.Enabled = false;
            btnDeletarItem.Enabled = false;
            btnNovo.Enabled = false;
            btnPesqProd.Enabled = false;
            btnPesquisarCli.Enabled = false;
            btnInserirItem.Enabled = false;
            btnSalvar.Enabled = false;
        }

        //Metodo limpar Campos
        public void Limpar()
        {
            //this.PreencherCliente();
            this.PreencherUsuario();
            this.PreencherFuncionario();
           // this.PreencherProdutos();
            txtAno.Clear();
            txtCarro.Clear();
            txtCliente.Clear();
            txtMaoObra.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtPesquisaOrc.Clear();
            txtPlaca.Clear();

            txtQtd.Text = "0";
            txtValorObra.Text = "0.00";
            txtValorProd.Text = "0.00";
            cbbResponsavel.Text = null;
            txtDescricao.Clear();
            cbbFuncionario.Text = null;
            lblSubTotal.Text = "0.00";
            lblValorTotal.Text = "0.00";
        }


        //Habilita campos e botoes
        private void HabiltarBotoes()
        {
            btnNovo.Enabled = (op == 1);
            btnSalvar.Enabled = (op > 0);

            cbbResponsavel.Enabled = true;
            //txtDescricao.Enabled = true;
            cbbFuncionario.Enabled = true;
            txtAno.Enabled = true;
            txtCarro.Enabled = true;
            //txtCliente.Enabled = true;
            txtMaoObra.Enabled = true;
            txtMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtPesquisaOrc.Enabled = true;
            txtPlaca.Enabled = true;
            txtQtd.Enabled = true;
            txtValorObra.Enabled = true;
            txtValorProd.Enabled = false;
            btnSalvar.Enabled = true;
            btnDeletarItem.Enabled = true;
            btnInserirItem.Enabled = true;
            btnPesquisarCli.Enabled = true;
            btnPesqProd.Enabled = true;
        }

        //Metodo Desabilita Campos e Botões
        public void Desabilita()
        {
            txtAno.Enabled = false;
            txtCarro.Enabled = false;
            txtCliente.Enabled = false;
            txtMaoObra.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPlaca.Enabled = false;
            txtQtd.Enabled = false;
            txtValorObra.Enabled = false;
            txtValorProd.Enabled = false;
            cbbFuncionario.Enabled = false;
            txtDescricao.Enabled = false;
            cbbResponsavel.Enabled = false;
            btnSalvar.Enabled = false;
            btnDeletarItem.Enabled = false;
            btnInserirItem.Enabled = false;
            btnPesqProd.Enabled = false;
            btnPesquisarCli.Enabled = false;
            btnCancelarOS.Enabled = true;
            btnGerarOS.Enabled = true;
        }

        //Metodo Limpar Itens
        public void LimparItens()
        {
            txtQtd.Clear();
            txtMaoObra.Clear();
            txtValorObra.Clear();
            lblSubTotal.Text = "0,00";
        }

        //Metodo para somar o Orcamento
        public void SomarOrc()
        {
            double pproduto, qtdPro, valorObra, resultObra, subTotal;
            pproduto = Double.Parse(txtValorProd.Text);
            qtdPro = Double.Parse(txtQtd.Text);
            valorObra = Double.Parse(txtValorObra.Text);

            resultObra = pproduto * qtdPro + valorObra;

            subTotal = resultObra;

            lblSubTotal.Text = subTotal.ToString();

            SomaTotal(subTotal);
        }

        //Metodo para somar total
        public void SomaTotal(double subTotal)
        {
            double total = 0;
            total = total + subTotal;

            lblValorTotal.Text = total.ToString();
        }

        //Metodo para trazer os dados no DataGrid
        public DataTable ConsultarPro()
        {
            sql.CommandText = "SELECT pro_nome, pro_precoVenda FROM Produto";

            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dtProduto = new DataTable();

            da.Fill(dtProduto);
            return dtProduto;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Limpar();
            op = 1;
            cbbResponsavel.Focus();
            HabiltarBotoes();
            btnGerarOS.Enabled = false;
            btnCancelarOS.Enabled = false;
            cbbResponsavel.Focus();
            dgvItens.Rows.Clear();

            //Tratando Codigo do Orçamento atualizado
            dgvOrcamento.DataSource = orc.ConsultarOrcamento();
            if (dgvOrcamento.RowCount > 1)
            {
                txtNumOrc.Text = orc.NumOrc().ToString();
                dgvOrcamento.DataSource = orc.ConsultarOrcamento();
            }
            else
            {
                txtNumOrc.Text = orc.PrimeiroOrc().ToString();
            }
        }

        private void txtPesquisaOrc_Click(object sender, EventArgs e)
        {
            Limpar();
            btnNovo.Enabled = true;
            btnGerarOS.Enabled = true;
            Desabilita();
            orc.NumOrc();
        }

        private void dgvOrcamento_Click(object sender, EventArgs e)
        {
            Limpar();
            btnNovo.Enabled = true;
            btnGerarOS.Enabled = true;
            Desabilita();
            orc.NumOrc();
        }

        //Preencher o combobox com todos os Usuarios
        private void PreencherUsuario()
        {
            cbbResponsavel.DisplayMember = "usu_nome";
            cbbResponsavel.ValueMember = "usu_cod";
            cbbResponsavel.DataSource = usu.ConsultarAtivo();
        }

        //Preencher o combobox com todos os funcionarios
        private void PreencherFuncionario()
        {
            cbbFuncionario.DisplayMember = "fun_nome";
            cbbFuncionario.ValueMember = "fun_cod";
            cbbFuncionario.DataSource = fun.ConsultarAtivo();
        }

        private void txtQtd_Leave(object sender, EventArgs e)
        {
            double pproduto, qtdPro, resultProd, Total, valorObra;
            try
            {
                if (txtQtd.Text != "" && txtValorObra.Text != "")
                {
                    valorObra = Double.Parse(txtValorObra.Text);
                    if(txtValorProd.Text != "")
                    {
                        pproduto = Double.Parse(txtValorProd.Text);
                        qtdPro = Double.Parse(txtQtd.Text);

                        resultProd = pproduto * qtdPro + valorObra;

                        Total = resultProd;

                        lblSubTotal.Text = Total.ToString();
                    }
                }
                else if(txtQtd.Text != "" && txtValorObra.Text == "")
                {
                    if(txtValorProd.Text != "")
                    {
                        pproduto = Double.Parse(txtValorProd.Text);
                        qtdPro = Double.Parse(txtQtd.Text);
                        resultProd = pproduto * qtdPro;

                        Total = resultProd;

                        lblSubTotal.Text = Total.ToString();
                    }
                }
                else if (txtQtd.Text == "" && txtValorObra.Text != "")
                {
                    valorObra = Double.Parse(txtValorObra.Text);
                    pproduto = Double.Parse(txtValorProd.Text);
                    Total = valorObra;

                    lblSubTotal.Text = Total.ToString();
                }
                else if(txtQtd.Text == "" && txtValorProd.Text != "")
                {
                    MessageBox.Show("A quantidade precisa estar preenchida!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricao.Clear();
                    txtValorProd.Clear();
                }
                else 
                {
                    lblSubTotal.Text = "0,00";
                }           
            }
            catch(Exception ex)
            {
                MessageBox.Show("Houve um erro");
            }
                
        }

        private void txtValorObra_Leave(object sender, EventArgs e)
        {
            double pproduto, qtdPro, resultProd, Total, valorObra;
            try
            {
                if (txtQtd.Text != "" && txtValorObra.Text != "")
                {
                    if(txtValorProd.Text != "")
                    {
                        valorObra = Double.Parse(txtValorObra.Text);
                        pproduto = Double.Parse(txtValorProd.Text);
                        qtdPro = Double.Parse(txtQtd.Text);

                        resultProd = pproduto * qtdPro + valorObra;

                        Total = resultProd;

                        lblSubTotal.Text = Total.ToString();
                    }
                }
                else if (txtQtd.Text != "" && txtValorObra.Text == "")
                {
                    if(txtValorProd.Text != "")
                    {
                        pproduto = Double.Parse(txtValorProd.Text);
                        qtdPro = Double.Parse(txtQtd.Text);
                        resultProd = pproduto * qtdPro;

                        Total = resultProd;

                        lblSubTotal.Text = Total.ToString();
                    }
                }
                else if (txtQtd.Text == "" && txtValorObra.Text != "")
                {
                    valorObra = Double.Parse(txtValorObra.Text);
                    if(txtValorProd.Text != "")
                    {
                        pproduto = Double.Parse(txtValorProd.Text);
                    }
                    Total = valorObra;

                    lblSubTotal.Text = Total.ToString();
                }
                else
                {
                    lblSubTotal.Text = "0,00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro");
            }
        }

        private void frmOrcamento_Load(object sender, EventArgs e)
        {
            btnNovo.Focus();
            dgvOrcamento.DataSource = orc.ConsultarOrcamento();
            if (dgvOrcamento.RowCount > 1)
            {
                txtNumOrc.Text = orc.NumOrc().ToString();
                dgvOrcamento.DataSource = orc.ConsultarOrcamento();
            }
            else
            {
                txtNumOrc.Text = orc.PrimeiroOrc().ToString();
           }
            
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!(cbbResponsavel.Text == "" || cbbFuncionario.Text == "" || txtCliente.Text == "" || txtCarro.Text == "" || 
                txtMarca.Text == "" || txtPlaca.Text == "" || txtAno.Text == "" || txtModelo.Text == ""))
            {
                if (dgvItens.RowCount > 0)
                {
                    if(con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    
                    tr = con.BeginTransaction();
                    try
                    {
                        if (op == 1)
                        {
                            Orcamento orc1 = new Orcamento(0,
                                txtData.Text,
                                txtCliente.Text,
                                double.Parse(lblValorTotal.Text),
                                cbbFuncionario.Text,
                                cbbResponsavel.Text,
                                txtCarro.Text,
                                txtAno.Text,
                                txtMarca.Text,
                                txtModelo.Text,                               
                                txtPlaca.Text);
                            orc.CadastrarOrcamento(orc1);
                            //Alteramos aqui
                            ItensOrcamento ite1 = new ItensOrcamento();
                            InserirItens();
                            tr.Commit();
                            MessageBox.Show("Orçamento cadastrado com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Não foi possível realizar a operação!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        this.Limpar();
                        op = 0;
                        dgvOrcamento.DataSource = orc.ConsultarOrcamento();
                        dgvItens.Rows.Clear();
                        this.HabiltarBotoes();
                        Desabilita();
                        btnNovo.Enabled = true;
                        txtNumOrc.Text = orc.NumOrc().ToString();
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("O Orçamento precisa ter ao menos 1 item!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os dados do cliente e do carro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCliente.Focus();
            }                           
        }

        private void btnDeletarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItens.SelectedCells[0].Value.ToString() != "")
                {
                    dgvItens.Rows.Remove(dgvItens.CurrentRow);
                    lblValorTotal.Text = dgvItens.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[6].Value ?? 0)).ToString("##.00");
                    txtDescricao.Focus();
                    ZerandoTotal();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("É necessário selecionar o item desejado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void dgvOrcamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                op = 2;
                cod = int.Parse(dgvOrcamento.SelectedCells[0].Value.ToString());

                this.HabiltarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Estas Informações são fixas", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Metodo para zerar o total quando não conter nada no datagridview
        public void ZerandoTotal()
        {
            if(dgvItens.RowCount == 0)
            {
                lblValorTotal.Text = "0.00";
            }
        }


        private void dgvOrcamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Alterar o texto do cabeçalho
            dgvOrcamento.Columns[0].HeaderText = "Orçamento";
            dgvOrcamento.Columns[1].HeaderText = "Data";
            dgvOrcamento.Columns[2].HeaderText = "Responsável";
            dgvOrcamento.Columns[3].HeaderText = "Funcionário";
            dgvOrcamento.Columns[4].HeaderText = "Cliente";
            dgvOrcamento.Columns[5].HeaderText = "Carro";
            dgvOrcamento.Columns[6].HeaderText = "Marca";
            dgvOrcamento.Columns[7].HeaderText = "Placa";
            dgvOrcamento.Columns[8].HeaderText = "Ano/Modelo";
            dgvOrcamento.Columns[9].HeaderText = "Modelo";
            dgvOrcamento.Columns[10].HeaderText = "Total";
            dgvOrcamento.Columns[11].HeaderText = "Ordem Serviço";
        }

        private void dgvOrcamento_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DesabilitarConsulta();
            btnNovo.Enabled = true;
            txtQtd.Enabled = false;
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente numero e virgula", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtValorObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número e virgula", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Botao pesquisar produtos
        private void btnPesqProd_Click(object sender, EventArgs e)
        {
            frmPesquisarProd pesqProd = new frmPesquisarProd();
            pesqProd.ShowDialog();
            txtDescricao.Text = desc;
            txtValorProd.Text = valor.ToString();
            txtCodProd.Text = codProd;
        }
        //Botao pesquisar clientes
        private void btnPesquisarCli_Click(object sender, EventArgs e)
        {
            frmPesquisarCliente pesqCli = new frmPesquisarCliente();
            pesqCli.ShowDialog();
            txtCliente.Text = nome;
        }

        private void btnGerarOS_Click(object sender, EventArgs e)
        {
            if(dgvOrcamento.SelectedCells[0].Value != null)
            {
                if (dgvOrcamento.SelectedCells[11].Value.ToString() == "AGUARDANDO")
                {
                    if (MessageBox.Show("Tem certeza que deseja GERAR ORDEM DE SERVIÇO? ", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string estoque = ite.VeririfcarEstoque(cod);                            
                            //verificar se tem no estoque
                            if (estoque.Trim() != string.Empty)
                            { 
                                if(MessageBox.Show("Os itens abaixo não possuem estoque suficiente!\nDeseja continuar?\n" + estoque, "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    orc.GerarOS(cod);
                                    ite.RemoveSaldo(cod);
                                    MessageBox.Show("Ordem de serviço GERADA com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Ordem de serviço CANCELADA pelo usuário!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);                                   
                                }
                            }
                            else
                            {
                                cod = int.Parse(dgvOrcamento.SelectedCells[0].Value.ToString());
                                orc.GerarOS(cod);
                                ite.RemoveSaldo(cod);
                                MessageBox.Show("Ordem de serviço GERADA com sucesso!", "Bem-Sucedido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch (Exception ex)
                        {
                             if (MessageBox.Show("Erro ao gerar O.S!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                             {
                                 Desabilita();
                             }
                        }
                        finally
                        {
                            //Atualizar o data grid
                            dgvOrcamento.DataSource = orc.ConsultarOrcamento();
                            HabiltarBotoes();

                            Limpar();
                            Desabilita();
                            btnNovo.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Orçamento já aprovado ou cancelado, não pode gerar uma O.S!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Registro vazio não possui funções!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                          
        }

        private void btnCancelarOS_Click(object sender, EventArgs e)
        {
            if(dgvOrcamento.SelectedCells[11].Value.ToString() != "APROVADO")
            {
                if (dgvOrcamento.SelectedCells[11].Value.ToString() != "CANCELADO")
                {
                    if (MessageBox.Show("Tem certeza que deseja CANCELAR O ORÇAMENTO? ", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            cod = int.Parse(dgvOrcamento.SelectedCells[0].Value.ToString());
                            orc.CancelarOS(cod);
                            MessageBox.Show("Orçamento CANCELADO com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            if (MessageBox.Show("Registro vazio não possui funções!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                Desabilita();
                            }
                        }
                        finally
                        {
                            //Atualizar o data grid
                            dgvOrcamento.DataSource = orc.ConsultarOrcamento();
                            HabiltarBotoes();

                            Limpar();
                            Desabilita();
                            btnNovo.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Orçamento já está CANCELADO!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("O.S GERADA NÃO pode mais ser CANCELADA!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesquisaOrc_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbbPesqOrc.Text == "Cliente")
            {
                dgvOrcamento.DataSource = orc.PesquisarNomeOrc(txtPesquisaOrc.Text);
            }
            else if (cbbPesqOrc.Text == "Placa")
            {
                dgvOrcamento.DataSource = orc.PesquisarPlacaOrc(txtPesquisaOrc.Text);
            }
        }

        private void dgvOrcamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // dgvItens.DataSource = null;
            dgvItens.Rows.Clear();
            //DesabilitarConsulta();
           // ite.ConsultarItensOrc();
            if (dgvOrcamento.SelectedCells[0].Value.ToString() != "")
            {
                try
                {   //Dados do Responsavel, funcionário, data, Orcamento
                    cod = int.Parse(dgvOrcamento.SelectedCells[0].Value.ToString());
                    txtNumOrc.Text = dgvOrcamento.SelectedCells[0].Value.ToString();
                    txtData.Text = dgvOrcamento.SelectedCells[1].Value.ToString();
                    cbbResponsavel.Text = dgvOrcamento.SelectedCells[2].Value.ToString();
                    cbbFuncionario.Text = dgvOrcamento.SelectedCells[3].Value.ToString();
                    txtCliente.Text = dgvOrcamento.SelectedCells[4].Value.ToString();
                    txtCarro.Text = dgvOrcamento.SelectedCells[5].Value.ToString();
                    txtMarca.Text = dgvOrcamento.SelectedCells[6].Value.ToString();
                    txtPlaca.Text = dgvOrcamento.SelectedCells[7].Value.ToString();
                    txtAno.Text = dgvOrcamento.SelectedCells[8].Value.ToString();
                    txtModelo.Text = dgvOrcamento.SelectedCells[9].Value.ToString();

                    DataTable dados = ite.ConsultarItensOrc(cod);

                    for (int i = 0; i < dados.Rows.Count; i++)
                    {
                        dgvItens.Rows.Add(cod, dados.Rows[i]["ite_cod"].ToString(),
                            dados.Rows[i]["ite_nomeProd"].ToString(), dados.Rows[i]["ite_qtd"].ToString(),
                            dados.Rows[i]["ite_valorProd"].ToString(), dados.Rows[i]["ite_descObra"].ToString(),
                            dados.Rows[i]["ite_vlrObra"].ToString(), dados.Rows[i]["ite_subTotal"].ToString());
                    }
                    dgvItens.Refresh();
                    lblValorTotal.Text = dgvItens.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[7].Value ?? 0)).ToString("##.00");


                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("Erro ao tentar puxar os dados do orçamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Desabilita();
                        DesabilitarConsulta();
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

        private void txtAno_Leave(object sender, EventArgs e)
        {
            if (txtAno.Text.Length < 9)
            {
                txtCliente.Focus();
                MessageBox.Show("Ano/Modelo está Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            if (txtPlaca.Text.Length < 8)
            {
                txtCliente.Focus();
                MessageBox.Show("Placa está Incompleto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        //Botão Insere dados no list
        private void btnInserirItem_Click(object sender, EventArgs e)
        {
            if(!(txtDescricao.Text == "" && txtQtd.Text == "0" && txtValorProd.Text == "0.00" 
                && txtMaoObra.Text == "" && txtValorObra.Text == "0.00"))
            {
                if (txtQtd.Text != "0" && txtDescricao.Text == "")
                {
                    MessageBox.Show("Informe o produto desejado e depois a quantidade!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricao.Clear();
                    txtValorProd.Clear();
                    txtQtd.Text = "0";
                    txtValorProd.Text = "0.00";
                    txtMaoObra.Clear();
                    txtValorObra.Text = "0.00";
                }
                else if ((txtDescricao.Text != "" && txtQtd.Text == "") || (txtDescricao.Text != "" && txtQtd.Text == "0"))
                {
                    MessageBox.Show("Informe a quantidade do produto escolhido!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtMaoObra.Text != "" && txtValorObra.Text == "0.00" || txtValorObra.Text == "0" || txtValorObra.Text == "00.0" || txtValorObra.Text == "00")
                {
                    MessageBox.Show("Coloque o valor da mão de obra!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        codItem++;
                        dgvItens.Rows.Add(txtNumOrc.Text, codItem, txtDescricao.Text, txtQtd.Text, txtValorProd.Text, txtMaoObra.Text, txtValorObra.Text, lblSubTotal.Text, txtCodProd.Text);
                        dgvItens.Refresh();
                        lblValorTotal.Text = dgvItens.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[7].Value ?? 0)).ToString("##.00");
                        LimparItens();
                        txtDescricao.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao inserir item!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        txtDescricao.Clear();
                        txtQtd.Text = "0";
                        txtValorProd.Text = "0.00";
                        txtMaoObra.Clear();
                        txtValorObra.Text = "0.00";
                    }
                }
            }
            else
            {
                MessageBox.Show("É necessário ter algum produto ou mão de obra \npara inserir itens no orçamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Método para Inserir itens
        private void InserirItens()
        {
            sql.CommandText = "INSERT INTO itensorcamento (ite_cod, orc_cod, ite_nomeProd, ite_descObra, ite_qtd, ite_valorProd, ite_vlrObra, ite_subTotal, pro_cod) " +
							  "VALUES (@ci, @co, @np, @do, @qt, @vp, @vo, @vt, @pd);";

            sql.Parameters.Clear(); 

            //percorro o DataGridView
            for (int i = 0; i < dgvItens.Rows.Count; i++)
            {
				//limpo os parâmetros
				sql.Parameters.Clear();
				sql.Parameters.AddWithValue("@ci", dgvItens.Rows[i].Cells[1].Value);
                sql.Parameters.AddWithValue("@co", dgvItens.Rows[i].Cells[0].Value);
                sql.Parameters.AddWithValue("@np", dgvItens.Rows[i].Cells[2].Value);
                sql.Parameters.AddWithValue("@qt", dgvItens.Rows[i].Cells[3].Value);
                sql.Parameters.AddWithValue("@do", dgvItens.Rows[i].Cells[5].Value);
                sql.Parameters.AddWithValue("@vp", dgvItens.Rows[i].Cells[4].Value);
                sql.Parameters.AddWithValue("@vo", dgvItens.Rows[i].Cells[6].Value);
                sql.Parameters.AddWithValue("@vt", dgvItens.Rows[i].Cells[7].Value);
                sql.Parameters.AddWithValue("@pd", dgvItens.Rows[i].Cells[8].Value);
                //executo o comando

                try
				{
					sql.ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					throw new ApplicationException(ex.ToString());
				}
			}
            //Fecho conexão ****A CONEXÃO ESTÁ SENDO FECHADA DIRETO NA CLASSE PARA EVITAR ERROS*****
            //con.Close();
        }
    }
}
