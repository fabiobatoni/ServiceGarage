namespace OficinaGarage.Formularios
{
    partial class frmPesquisarOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisarOS));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbPesqOrc = new System.Windows.Forms.ComboBox();
            this.txtPesqOrc = new System.Windows.Forms.TextBox();
            this.dgvPesqOrc = new System.Windows.Forms.DataGridView();
            this.BtnImprimirOS = new System.Windows.Forms.Button();
            this.btnRelatorioOS = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqOrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar O.S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pesquisar:";
            // 
            // cbbPesqOrc
            // 
            this.cbbPesqOrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPesqOrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPesqOrc.FormattingEnabled = true;
            this.cbbPesqOrc.Items.AddRange(new object[] {
            "Cliente",
            "Placa"});
            this.cbbPesqOrc.Location = new System.Drawing.Point(117, 105);
            this.cbbPesqOrc.Name = "cbbPesqOrc";
            this.cbbPesqOrc.Size = new System.Drawing.Size(152, 24);
            this.cbbPesqOrc.TabIndex = 2;
            // 
            // txtPesqOrc
            // 
            this.txtPesqOrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesqOrc.Location = new System.Drawing.Point(275, 105);
            this.txtPesqOrc.Name = "txtPesqOrc";
            this.txtPesqOrc.Size = new System.Drawing.Size(349, 22);
            this.txtPesqOrc.TabIndex = 3;
            this.txtPesqOrc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPesqOrc_KeyUp);
            // 
            // dgvPesqOrc
            // 
            this.dgvPesqOrc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPesqOrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesqOrc.Location = new System.Drawing.Point(32, 135);
            this.dgvPesqOrc.Name = "dgvPesqOrc";
            this.dgvPesqOrc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesqOrc.Size = new System.Drawing.Size(592, 411);
            this.dgvPesqOrc.TabIndex = 4;
            this.dgvPesqOrc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPesqOrc_CellFormatting);
            // 
            // BtnImprimirOS
            // 
            this.BtnImprimirOS.Enabled = false;
            this.BtnImprimirOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimirOS.Location = new System.Drawing.Point(117, 552);
            this.BtnImprimirOS.Name = "BtnImprimirOS";
            this.BtnImprimirOS.Size = new System.Drawing.Size(166, 48);
            this.BtnImprimirOS.TabIndex = 5;
            this.BtnImprimirOS.Text = "Imprimir";
            this.BtnImprimirOS.UseVisualStyleBackColor = true;
            this.BtnImprimirOS.Click += new System.EventHandler(this.BtnImprimirOS_Click);
            // 
            // btnRelatorioOS
            // 
            this.btnRelatorioOS.Enabled = false;
            this.btnRelatorioOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorioOS.Location = new System.Drawing.Point(375, 552);
            this.btnRelatorioOS.Name = "btnRelatorioOS";
            this.btnRelatorioOS.Size = new System.Drawing.Size(166, 48);
            this.btnRelatorioOS.TabIndex = 6;
            this.btnRelatorioOS.Text = "Relatório";
            this.btnRelatorioOS.UseVisualStyleBackColor = true;
            this.btnRelatorioOS.Click += new System.EventHandler(this.btnRelatorioOS_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(594, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 44);
            this.button3.TabIndex = 7;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OficinaGarage.Properties.Resources.consultaOrc1;
            this.pictureBox1.Location = new System.Drawing.Point(32, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmPesquisarOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 628);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnRelatorioOS);
            this.Controls.Add(this.BtnImprimirOS);
            this.Controls.Add(this.dgvPesqOrc);
            this.Controls.Add(this.txtPesqOrc);
            this.Controls.Add(this.cbbPesqOrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisarOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPesquisarOS";
            this.Load += new System.EventHandler(this.frmPesquisarOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesqOrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbPesqOrc;
        private System.Windows.Forms.TextBox txtPesqOrc;
        private System.Windows.Forms.DataGridView dgvPesqOrc;
        private System.Windows.Forms.Button BtnImprimirOS;
        private System.Windows.Forms.Button btnRelatorioOS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}