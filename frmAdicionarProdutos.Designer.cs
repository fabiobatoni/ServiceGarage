namespace OficinaGarage.Formularios
{
    partial class frmAdicionarProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesqProd = new System.Windows.Forms.TextBox();
            this.cbbPesqProd = new System.Windows.Forms.ComboBox();
            this.dgvPesqProd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblAdc = new System.Windows.Forms.Label();
            this.txtAdicionar = new System.Windows.Forms.TextBox();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbOperacao = new System.Windows.Forms.ComboBox();
            this.txtRemover = new System.Windows.Forms.TextBox();
            this.lblRemover = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Red;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechar.Location = new System.Drawing.Point(479, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(49, 31);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ajustar Saldo Produto";
            // 
            // txtPesqProd
            // 
            this.txtPesqProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesqProd.Location = new System.Drawing.Point(197, 95);
            this.txtPesqProd.Name = "txtPesqProd";
            this.txtPesqProd.Size = new System.Drawing.Size(307, 22);
            this.txtPesqProd.TabIndex = 11;
            this.txtPesqProd.Click += new System.EventHandler(this.txtPesqProd_Click);
            this.txtPesqProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPesqProd_KeyUp);
            // 
            // cbbPesqProd
            // 
            this.cbbPesqProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPesqProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPesqProd.FormattingEnabled = true;
            this.cbbPesqProd.Items.AddRange(new object[] {
            "Nome",
            "Descrição"});
            this.cbbPesqProd.Location = new System.Drawing.Point(33, 93);
            this.cbbPesqProd.Name = "cbbPesqProd";
            this.cbbPesqProd.Size = new System.Drawing.Size(158, 24);
            this.cbbPesqProd.TabIndex = 10;
            // 
            // dgvPesqProd
            // 
            this.dgvPesqProd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPesqProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesqProd.Location = new System.Drawing.Point(33, 121);
            this.dgvPesqProd.Name = "dgvPesqProd";
            this.dgvPesqProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesqProd.Size = new System.Drawing.Size(471, 211);
            this.dgvPesqProd.TabIndex = 9;
            this.dgvPesqProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesqProd_CellClick);
            this.dgvPesqProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesqProd_CellContentClick);
            this.dgvPesqProd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesqProd_CellDoubleClick);
            this.dgvPesqProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPesqProd_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descrição:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Quantidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(266, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Unidade/Med:";
            // 
            // txtUnidade
            // 
            this.txtUnidade.Enabled = false;
            this.txtUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidade.Location = new System.Drawing.Point(378, 423);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(126, 22);
            this.txtUnidade.TabIndex = 18;
            // 
            // txtQtd
            // 
            this.txtQtd.Enabled = false;
            this.txtQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtd.Location = new System.Drawing.Point(106, 420);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(126, 22);
            this.txtQtd.TabIndex = 19;
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(106, 386);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(398, 22);
            this.txtDesc.TabIndex = 20;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(106, 352);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(398, 22);
            this.txtNome.TabIndex = 21;
            // 
            // lblAdc
            // 
            this.lblAdc.AutoSize = true;
            this.lblAdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdc.Location = new System.Drawing.Point(17, 500);
            this.lblAdc.Name = "lblAdc";
            this.lblAdc.Size = new System.Drawing.Size(78, 16);
            this.lblAdc.TabIndex = 22;
            this.lblAdc.Text = "Adicionar:";
            this.lblAdc.Visible = false;
            // 
            // txtAdicionar
            // 
            this.txtAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdicionar.Location = new System.Drawing.Point(106, 497);
            this.txtAdicionar.Name = "txtAdicionar";
            this.txtAdicionar.Size = new System.Drawing.Size(126, 22);
            this.txtAdicionar.TabIndex = 23;
            this.txtAdicionar.Visible = false;
            this.txtAdicionar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAdicionar_KeyPress);
            // 
            // btnDepositar
            // 
            this.btnDepositar.Enabled = false;
            this.btnDepositar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepositar.Location = new System.Drawing.Point(378, 491);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(126, 35);
            this.btnDepositar.TabIndex = 24;
            this.btnDepositar.Text = "Adicionar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Visible = false;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Operação:";
            // 
            // cbbOperacao
            // 
            this.cbbOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOperacao.Enabled = false;
            this.cbbOperacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOperacao.FormattingEnabled = true;
            this.cbbOperacao.Items.AddRange(new object[] {
            "Adicionar",
            "Remover"});
            this.cbbOperacao.Location = new System.Drawing.Point(106, 457);
            this.cbbOperacao.Name = "cbbOperacao";
            this.cbbOperacao.Size = new System.Drawing.Size(126, 24);
            this.cbbOperacao.TabIndex = 26;
            this.cbbOperacao.SelectedIndexChanged += new System.EventHandler(this.cbbOperacao_SelectedIndexChanged);
            // 
            // txtRemover
            // 
            this.txtRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemover.Location = new System.Drawing.Point(106, 497);
            this.txtRemover.Name = "txtRemover";
            this.txtRemover.Size = new System.Drawing.Size(126, 22);
            this.txtRemover.TabIndex = 27;
            this.txtRemover.Visible = false;
            this.txtRemover.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRemover_KeyPress);
            // 
            // lblRemover
            // 
            this.lblRemover.AutoSize = true;
            this.lblRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemover.Location = new System.Drawing.Point(17, 500);
            this.lblRemover.Name = "lblRemover";
            this.lblRemover.Size = new System.Drawing.Size(75, 16);
            this.lblRemover.TabIndex = 28;
            this.lblRemover.Text = "Remover:";
            this.lblRemover.Visible = false;
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(378, 491);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(126, 35);
            this.btnRemover.TabIndex = 29;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Visible = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OficinaGarage.Properties.Resources.ajustarSaldo2;
            this.pictureBox1.Location = new System.Drawing.Point(33, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // frmAdicionarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 540);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.lblRemover);
            this.Controls.Add(this.txtRemover);
            this.Controls.Add(this.cbbOperacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.txtAdicionar);
            this.Controls.Add(this.lblAdc);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesqProd);
            this.Controls.Add(this.cbbPesqProd);
            this.Controls.Add(this.dgvPesqProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdicionarProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdicionarProdutos";
            this.Load += new System.EventHandler(this.frmAdicionarProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesqProd;
        private System.Windows.Forms.ComboBox cbbPesqProd;
        private System.Windows.Forms.DataGridView dgvPesqProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblAdc;
        private System.Windows.Forms.TextBox txtAdicionar;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbOperacao;
        private System.Windows.Forms.TextBox txtRemover;
        private System.Windows.Forms.Label lblRemover;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}