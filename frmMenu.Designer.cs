namespace OficinaGarage.Formularios
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segurançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblData = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblF8 = new System.Windows.Forms.Label();
            this.lblF7 = new System.Windows.Forms.Label();
            this.lblF6 = new System.Windows.Forms.Label();
            this.lblF5 = new System.Windows.Forms.Label();
            this.lblF4 = new System.Windows.Forms.Label();
            this.lblF3 = new System.Windows.Forms.Label();
            this.lblF2 = new System.Windows.Forms.Label();
            this.lblF1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordemDeServiçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quemSomosNósToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.btnSair, "btnSair");
            this.btnSair.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSair.Name = "btnSair";
            this.btnSair.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.serviçosToolStripMenuItem,
            this.segurançaToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.funcionárioToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.usuárioToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            resources.ApplyResources(this.cadastrosToolStripMenuItem, "cadastrosToolStripMenuItem");
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordemDeServiçoToolStripMenuItem,
            this.pesquisarOSToolStripMenuItem,
            this.consultarEstoqueToolStripMenuItem,
            this.adicionarEstoqueToolStripMenuItem});
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            resources.ApplyResources(this.serviçosToolStripMenuItem, "serviçosToolStripMenuItem");
            // 
            // segurançaToolStripMenuItem
            // 
            this.segurançaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.restoryToolStripMenuItem});
            this.segurançaToolStripMenuItem.Name = "segurançaToolStripMenuItem";
            resources.ApplyResources(this.segurançaToolStripMenuItem, "segurançaToolStripMenuItem");
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quemSomosNósToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            resources.ApplyResources(this.sobreToolStripMenuItem, "sobreToolStripMenuItem");
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contatoToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            resources.ApplyResources(this.ajudaToolStripMenuItem, "ajudaToolStripMenuItem");
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(this.sairToolStripMenuItem, "sairToolStripMenuItem");
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // lblHora
            // 
            resources.ApplyResources(this.lblHora, "lblHora");
            this.lblHora.Name = "lblHora";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.Name = "lblData";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblF8
            // 
            resources.ApplyResources(this.lblF8, "lblF8");
            this.lblF8.Name = "lblF8";
            // 
            // lblF7
            // 
            resources.ApplyResources(this.lblF7, "lblF7");
            this.lblF7.Name = "lblF7";
            // 
            // lblF6
            // 
            resources.ApplyResources(this.lblF6, "lblF6");
            this.lblF6.Name = "lblF6";
            // 
            // lblF5
            // 
            resources.ApplyResources(this.lblF5, "lblF5");
            this.lblF5.Name = "lblF5";
            // 
            // lblF4
            // 
            resources.ApplyResources(this.lblF4, "lblF4");
            this.lblF4.Name = "lblF4";
            // 
            // lblF3
            // 
            resources.ApplyResources(this.lblF3, "lblF3");
            this.lblF3.Name = "lblF3";
            // 
            // lblF2
            // 
            resources.ApplyResources(this.lblF2, "lblF2");
            this.lblF2.Name = "lblF2";
            // 
            // lblF1
            // 
            resources.ApplyResources(this.lblF1, "lblF1");
            this.lblF1.Name = "lblF1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OficinaGarage.Properties.Resources.car;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.cliente;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            resources.ApplyResources(this.clienteToolStripMenuItem, "clienteToolStripMenuItem");
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // funcionárioToolStripMenuItem
            // 
            this.funcionárioToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.funcionario;
            this.funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            resources.ApplyResources(this.funcionárioToolStripMenuItem, "funcionárioToolStripMenuItem");
            this.funcionárioToolStripMenuItem.Click += new System.EventHandler(this.funcionárioToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.produto;
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            resources.ApplyResources(this.produtoToolStripMenuItem, "produtoToolStripMenuItem");
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.usuario1;
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            resources.ApplyResources(this.usuárioToolStripMenuItem, "usuárioToolStripMenuItem");
            this.usuárioToolStripMenuItem.Click += new System.EventHandler(this.usuárioToolStripMenuItem_Click);
            // 
            // ordemDeServiçoToolStripMenuItem
            // 
            this.ordemDeServiçoToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.orcamento;
            this.ordemDeServiçoToolStripMenuItem.Name = "ordemDeServiçoToolStripMenuItem";
            resources.ApplyResources(this.ordemDeServiçoToolStripMenuItem, "ordemDeServiçoToolStripMenuItem");
            this.ordemDeServiçoToolStripMenuItem.Click += new System.EventHandler(this.ordemDeServiçoToolStripMenuItem_Click);
            // 
            // pesquisarOSToolStripMenuItem
            // 
            this.pesquisarOSToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.consultaOrc;
            this.pesquisarOSToolStripMenuItem.Name = "pesquisarOSToolStripMenuItem";
            resources.ApplyResources(this.pesquisarOSToolStripMenuItem, "pesquisarOSToolStripMenuItem");
            this.pesquisarOSToolStripMenuItem.Click += new System.EventHandler(this.pesquisarOSToolStripMenuItem_Click);
            // 
            // consultarEstoqueToolStripMenuItem
            // 
            this.consultarEstoqueToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.consultaEstoque;
            this.consultarEstoqueToolStripMenuItem.Name = "consultarEstoqueToolStripMenuItem";
            resources.ApplyResources(this.consultarEstoqueToolStripMenuItem, "consultarEstoqueToolStripMenuItem");
            this.consultarEstoqueToolStripMenuItem.Click += new System.EventHandler(this.consultarEstoqueToolStripMenuItem_Click);
            // 
            // adicionarEstoqueToolStripMenuItem
            // 
            this.adicionarEstoqueToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.ajustarSaldo;
            this.adicionarEstoqueToolStripMenuItem.Name = "adicionarEstoqueToolStripMenuItem";
            resources.ApplyResources(this.adicionarEstoqueToolStripMenuItem, "adicionarEstoqueToolStripMenuItem");
            this.adicionarEstoqueToolStripMenuItem.Click += new System.EventHandler(this.adicionarEstoqueToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.backupIco;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            resources.ApplyResources(this.backupToolStripMenuItem, "backupToolStripMenuItem");
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restoryToolStripMenuItem
            // 
            this.restoryToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.restoryIco;
            this.restoryToolStripMenuItem.Name = "restoryToolStripMenuItem";
            resources.ApplyResources(this.restoryToolStripMenuItem, "restoryToolStripMenuItem");
            this.restoryToolStripMenuItem.Click += new System.EventHandler(this.restoryToolStripMenuItem_Click);
            // 
            // quemSomosNósToolStripMenuItem
            // 
            this.quemSomosNósToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.car;
            this.quemSomosNósToolStripMenuItem.Name = "quemSomosNósToolStripMenuItem";
            resources.ApplyResources(this.quemSomosNósToolStripMenuItem, "quemSomosNósToolStripMenuItem");
            this.quemSomosNósToolStripMenuItem.Click += new System.EventHandler(this.quemSomosNósToolStripMenuItem_Click);
            // 
            // contatoToolStripMenuItem
            // 
            this.contatoToolStripMenuItem.Image = global::OficinaGarage.Properties.Resources.wpp;
            this.contatoToolStripMenuItem.Name = "contatoToolStripMenuItem";
            resources.ApplyResources(this.contatoToolStripMenuItem, "contatoToolStripMenuItem");
            this.contatoToolStripMenuItem.Click += new System.EventHandler(this.contatoToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblF8);
            this.Controls.Add(this.lblF7);
            this.Controls.Add(this.lblF6);
            this.Controls.Add(this.lblF5);
            this.Controls.Add(this.lblF4);
            this.Controls.Add(this.lblF3);
            this.Controls.Add(this.lblF2);
            this.Controls.Add(this.lblF1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordemDeServiçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quemSomosNósToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segurançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ToolStripMenuItem consultarEstoqueToolStripMenuItem;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem adicionarEstoqueToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblF8;
        private System.Windows.Forms.Label lblF7;
        private System.Windows.Forms.Label lblF6;
        private System.Windows.Forms.Label lblF5;
        private System.Windows.Forms.Label lblF4;
        private System.Windows.Forms.Label lblF3;
        private System.Windows.Forms.Label lblF2;
        private System.Windows.Forms.Label lblF1;
    }
}