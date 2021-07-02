namespace Util.TratamentoErros
{
    partial class frmVisualizarErro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarErro));
            this.lstMensagemErro = new System.Windows.Forms.ListBox();
            this.lstDetalhesErro = new System.Windows.Forms.ListBox();
            this.pctTipoErro = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctTipoErro)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMensagemErro
            // 
            this.lstMensagemErro.BackColor = System.Drawing.Color.White;
            this.lstMensagemErro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMensagemErro.FormattingEnabled = true;
            this.lstMensagemErro.HorizontalScrollbar = true;
            this.lstMensagemErro.Location = new System.Drawing.Point(95, 9);
            this.lstMensagemErro.Name = "lstMensagemErro";
            this.lstMensagemErro.Size = new System.Drawing.Size(429, 91);
            this.lstMensagemErro.TabIndex = 3;
            this.lstMensagemErro.TabStop = false;
            // 
            // lstDetalhesErro
            // 
            this.lstDetalhesErro.BackColor = System.Drawing.SystemColors.Control;
            this.lstDetalhesErro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDetalhesErro.FormattingEnabled = true;
            this.lstDetalhesErro.HorizontalScrollbar = true;
            this.lstDetalhesErro.Location = new System.Drawing.Point(14, 151);
            this.lstDetalhesErro.Name = "lstDetalhesErro";
            this.lstDetalhesErro.Size = new System.Drawing.Size(506, 145);
            this.lstDetalhesErro.TabIndex = 6;
            this.lstDetalhesErro.TabStop = false;
            // 
            // pctTipoErro
            // 
            this.pctTipoErro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctTipoErro.Image = global::Util.Properties.Resources.Pare;
            this.pctTipoErro.Location = new System.Drawing.Point(12, 12);
            this.pctTipoErro.Name = "pctTipoErro";
            this.pctTipoErro.Size = new System.Drawing.Size(66, 67);
            this.pctTipoErro.TabIndex = 0;
            this.pctTipoErro.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnDetalhes);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(-1, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 37);
            this.panel1.TabIndex = 7;
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Location = new System.Drawing.Point(10, 7);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(75, 23);
            this.btnDetalhes.TabIndex = 3;
            this.btnDetalhes.Text = "Detalhes ->";
            this.btnDetalhes.UseVisualStyleBackColor = true;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(447, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmVisualizarErro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstDetalhesErro);
            this.Controls.Add(this.lstMensagemErro);
            this.Controls.Add(this.pctTipoErro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisualizarErro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagem do Sistema - Solutions";
            ((System.ComponentModel.ISupportInitialize)(this.pctTipoErro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctTipoErro;
        private System.Windows.Forms.ListBox lstMensagemErro;
        private System.Windows.Forms.ListBox lstDetalhesErro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Button btnOk;
    }
}