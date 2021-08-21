namespace OficinaGarage.Formularios
{
    partial class frmPesquisarCliente
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesqCli = new System.Windows.Forms.TextBox();
            this.cbbPesqCli = new System.Windows.Forms.ComboBox();
            this.dgvPesqCli = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqCli)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(407, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(155, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pesquisar Cliente";
            // 
            // txtPesqCli
            // 
            this.txtPesqCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesqCli.Location = new System.Drawing.Point(159, 67);
            this.txtPesqCli.Name = "txtPesqCli";
            this.txtPesqCli.Size = new System.Drawing.Size(291, 22);
            this.txtPesqCli.TabIndex = 11;
            this.txtPesqCli.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPesqCli_KeyUp);
            // 
            // cbbPesqCli
            // 
            this.cbbPesqCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPesqCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPesqCli.FormattingEnabled = true;
            this.cbbPesqCli.Items.AddRange(new object[] {
            "Cliente",
            "CPF",
            "CNPJ",
            "Cidade"});
            this.cbbPesqCli.Location = new System.Drawing.Point(12, 65);
            this.cbbPesqCli.Name = "cbbPesqCli";
            this.cbbPesqCli.Size = new System.Drawing.Size(141, 24);
            this.cbbPesqCli.TabIndex = 10;
            // 
            // dgvPesqCli
            // 
            this.dgvPesqCli.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPesqCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesqCli.Location = new System.Drawing.Point(12, 93);
            this.dgvPesqCli.Name = "dgvPesqCli";
            this.dgvPesqCli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesqCli.Size = new System.Drawing.Size(438, 273);
            this.dgvPesqCli.TabIndex = 9;
            this.dgvPesqCli.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesqCli_CellDoubleClick);
            this.dgvPesqCli.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPesqCli_CellFormatting);
            // 
            // frmPesquisarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(468, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesqCli);
            this.Controls.Add(this.cbbPesqCli);
            this.Controls.Add(this.dgvPesqCli);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPesquisarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqCli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesqCli;
        private System.Windows.Forms.ComboBox cbbPesqCli;
        private System.Windows.Forms.DataGridView dgvPesqCli;
    }
}