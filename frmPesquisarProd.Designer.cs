namespace OficinaGarage.Formularios
{
    partial class frmPesquisarProd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesqProd = new System.Windows.Forms.TextBox();
            this.cbbPesqProd = new System.Windows.Forms.ComboBox();
            this.dgvPesqProd = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqProd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pesquisar Produto";
            // 
            // txtPesqProd
            // 
            this.txtPesqProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesqProd.Location = new System.Drawing.Point(172, 69);
            this.txtPesqProd.Name = "txtPesqProd";
            this.txtPesqProd.Size = new System.Drawing.Size(291, 22);
            this.txtPesqProd.TabIndex = 6;
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
            this.cbbPesqProd.Location = new System.Drawing.Point(25, 67);
            this.cbbPesqProd.Name = "cbbPesqProd";
            this.cbbPesqProd.Size = new System.Drawing.Size(141, 24);
            this.cbbPesqProd.TabIndex = 5;
            // 
            // dgvPesqProd
            // 
            this.dgvPesqProd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPesqProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesqProd.Location = new System.Drawing.Point(25, 95);
            this.dgvPesqProd.Name = "dgvPesqProd";
            this.dgvPesqProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesqProd.Size = new System.Drawing.Size(438, 273);
            this.dgvPesqProd.TabIndex = 4;
            this.dgvPesqProd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesqProd_CellDoubleClick);
            this.dgvPesqProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPesqProd_CellFormatting);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(426, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPesquisarProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesqProd);
            this.Controls.Add(this.cbbPesqProd);
            this.Controls.Add(this.dgvPesqProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisarProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPesquisarProd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesqProd;
        private System.Windows.Forms.ComboBox cbbPesqProd;
        private System.Windows.Forms.DataGridView dgvPesqProd;
        private System.Windows.Forms.Button button1;
    }
}